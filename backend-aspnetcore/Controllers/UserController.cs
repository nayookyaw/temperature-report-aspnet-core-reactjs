using BackendAspNetCore.Dtos.Response;
using BackendAspNetCore.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace BackendAspNetCore.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(IUserService iUserService) : ControllerBase
{
    private readonly IUserService _iUserService = iUserService;

    [HttpGet]
    public async Task<IActionResult> GetAllUser()
    {
        var response = await _iUserService.GetAllUserAsync();
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] AddUserRequestBody input)
    {
        var response = await _iUserService.AddUserAsync(input);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> UpdateUser(Guid userId, [FromBody]UpdateUserRequestBody input)
    {
        var response = await _iUserService.UpdateUserAsync(userId,input);
        return StatusCode(response.StatusCode, response);
    }
}