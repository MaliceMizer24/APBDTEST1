using APBD_TEST_TEMPLATE.DTOs;

namespace APBD_TEST_TEMPLATE.Repositories;

public interface IProductRepository
{
    Task<MakerProductsResponse?> GetMakerProductsAsync(int makerId);
}