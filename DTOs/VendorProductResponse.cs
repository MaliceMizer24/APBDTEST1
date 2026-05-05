using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace APBD_TEST_TEMPLATE.DTOs;

public class VendorProductResponse
{
    [Required]
    public string Name { get; set; }  = null!;
    
    public int Amount { get; set; }
    
    public decimal PricePerUnit { get; set; }
}