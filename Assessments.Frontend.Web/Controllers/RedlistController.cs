using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Frontend.Web.Models;
using Assessments.Mapping.Models.Species;
using Newtonsoft.Json.Linq;
using X.PagedList;
// ReSharper disable InconsistentNaming

namespace Assessments.Frontend.Web.Controllers
{
    [Route("species")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class RedlistController : BaseController<RedlistController>
    {
        public IActionResult Index() => View();

        [Route("2021")]
        public async Task<IActionResult> Index2021(int? page, string name, bool export, bool RE, bool CR, bool EN, bool VU, 
        bool NT, bool DD, bool LC, bool NE, bool NA, bool redlisted, bool endangered, bool criteriaA, bool criteriaB, 
        bool criteriaC, bool criteriaD, bool Norge, bool svalbard, bool presumedExtinct)
        {
            // Pagination
            const int pageSize = 25;
            var pageNumber = page ?? 1;

            // var query = await DataRepository.GetData<Mapping.Models.Species.SpeciesAssessment2021>(Constants.Filename.Species2021);
            var query = await DataRepository.GetMappedSpeciesAssessments(); // transformer modellen 

            // Søk
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.ScientificName.ToLower().Contains(name.Trim().ToLower()));

            // Filter
            Dictionary<string, bool> categories = new Dictionary<string, bool>
            {
                { Constants.SpeciesCategories.Extinct.ShortHand, RE },
                { Constants.SpeciesCategories.CriticallyEndangered.ShortHand, CR },
                { Constants.SpeciesCategories.Endangered.ShortHand, EN },
                { Constants.SpeciesCategories.Vulnerable.ShortHand, VU },
                { Constants.SpeciesCategories.NearThreatened.ShortHand, NT },
                { Constants.SpeciesCategories.DataDeficient.ShortHand, DD },
                { Constants.SpeciesCategories.Viable.ShortHand, LC },
                { Constants.SpeciesCategories.NotEvalueted.ShortHand, NE },
                { Constants.SpeciesCategories.NotAppropriate.ShortHand, NA }
            };
            List<string> chosenCategories = Helpers.findSelectedCategories(categories, redlisted, endangered);

            Dictionary<char, bool> criterias = new Dictionary<char, bool>
            {
                { 'A', criteriaA },
                { 'B', criteriaB },
                { 'C', criteriaC },
                { 'D', criteriaD },
            };

            char[] chosenCriterias = Helpers.findSelectedCriterias(criterias);

            Dictionary<string, bool> assessmentAreas = new Dictionary<string, bool>
            {
                { "N", Norge },
                { "S", svalbard }
            };

            List<string> chosenAreas = Helpers.findSelectedAreas(assessmentAreas);

            if (chosenCategories?.Any() == true)
                query = query.Where(x => !string.IsNullOrEmpty(x.Category) && chosenCategories.Contains(x.Category));

            if (chosenCriterias?.Any() == true)
                query = query.Where(x => !string.IsNullOrEmpty(x.CriteriaSummarized) && x.CriteriaSummarized.IndexOfAny(chosenCriterias) != -1);

            if (chosenAreas?.Any() == true)
                query = query.Where(x => chosenAreas.Contains(x.AssessmentArea));

            if (presumedExtinct)
                query = query.Where(x => x.PresumedExtinct);

            var json_speciesgroup = await System.IO.File.ReadAllTextAsync("wwwroot/json/speciesgroup.json");
            ViewBag.speciesgroup = JObject.Parse(json_speciesgroup);

            var json_categories = await System.IO.File.ReadAllTextAsync("wwwroot/json/categories.json");
            ViewBag.categories = JObject.Parse(json_categories);

            if (export)
            {
                var assessmentsForExport = Mapper.Map<IEnumerable<SpeciesAssessment2021Export>>(query.ToList());

                return new FileStreamResult(Helpers.GenerateExcel(assessmentsForExport), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "rødliste-2021.xlsx"
                };
            }

            var viewModel = new RL2021ViewModel
            {
                Redlist2021Results = query.ToPagedList(pageNumber, pageSize),
                Name = name,
                RE = RE,
                CR = CR,
                EN = EN,
                VU = VU,
                NT = NT,
                DD = DD,
                LC = LC,
                NE = NE,
                NA = NA,
                Redlisted = redlisted,
                Endangered = endangered,
                CriteriaA = criteriaA,
                CriteriaB = criteriaB,
                CriteriaC = criteriaC,
                CriteriaD = criteriaD,
                Norge = Norge,
                Svalbard = svalbard,
                PresumedExtinct = presumedExtinct,
            };

            SetupStatisticsViewModel(query.ToList(), viewModel);

            return View("List/List2021", viewModel);
        }

        [Route("{id:required}")]
        public async Task<IActionResult> Detail(int id)
        {
            //var data = await DataRepository.GetData<Mapping.Models.Species.SpeciesAssessment2021>(Constants.Filename.Species2021);
            var data = await DataRepository.GetMappedSpeciesAssessments(); // transformer modellen 

            var assessment = data.FirstOrDefault(x => x.Id == id);

            if (assessment == null)
                return NotFound();

            var json_kriterier = await System.IO.File.ReadAllTextAsync("wwwroot/json/kriterier.json");
            ViewBag.kriterier = JObject.Parse(json_kriterier);

            var json_glossary = await System.IO.File.ReadAllTextAsync("wwwroot/json/glossary.json");
            ViewBag.glossary = JObject.Parse(json_glossary);

            var json_categories = await System.IO.File.ReadAllTextAsync("wwwroot/json/categories.json");
            ViewBag.categories = JObject.Parse(json_categories);

            var json_habitat = await System.IO.File.ReadAllTextAsync("wwwroot/json/habitat.json");
            ViewBag.habitat = JObject.Parse(json_habitat);

            var json_speciesgroup = await System.IO.File.ReadAllTextAsync("wwwroot/json/speciesgroup.json");
            ViewBag.speciesgroup = JObject.Parse(json_speciesgroup);

            return View("Assessment/SpeciesAssessment2021", assessment);
        }

        [Route("habitat")]
        public async Task<IActionResult> Habitat()
        {
            var json_glossary = System.IO.File.ReadAllText("wwwroot/json/glossary.json");
            ViewBag.glossary = JObject.Parse(json_glossary);

            var json_habitat = System.IO.File.ReadAllText("wwwroot/json/habitat.json");
            ViewBag.habitat = JObject.Parse(json_habitat);
            return View("Habitat");
        }

        [Route("speciesgroup")]
        public async Task<IActionResult> SpeciesGroup()
        {
            var json_glossary = System.IO.File.ReadAllText("wwwroot/json/glossary.json");
            ViewBag.glossary = JObject.Parse(json_glossary);

            var json_speciesgroup = System.IO.File.ReadAllText("wwwroot/json/speciesgroup.json");
            ViewBag.speciesgroup = JObject.Parse(json_speciesgroup);
            return View("SpeciesGroup");
        }

        private static void SetupStatisticsViewModel(IList<SpeciesAssessment2021> data, RL2021ViewModel viewModel)
        {
            var categories = data.Where(x => !string.IsNullOrEmpty(x.Category)).GroupBy(x => new
            {
                Category = x.Category[..2] // ignore degrees, ie "VUº = VU"
            }).Select(x => new KeyValuePair<string, int>(x.Key.Category, x.Count()));

            viewModel.Statistics.Categories = categories.ToDictionary(x => x.Key, x => x.Value);


            var criteriaCategories = new List<string> { "CR", "EN", "VU", "NT " }; // trua og nær trua 

            var criteriaStrings = data.Where(x => x.Category.Length >= 2 && criteriaCategories.Contains(x.Category[..2]))
                .Select(x => x.CriteriaSummarized);

            var criteria = new List<string> { "A", "B", "C", "D" }.Select(item => new KeyValuePair<string, int>(item, criteriaStrings.Count(x => x.Contains(item))));

            viewModel.Statistics.Criteria = criteria.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
