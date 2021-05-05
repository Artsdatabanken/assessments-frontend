using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Artsdatabanken;
using Assessments.Frontend.Web.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Assessments.Frontend.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly AssessmentApiService _assessmentApi;
        private readonly ILogger<TestController> _logger;

        public TestController(AssessmentApiService assessmentApi, ILogger<TestController> logger)
        {
            _logger = logger;
            _assessmentApi = assessmentApi;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _assessmentApi.Redlist2015.ExecuteAsync();

            return View(results.ToList());
        }

        [Route("[controller]/{id:required:int}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                return View(await _assessmentApi.Redlist2015.ByKey(id).GetValueAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }
        }

        public IActionResult HttpClient()
        {
            return View();
        }
    }
}
