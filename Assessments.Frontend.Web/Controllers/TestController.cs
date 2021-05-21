using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Artsdatabanken;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Frontend.Web.Models;
using Microsoft.Extensions.Logging;
using X.PagedList;

namespace Assessments.Frontend.Web.Controllers
{
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly AssessmentApiService _assessmentApi;
        private readonly ILogger<TestController> _logger;

        public TestController(AssessmentApiService assessmentApi, ILogger<TestController> logger)
        {
            _logger = logger;
            _assessmentApi = assessmentApi;
        }

        public IActionResult Index(int? page, string name)
        {
            const int pageSize = 25;
            var pageNumber = page ?? 1;

            IQueryable<Rodliste2015> query = _assessmentApi.Redlist2015;

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.VurdertVitenskapeligNavn.ToLower().Contains(name.Trim().ToLower()));

            var viewModel = new TestViewModel
            {
                Redlist2015Results = query.ToPagedList(pageNumber, pageSize),
                Name = name
            };

            return View(viewModel);
        }

        [Route("{id:required}")]
        public async Task<IActionResult> Detail(string id, int year, string vurderingscontext)
        {
            try
            {
                switch (year)
                {
                    case 2015:

                        var rodliste2015 = await _assessmentApi.Redlist2015.ByKey(Convert.ToInt32(id), vurderingscontext).GetValueAsync();

                        return View("Detail2015", rodliste2015);
                    
                    case 2006:
                        
                        var redlist2006Assessment = await _assessmentApi.Redlist2006.ByKey(id).GetValueAsync();

                        return View("Detail2006", redlist2006Assessment);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }

            return BadRequest();
        }

        [Route("httpclient")]
        public IActionResult HttpClient()
        {
            return View();
        }
    }
}
