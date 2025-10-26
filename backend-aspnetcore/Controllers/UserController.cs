using BackendAspNetCore.Dtos.Response;
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
        var users = await _iUserService.GetAllUserAsync();
        return Ok(users);
    }
}