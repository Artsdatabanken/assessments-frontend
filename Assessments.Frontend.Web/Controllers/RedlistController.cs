using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Frontend.Web.Models;
using Assessments.Mapping.Models.Species;
using Newtonsoft.Json.Linq;
using X.PagedList;
using System;
// ReSharper disable InconsistentNaming

namespace Assessments.Frontend.Web.Controllers
{
    [Route("species")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class RedlistController : BaseController<RedlistController>
    {
        private static readonly Dictionary<string,JObject> _resourceCache = new Dictionary<string, JObject>();
        public IActionResult Index() => View();

        [Route("2021")]
        public async Task<IActionResult> Index2021(int? page, string name, bool export, bool RE, bool CR, bool EN, bool VU, 
        bool NT, bool DD, bool LC, bool NE, bool NA, bool redlisted, bool endangered, bool criteriaA, bool criteriaB, 
        bool criteriaC, bool criteriaD, bool fastland, bool svalbard)
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
                { "N", fastland },
                { "S", svalbard }
            };

            List<string> chosenAreas = Helpers.findSelectedAreas(assessmentAreas);

            if (chosenCategories?.Any() == true)
                query = query.Where(x => !string.IsNullOrEmpty(x.Category) && chosenCategories.Contains(x.Category));

            if (chosenCriterias?.Any() == true)
                query = query.Where(x => !string.IsNullOrEmpty(x.CriteriaSummarized) && x.CriteriaSummarized.IndexOfAny(chosenCriterias) != -1);

            if (chosenAreas?.Any() == true)
                query = query.Where(x => chosenAreas.Contains(x.AssessmentArea));

            ViewBag.speciesgroup = await GetResource("wwwroot/json/speciesgroup.json");

            ViewBag.kriterier = await GetResource("wwwroot/json/kriterier.json");

            ViewBag.habitat = await GetResource("wwwroot/json/habitat.json");

            ViewBag.categories = await GetResource("wwwroot/json/categories.json");

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
                Fastland = fastland,
                Svalbard = svalbard,
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

            ViewBag.kriterier = await GetResource("wwwroot/json/kriterier.json");
            
            ViewBag.glossary = await GetResource("wwwroot/json/glossary.json"); 
            
            ViewBag.categories = await GetResource("wwwroot/json/categories.json");
            
            ViewBag.habitat = await GetResource("wwwroot/json/habitat.json");
            
            ViewBag.speciesgroup = await GetResource("wwwroot/json/speciesgroup.json");

            return View("Assessment/SpeciesAssessment2021", assessment);
        }
        
        [Route("habitat")]
        public async Task<IActionResult> Habitat()
        {
            ViewBag.glossary = await GetResource("wwwroot/json/glossary.json");

            ViewBag.habitat = await GetResource("wwwroot/json/habitat.json");

            return View("Habitat");
        }

        [Route("speciesgroup")]
        public async Task<IActionResult> SpeciesGroup()
        {
            ViewBag.glossary = await GetResource("wwwroot/json/glossary.json");

            ViewBag.speciesgroup = await GetResource("wwwroot/json/speciesgroup.json");

            return View("SpeciesGroup");
        }

        private static void SetupStatisticsViewModel(IList<SpeciesAssessment2021> data, RL2021ViewModel viewModel)
        {
            // CATEGORY
            var categories = data.Where(x => !string.IsNullOrEmpty(x.Category)).GroupBy(x => new
            {
                Category = x.Category[..2] // ignore degrees, ie "VUº = VU"
            }).Select(x => new KeyValuePair<string, int>(x.Key.Category, x.Count()));

            viewModel.Statistics.Categories = categories.ToDictionary(x => x.Key, x => x.Value);

            // Species main HABITAT

            // Fetch all habitat lists, flatten the lists and make it distinct to obtain all currently possible habitat names.
            var habitatNames = data.Select(x => x.MainHabitat).SelectMany(x => x).Distinct().ToList(); 

            // For each of the habitatnames - count each occurence in the main dataset
            var habitatStats = habitatNames.Select(name => new KeyValuePair<string, int>(name, data.Count(x => x.MainHabitat.Contains(name))))
                .ToDictionary(x => x.Key, x => x.Value);
            viewModel.Statistics.Habitat = habitatStats;
            /*
            for (int i = 0; i < habitatNames.Count; ++i)
            {
                Console.WriteLine(habitatNames[i] + ": " + habitatStats[habitatNames[i]].ToString());
            }*/

            // REGION
            var regionNames = data.Select(x => x.RegionOccurrences.Select(x => x.Fylke)).SelectMany(x => x).Distinct().ToList();
            var regionStats = regionNames.Select(name => new KeyValuePair<string, int>(name, data.Select(x => x.RegionOccurrences).SelectMany(x => x).Where(x => x.Fylke == name && (x.State ==0 || x.State==1)).Count()))
                .ToDictionary(x => x.Key, x => x.Value);
            viewModel.Statistics.Region = regionStats;

            viewModel.Statistics.RegionNames = regionNames;




            // CRITERIA

            var criteriaStrings = data.Where(x => !string.IsNullOrEmpty(x.CriteriaSummarized)).Select(x => x.CriteriaSummarized);

            var criteria = new List<string> { "A", "B", "C", "D" }.Select(item => new KeyValuePair<string, int>(item, criteriaStrings.Count(x => x.Contains(item))));

            viewModel.Statistics.Criteria = criteria.ToDictionary(x => x.Key, x => x.Value);
        }

        private static async Task<JObject> GetResource(string resourcePath)
        {
#if (DEBUG == true)
            if (_resourceCache.ContainsKey(resourcePath)) return _resourceCache[resourcePath];
#endif
            var json = await System.IO.File.ReadAllTextAsync(resourcePath);
            var jObject = JObject.Parse(json);
#if (DEBUG == true)
            if (!_resourceCache.ContainsKey(resourcePath)) _resourceCache.Add(resourcePath, jObject);
#endif            
            return jObject;
        }
    }
}
