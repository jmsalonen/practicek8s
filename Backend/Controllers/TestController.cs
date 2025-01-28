using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet("endpoint/test")]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("/api/endpoint/test received a request");

        return Ok("/api/endpoint/test received a request successfully");
    }
}
