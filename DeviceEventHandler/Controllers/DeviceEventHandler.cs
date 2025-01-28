using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api")]
public class DeviceEventController : ControllerBase
{
    private readonly ILogger<DeviceEventController> _logger;

    public DeviceEventController(ILogger<DeviceEventController> logger)
    {
        _logger = logger;
    }

    [HttpGet("DeviceEventHandler/test")]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("DeviceEvent received");

        return Ok("DeviceEvent received successfully");
    }

    [HttpPost("DeviceEventHandler/event")]
    public async Task<IActionResult> PostEvent([FromBody] JsonObject deviceEvent)
    {
        _logger.LogInformation($"DeviceEvent received: {JsonSerializer.Serialize(deviceEvent)}");

        return Ok($"DeviceEvent received successfully: {JsonSerializer.Serialize(deviceEvent)}");
    }
}
