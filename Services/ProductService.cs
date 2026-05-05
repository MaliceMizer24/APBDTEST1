using APBD_TEST_TEMPLATE.DTOs;
using APBD_TEST_TEMPLATE.Repositories;

namespace APBD_TEST_TEMPLATE.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    
    public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

    public Task<MakerProductsResponse?> GetMakerProductsAsync(int makerId)
    {
        return _productRepository.GetMakerProductsAsync(makerId);
    }
}