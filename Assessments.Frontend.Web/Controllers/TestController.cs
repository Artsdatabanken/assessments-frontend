using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Artsdatabanken;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Frontend.Web.Models;
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

        public IActionResult Index()
        {
            var viewModel = new TestViewModel
            {
                
            };

            return View(viewModel);
        }

        [Route("[controller]/2015")]
        public IActionResult Index2015()
        {
            var viewModel = new RL2015ViewModel
            {
                Redlist2015Results = _assessmentApi.Redlist2015.Take(100).ToList()
            };

            return View("List2015", viewModel);
        }

        [Route("[controller]/2006")]
        public IActionResult Index2006()
        {
            var viewModel = new RL2006ViewModel
            {
                Redlist2006Results = _assessmentApi.Redlist2006.Take(100).ToList()
            };

            return View("List2006", viewModel);
        }

        [Route("[controller]/{id:required}")]
        public async Task<IActionResult> Detail(string id, int year, string vurderingscontext)
        {
            try
            {
                switch (year)
                {
                    case 2015:

                        var rodliste2015 = await _assessmentApi.Redlist2015.ByKey(Convert.ToInt32(id), vurderingscontext).GetValueAsync();

                        return View("SpeciesAssessment2015", rodliste2015);
                    
                    case 2006:
                        
                        var redlist2006Assessment = await _assessmentApi.Redlist2006.ByKey(id).GetValueAsync();

                        return View("SpeciesAssessment2006", redlist2006Assessment);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }

            return BadRequest();
        }

        [Route("[controller]/httpclient")]
        public IActionResult HttpClient()
        {
            return View();
        }
    }
}
