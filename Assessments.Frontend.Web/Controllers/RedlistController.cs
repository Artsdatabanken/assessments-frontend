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
        public async Task<IActionResult> Index2021(int? page, string name, bool export, bool RE, bool CR, bool EN, 
        bool VU, bool NT, bool DD, bool LC, bool NE, bool NA, bool Redlisted, bool Endangered, string criteria, string[] assessmentAreas)
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
            List<string> categories = new List<string>{ "RE", "CR", "EN", "VU", "NT", "DD", "LC", "NE", "NA" };
            bool[] categoryBools = { RE, CR, EN, VU, NT, DD, LC, NE, NA };
            List<string> chosenCategories = new List<string>();

            for (var i = 0; i < categories.Count; i++)
            {
                if (categoryBools[i])
                    chosenCategories.Add(categories[i]);
            }

            if (categoryBools.Contains(true))
                query = query.Where(x => !string.IsNullOrEmpty(x.Category) && chosenCategories.Contains(x.Category));

            if (!string.IsNullOrEmpty(criteria))
                query = query.Where(x => !string.IsNullOrEmpty(x.CriteriaSummarized) && x.CriteriaSummarized.ToLower().Equals(criteria.Trim().ToLower()));

            if (assessmentAreas?.Any() == true)
                query = query.Where(x => assessmentAreas.Contains(x.AssessmentArea));

            var json_speciesgroup = await System.IO.File.ReadAllTextAsync("wwwroot/json/speciesgroup.json");
            ViewBag.speciesgroup = JObject.Parse(json_speciesgroup);

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
                Redlisted = Redlisted,
                Endangered = Endangered,
                CriteriaSummarized = criteria,
                AssessmentAreas = assessmentAreas
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

            viewModel.Statistics.Categories = categories.ToList();

            var criteriaCategories = new List<string> { "CR", "EN", "VU", "NT " }; // trua og nær trua 

            var criteriaStrings = data.Where(x => x.Category.Length >= 2 && criteriaCategories.Contains(x.Category[..2]))
                .Select(x => x.CriteriaSummarized);

            var criteria = new List<string> { "A", "B", "C", "D" }.Select(item => new KeyValuePair<string, int>(item, criteriaStrings.Count(x => x.Contains(item))));

            viewModel.Statistics.Criteria = criteria.ToList();
        }
    }
}
