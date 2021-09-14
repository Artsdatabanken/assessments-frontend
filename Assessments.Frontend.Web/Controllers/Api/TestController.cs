using Microsoft.AspNetCore.Mvc;

namespace Assessments.Frontend.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : BaseController<TestController>
    {
        [HttpGet]
        public string Get() => $"Hello from {Environment.EnvironmentName.ToLower()} environment";
    }
}
