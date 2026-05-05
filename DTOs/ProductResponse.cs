using System.ComponentModel.DataAnnotations;

namespace APBD_TEST_TEMPLATE.DTOs;

public class ProductResponse
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Description { get; set; } =  null!;
    
    public decimal StickerPrice { get; set; }
    public List<VendorProductResponse> VendorProducts { get; set; } = new();
}