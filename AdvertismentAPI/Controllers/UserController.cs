using Advertisment.BLL.IServices;
using Advertisment.DAL.Enteties;
using Microsoft.AspNetCore.Mvc;

namespace AdvertismentAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService) => this.userService = userService;

    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAll()
    {
        var result = await userService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("GetUserById/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await userService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpDelete("DeleteUserById/{id}")]
    public async Task<IActionResult> DeleteById(string id)
    {
        await userService.DeleteByIdAsync(id);
        return Ok();
    }

    [HttpPost("InsertUser")]
    public async Task<IActionResult> Insert([FromBody] User user)
    {
        await userService.InsertAsync(user);
        return Ok();
    }

    [HttpPost("UpdateUser")]
    public async Task<IActionResult> Update([FromBody] User user)
    {
        var result = await userService.UpdateAsync(user);
        return Ok(result);
    }
}
