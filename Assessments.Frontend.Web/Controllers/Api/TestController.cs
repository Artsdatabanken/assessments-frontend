using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Assessments.Frontend.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class TestController(IWebHostEnvironment environment) : ControllerBase
{
    [HttpGet]
    public IActionResult Test() => Ok($"Hello from {environment.EnvironmentName}");
}