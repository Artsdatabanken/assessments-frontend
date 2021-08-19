using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
        private readonly DataRepository _dataRepository;

        public TestController(AssessmentApiService assessmentApi, ILogger<TestController> logger, DataRepository dataRepository)
        {
            _dataRepository = dataRepository;
            _logger = logger;
            _assessmentApi = assessmentApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("2021")]
        public async Task<IActionResult> Index2021(int? page, string name)
        {
            // Pagination
            const int pageSize = 25;
            var pageNumber = page ?? 1;

            var query = await _dataRepository.GetData<Mapping.Models.Species.SpeciesAssessment2021>(Helpers.Filenames.Species2021);

            // Filter
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.ScientificName.ToLower().Contains(name.Trim().ToLower()));

            var viewModel = new RL2021ViewModel
            {
                Redlist2021Results = query.ToPagedList(pageNumber, pageSize),
                Name = name
            };

            string json_speciesgroup = System.IO.File.ReadAllText("Views/Test/partials_2021/speciesgroup.json");
            ViewBag.speciesgroup = Newtonsoft.Json.Linq.JObject.Parse(json_speciesgroup);

            return View("List2021", viewModel);
        }

        [Route("2015")]
        public async Task<IActionResult> Index2015(int? page, string name)
        {
            // Pagination
            const int pageSize = 25;
            var pageNumber = page ?? 1;

            var query = await _dataRepository.GetData<Mapping.Models.Species.Rodliste2015>(Helpers.Filenames.Species2015);

            // Filter
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.VurdertVitenskapeligNavn.ToLower().Contains(name.Trim().ToLower()));

            var viewModel = new RL2015ViewModel
            {
                Redlist2015Results = query.ToPagedList(pageNumber, pageSize),
                Name = name
            };

            return View("List2015", viewModel);
        }

        [Route("2006")]
        public async Task<IActionResult> Index2006(int? page, string name)
        {
            // Pagination
            const int pageSize = 25;
            var pageNumber = page ?? 1;

            var query = await _dataRepository.GetData<Mapping.Models.Species.Redlist2006Assessment>(Helpers.Filenames.Species2006);

            // Filter
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.LatinskArtsnavn.ToLower().Contains(name.Trim().ToLower()));

            var viewModel = new RL2006ViewModel
            {
                Redlist2006Results = query.ToPagedList(pageNumber, pageSize),
                Name = name
            };

            return View("List2006", viewModel);
        }

        [Route("habitat")]
        public IActionResult Habitat()
        {
            string json_glossary = System.IO.File.ReadAllText("Views/Shared/glossary.json");
            ViewBag.glossary = Newtonsoft.Json.Linq.JObject.Parse(json_glossary);

            string json_habitat = System.IO.File.ReadAllText("Views/Test/partials_2021/habitat.json");
            ViewBag.habitat = Newtonsoft.Json.Linq.JObject.Parse(json_habitat);
            return View("Habitat");
        }

        [Route("speciesgroup")]
        public IActionResult SpeciesGroup()
        {
            string json_glossary = System.IO.File.ReadAllText("Views/Shared/glossary.json");
            ViewBag.glossary = Newtonsoft.Json.Linq.JObject.Parse(json_glossary);

            string json_speciesgroup = System.IO.File.ReadAllText("Views/Test/partials_2021/speciesgroup.json");
            ViewBag.speciesgroup = Newtonsoft.Json.Linq.JObject.Parse(json_speciesgroup);
            return View("SpeciesGroup");
        }

        [Route("{id:required}")]
        public async Task<IActionResult> Detail(string id, int year, string vurderingscontext)
        {
            try
            {
                switch (year)
                {
                    case 2021:

                        // TODO: erstatte (og slette) assessmentApi med dataRepository - på samme måte som 2015 og 2006
                        // var species2021 = await _dataRepository.GetData<Mapping.Models.Species.SpeciesAssessment2021>(Helpers.Filenames.Species2021);

                        var RL2021 = await _assessmentApi.Redlist2021.ByKey(Convert.ToInt32(id)).GetValueAsync();

                        string json_kriterier = System.IO.File.ReadAllText("Views/Test/partials_2021/Kriterier_2021/kriterier.json");
                        ViewBag.kriterier = Newtonsoft.Json.Linq.JObject.Parse(json_kriterier);

                        string json_glossary = System.IO.File.ReadAllText("Views/Shared/glossary.json");
                        ViewBag.glossary = Newtonsoft.Json.Linq.JObject.Parse(json_glossary);

                        string json_habitat = System.IO.File.ReadAllText("Views/Test/partials_2021/habitat.json");
                        ViewBag.habitat = Newtonsoft.Json.Linq.JObject.Parse(json_habitat);

                        string json_speciesgroup = System.IO.File.ReadAllText("Views/Test/partials_2021/speciesgroup.json");
                        ViewBag.speciesgroup = Newtonsoft.Json.Linq.JObject.Parse(json_speciesgroup);


                        return View("SpeciesAssessment2021", RL2021);

                    case 2015:

                        var species2015 = await _dataRepository.GetData<Mapping.Models.Species.Rodliste2015>(Helpers.Filenames.Species2015);
                        var species2015Model = species2015.FirstOrDefault(x => x.LatinsknavnId == Convert.ToInt32(id) && x.VurderingsContext == vurderingscontext);

                        return species2015Model != null ? View("SpeciesAssessment2015", species2015Model) : NotFound();

                    case 2006:

                        var species2006 = await _dataRepository.GetData<Mapping.Models.Species.Redlist2006Assessment>(Helpers.Filenames.Species2006);
                        var species2006Model = species2006.FirstOrDefault(x => x.ArtsID == id);

                        return species2006Model != null ? View("SpeciesAssessment2006", species2006Model) : NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught it!");
                _logger.LogError(ex, ex.Message);
                return NotFound();
            }

            return BadRequest();
        }
    }
}
