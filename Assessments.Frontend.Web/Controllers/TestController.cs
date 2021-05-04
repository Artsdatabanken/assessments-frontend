using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Artsdatabanken;
using Assessments.Frontend.Web.Infrastructure;

namespace Assessments.Frontend.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly AssessmentApiService _assessmentApi;

        public TestController(AssessmentApiService assessmentApi)
        {
            _assessmentApi = assessmentApi;
        }

        public async Task<IActionResult> Index()
        {
            var results = await _assessmentApi.Redlist2015.ExecuteAsync();

            return View(results.ToList());
        }

        [Route("[controller]/{id:required}")]
        public async Task<IActionResult> Detail(string id)
        {
            try
            {
                var key = HttpUtility.UrlDecode(id);

                var result = await _assessmentApi.Redlist2015.ByKey(key).GetValueAsync();
                
                return View(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
