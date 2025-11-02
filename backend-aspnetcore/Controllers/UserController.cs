using BackendAspNetCore.Dtos.Response;
using BackendAspNetCore.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNetCore.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _iUserService;

    public UserController(IUserService iUserService)
    {
        _iUserService = iUserService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUser()
    {
        var response = await _iUserService.GetAllUserAsync();
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] AddUserRequestBody input)
    {
        var response = await _iUserService.AddUserAsync(input);
        return StatusCode(response.StatusCode, response);
    }
}