using APBD_TEST_TEMPLATE.DTOs;
using APBD_TEST_TEMPLATE.Repositories;

namespace APBD_TEST_TEMPLATE.Services;

public class ProductsService
{
    private readonly IProductRepository _productRepository;
    
    public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

    public Task<MakerProductsResponse?> GetMakerProductsAsync(int makerId)
    {
        return _productRepository.GetMakerProductsAsync(makerId);
    }
}