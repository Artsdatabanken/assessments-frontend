using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Artsdatabanken;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Frontend.Web.Models;
using Microsoft.Extensions.Logging;
using X.PagedList;
using System.Collections.Generic;

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

        public IActionResult Index()
        {
            var viewModel = new TestViewModel
            {
                
            };

            return View(viewModel);
        }

        [Route("2021")]
        public IActionResult Index2021(int? page, string name)
        {
            // Pageination
            const int pageSize = 25;
            var pageNumber = page ?? 1;

            // Filter
            IQueryable<RL2021> query = _assessmentApi.Redlist2021;
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.VurdertVitenskapeligNavn.ToLower().Contains(name.Trim().ToLower()));


            var viewModel = new RL2021ViewModel
            {
                //Redlist2015Results = _assessmentApi.Redlist2015.ToPagedList(pageNumber, pageSize),
                Redlist2021Results = query.ToPagedList(pageNumber, pageSize),
                Name = name
            };

            return View("List2021", viewModel);
        }

        [Route("2015")]
        public IActionResult Index2015(int? page, string name)
        {
            // Pageination
            const int pageSize = 25;
            var pageNumber = page ?? 1;

            // Filter
            IQueryable<Rodliste2015> query = _assessmentApi.Redlist2015;
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.VurdertVitenskapeligNavn.ToLower().Contains(name.Trim().ToLower()));


            var viewModel = new RL2015ViewModel
            {
                //Redlist2015Results = _assessmentApi.Redlist2015.ToPagedList(pageNumber, pageSize),
                Redlist2015Results = query.ToPagedList(pageNumber, pageSize),
                Name = name
            };

            return View("List2015", viewModel);
        }

        [Route("2006")]
        public IActionResult Index2006(int? page, string name)
        {
            // Pageination
            const int pageSize = 25;
            var pageNumber = page ?? 1;

            // Filter
            IQueryable<Redlist2006Assessment> query = _assessmentApi.Redlist2006;

            // TODO: Check if this is the correct field to match
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.LatinskArtsnavn.ToLower().Contains(name.Trim().ToLower()));


            var viewModel = new RL2006ViewModel
            {
                //Redlist2006Results = _assessmentApi.Redlist2006.ToPagedList(pageNumber, pageSize),
                Redlist2006Results = query.ToPagedList(pageNumber, pageSize),
                Name = name
            };

            return View("List2006", viewModel);
        }

        [Route("{id:required}")]
        public async Task<IActionResult> Detail(string id, int year, string vurderingscontext)

        {
            try
            {
                switch (year)
                {
                    case 2021:
                        var RL2021 = await _assessmentApi.Redlist2021.ByKey(Convert.ToInt32(id)).GetValueAsync();
                        string json = System.IO.File.ReadAllText("Views/Test/partials_2021/Kriterier_2021/kriterier.json");
                        var jsondata = Newtonsoft.Json.Linq.JObject.Parse(json);
                        ViewBag.kriterier = jsondata;

                        return View("SpeciesAssessment2021", RL2021);

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

        [Route("httpclient")]
        public IActionResult HttpClient()
        {
            return View();
        }
    }
}
