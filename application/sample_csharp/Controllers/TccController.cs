using Microsoft.AspNetCore.Mvc;

namespace sample_csharp.Controllers;

[ApiController]
[Route("[controller]")]
public class TccController : ControllerBase
{
    private readonly ILogger<TccController> _logger;
    private readonly IConfiguration _config;

    public TccController(ILogger<TccController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    [HttpGet(Name = "GetEnvironment")]
    public IActionResult GetEnvironment()
    {
        var tz = _config["TZ"];
        var env = _config["ASPNETCORE_ENVIRONMENT"];

        return Ok(new { timezone = tz, environment = env });
    }
}
