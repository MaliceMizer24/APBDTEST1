using System.ComponentModel.DataAnnotations;

namespace APBD_TEST_TEMPLATE.DTOs;

public class MakerDto
{
    public int Id { get; set; }
    [Required] public string Name { get; set; } = null!;
}