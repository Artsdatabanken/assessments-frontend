using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Frontend.Web.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using X.PagedList;
// ReSharper disable InconsistentNaming

namespace Assessments.Frontend.Web.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class TestController : BaseController<TestController>
    {
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

            var query =
                await DataRepository.GetData<Mapping.Models.Species.SpeciesAssessment2021>(Constants.Filename
                    .Species2021);

            // Filter
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.ScientificName.ToLower().Contains(name.Trim().ToLower()));

            var viewModel = new RL2021ViewModel
            {
                Redlist2021Results = query.ToPagedList(pageNumber, pageSize),
                Name = name
            };

            var json_speciesgroup = await System.IO.File.ReadAllTextAsync("Views/Test/partials_2021/speciesgroup.json");
            ViewBag.speciesgroup = JObject.Parse(json_speciesgroup);

            return View("List2021", viewModel);
        }

        [Route("2015")]
        public async Task<IActionResult> Index2015(int? page, string name)
        {
            // Pagination
            const int pageSize = 25;
            var pageNumber = page ?? 1;

            var query =
                await DataRepository.GetData<Mapping.Models.Species.Rodliste2015>(Constants.Filename.Species2015);

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

            var query = await DataRepository.GetData<Mapping.Models.Species.Redlist2006Assessment>(Constants.Filename.Species2006);

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

        [Route("{id:required}")]
        public async Task<IActionResult> Detail(string id, int year, string vurderingscontext)
        {
            try
            {
                switch (year)
                {
                    case 2021:

                        var species2021 = await DataRepository.GetData<Mapping.Models.Species.SpeciesAssessment2021>(Constants.Filename.Species2021);
                        var species2021Model = species2021.FirstOrDefault(x => x.Id == Convert.ToInt32(id));

                        var json_kriterier = await System.IO.File.ReadAllTextAsync("Views/Test/partials_2021/Kriterier_2021/kriterier.json");
                        ViewBag.kriterier = JObject.Parse(json_kriterier);

                        var json_glossary = await System.IO.File.ReadAllTextAsync("Views/Shared/glossary.json");
                        ViewBag.glossary = JObject.Parse(json_glossary);

                        var json_habitat = await System.IO.File.ReadAllTextAsync("Views/Test/partials_2021/habitat.json");
                        ViewBag.habitat = JObject.Parse(json_habitat);

                        var json_speciesgroup = await System.IO.File.ReadAllTextAsync("Views/Test/partials_2021/speciesgroup.json");
                        ViewBag.speciesgroup = JObject.Parse(json_speciesgroup);

                        return View("SpeciesAssessment2021", species2021Model);

                    case 2015:

                        var species2015 = await DataRepository.GetData<Mapping.Models.Species.Rodliste2015>(Constants.Filename.Species2015);
                        var species2015Model = species2015.FirstOrDefault(x => x.LatinsknavnId == Convert.ToInt32(id) && x.VurderingsContext == vurderingscontext);

                        return species2015Model != null ? View("SpeciesAssessment2015", species2015Model) : NotFound();

                    case 2006:

                        var species2006 = await DataRepository.GetData<Mapping.Models.Species.Redlist2006Assessment>(Constants.Filename.Species2006);
                        var species2006Model = species2006.FirstOrDefault(x => x.ArtsID == id);

                        return species2006Model != null ? View("SpeciesAssessment2006", species2006Model) : NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught it!");
                Logger.LogError(ex, ex.Message);
                return NotFound();
            }

            return BadRequest();
        }

        [Route("habitat")]
        public IActionResult Habitat()
        {
            var json_glossary = System.IO.File.ReadAllText("Views/Shared/glossary.json");
            ViewBag.glossary = JObject.Parse(json_glossary);

            var json_habitat = System.IO.File.ReadAllText("Views/Test/partials_2021/habitat.json");
            ViewBag.habitat = JObject.Parse(json_habitat);
            return View("Habitat");
        }

        [Route("speciesgroup")]
        public IActionResult SpeciesGroup()
        {
            var json_glossary = System.IO.File.ReadAllText("Views/Shared/glossary.json");
            ViewBag.glossary = JObject.Parse(json_glossary);

            var json_speciesgroup = System.IO.File.ReadAllText("Views/Test/partials_2021/speciesgroup.json");
            ViewBag.speciesgroup = JObject.Parse(json_speciesgroup);
            return View("SpeciesGroup");
        }
    }
}
