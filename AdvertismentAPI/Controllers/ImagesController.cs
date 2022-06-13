using Advertisment.BLL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvertismentAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IImageService imageService;
    public ImagesController(IImageService imageService) => this.imageService = imageService;

    [HttpGet("GetByAdId")]
    public async Task<IActionResult> GetImagesByAdId([FromQuery] int adId)
    {
        var response = await imageService.GetImagesByAdId(adId);
        return Ok(response);
    }
    
    [HttpDelete("Delete")]
    public async Task DeleteImageById([FromQuery] int id)
    {
        await imageService.DeleteById(id);
    }

}
