using Microsoft.AspNetCore.Mvc;

namespace Assessments.Frontend.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class TestController : BaseApiController<TestController>
    {
        [HttpGet]
        public IActionResult Get() => Ok($"Hello from {Environment.EnvironmentName.ToLower()} environment");
    }
}
