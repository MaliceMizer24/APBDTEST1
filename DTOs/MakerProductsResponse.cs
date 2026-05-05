using System.ComponentModel.DataAnnotations;

namespace APBD_TEST_TEMPLATE.DTOs;

public class MakerProductsResponse
{
    public string Name { get; set; } = null!;
    public List<ProductResponse> Products { get; set; } = new();
}