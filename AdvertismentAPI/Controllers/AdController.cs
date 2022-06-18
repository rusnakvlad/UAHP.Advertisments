using Advertisment.BLL.DTO;
using Advertisment.BLL.IServices;
using Advertisment.DAL.Enteties;
using AdvertismentAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace AdvertismentAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AdController : ControllerBase
{
    private readonly IAdService adService;
    private readonly IAdPublisher adPublisher;

    public AdController(IAdService adService, IAdPublisher adPublisher)
    {
        this.adService = adService;
        this.adPublisher = adPublisher;
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetAdvertismentById([FromQuery] int id)
    {
        var result = await adService.GetByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteUserById([FromQuery] int id)
    {
        await adService.DeleteByIdAsync(id);
        return NoContent();
    }

    [HttpPost("Insert")]
    public async Task<IActionResult> InsertAdvertisment([FromBody] AdCreateDTO advertisment)
    {
        var result = await adService.InsertAsync(advertisment);
        adPublisher.Publish(result);

        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAdvertisment([FromBody] Ad advertisment)
    {
        var result = await adService.UpdateAsync(advertisment);
        return Ok(result);
    }
}
