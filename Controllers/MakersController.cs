using APBD_TEST_TEMPLATE.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_TEST_TEMPLATE.Controllers;
[ApiController]
[Route("api/makers")]
public class MakersController : ControllerBase
{
    
    private readonly IProductService _productService;

    public MakersController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetMaker(int id)
    {
        var maker = await _productService.GetMakerProductsAsync(id);
        if (maker is null)
        {
            return NotFound();
        }
            
        return Ok(maker);
    }
}