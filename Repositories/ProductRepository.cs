using APBD_TEST_TEMPLATE.DTOs;
using Microsoft.Data.SqlClient;

namespace APBD_TEST_TEMPLATE.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly string _connectionString;

    public ProductRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Default")
            ?? throw new InvalidOperationException("No connection string found");
    }

    public async Task<MakerProductsResponse> GetMakerProductsAsync(int makerId)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        String name;
        
        await using (var makerCommand = new SqlCommand(
                         "SELECT Name FROM Makers WHERE Id = @makerId;",
                         connection))
        {
            makerCommand.Parameters.AddWithValue("@makerId", makerId);

            await using var customerReader = await makerCommand.ExecuteReaderAsync();
            if (!await customerReader.ReadAsync())
            {
                return null;
            }

            name = customerReader.GetString(0);
        }
        var productsById = new Dictionary<int, ProductResponse>();
        await using (var productsCommand = new SqlCommand(@"
            SELECT  p.Id,
                    p.Name,
                    p.Description,
                    t.name           AS product_type_name,
                    v.Name          AS vendor_name,
					vp.Amount,
                    vp.PricePerUnit AS price_per_unit
            FROM    Products p
            JOIN    ProductTypes  t  ON p.ProductTypeId = t.Id
            LEFT JOIN VendorProducts vp ON vp.ProductId = p.Id
            LEFT JOIN Vendors       v  ON v.Code  = vp.VendorCode
            WHERE   p.MakerId = @makerId
            ORDER BY p.Id, v.Name;", connection))
        {
            productsCommand.Parameters.AddWithValue("@makerId", makerId);

            await using var reader = await productsCommand.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var productId = reader.GetInt32(0);

                if (!productsById.TryGetValue(productId, out var product))
                {
                    product = new ProductResponse
                    {
                        Id = productId,
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        StickerPrice = reader.GetDecimal(3),
                        VendorProducts = new List<VendorProductResponse>()
                    };
                    productsById.Add(productId,product);
                }

                if (!reader.IsDBNull(4))
                {
                    product.VendorProducts.Add(new VendorProductResponse
                    {
                        Name = reader.GetString(4),
                        Amount = reader.GetInt32(5),
                        PricePerUnit = reader.GetDecimal(6),
                    });
                }
            }
        }

        return new MakerProductsResponse
        {
            Name = name,
            Products = productsById.Values.ToList()
        };
    }
}