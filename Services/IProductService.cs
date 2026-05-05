using APBD_TEST_TEMPLATE.DTOs;

namespace APBD_TEST_TEMPLATE.Services;

public interface IProductService
{
    Task<MakerProductsResponse> GetMakerProductsAsync(int makerId);
}