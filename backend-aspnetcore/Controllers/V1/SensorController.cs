
using Microsoft.AspNetCore.Mvc;
using BackendAspNetCore.Services.SensorServices;

namespace BackendAspNetCore.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/sensor")]
public class SensorController(ISensorService iSensorService) : ControllerBase
{
    private readonly ISensorService _iSensorService = iSensorService;

    [HttpPost]
    public async Task<IActionResult> RemoveSensor([FromBody] AddSensorRequestBody input)
    {
        var response = await _iSensorService.SaveOrUpdateSensorAsync(input);
        return StatusCode(response.StatusCode, response);
    }
}