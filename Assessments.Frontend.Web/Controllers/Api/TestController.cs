using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Assessments.Frontend.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class TestController : Controller
{
    private readonly IWebHostEnvironment _environment;

    public TestController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    [HttpGet]
    public IActionResult Get() => Ok($"Hello from {_environment.EnvironmentName.ToLower()} environment!");
}