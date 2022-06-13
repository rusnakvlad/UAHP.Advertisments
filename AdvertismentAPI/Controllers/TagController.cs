using Advertisment.BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AdvertismentAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ITagService tagService;

    public TagController(ITagService tagService) => this.tagService = tagService;

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await tagService.GetAllAsync();
        return Ok(response);
    }

    [HttpPost("Insert")]
    public async Task Insert([FromQuery] string tag)
    {
        await tagService.InsertAsync(tag);
    }

    [HttpDelete("Delete")]
    public async Task Delete([FromQuery] string tag)
    {
        await tagService.DeleteAsync(tag);
    }
}
