using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Assessments.Frontend.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    private readonly IConfiguration _configuration;

    public TestController(IWebHostEnvironment environment, IConfiguration configuration
    )
    {
        _configuration = configuration;
        _environment = environment;
    }

    [HttpGet("")]
    public IActionResult Test() => Ok($"Hello from {_environment.EnvironmentName.ToLower()} environment!");

    [HttpGet("database")]
    public IActionResult DatabaseInfo()
    {
        if (_environment.IsProduction())
            return NotFound();

        var connectionString = _configuration.GetConnectionString("Default");
        var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
        
        return Ok($"DataSource: '{sqlConnectionStringBuilder.DataSource}', UserID: '{sqlConnectionStringBuilder.UserID}', InitialCatalog: '{sqlConnectionStringBuilder.InitialCatalog}'");
    }
}