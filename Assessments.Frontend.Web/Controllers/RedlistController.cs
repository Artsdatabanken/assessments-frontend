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

        private static readonly string[] _allCategories = new[]
        {
            Constants.SpeciesCategories.Extinct.ShortHand,
            Constants.SpeciesCategories.CriticallyEndangered.ShortHand,
            Constants.SpeciesCategories.Endangered.ShortHand,
            Constants.SpeciesCategories.Vulnerable.ShortHand,
            Constants.SpeciesCategories.NearThreatened.ShortHand,
            Constants.SpeciesCategories.DataDeficient.ShortHand,
            Constants.SpeciesCategories.Viable.ShortHand,
            Constants.SpeciesCategories.NotEvalueted.ShortHand,
            Constants.SpeciesCategories.NotAppropriate.ShortHand
        };
        public IActionResult Index() => View();

        [Route("2021")]
        public async Task<IActionResult> Index2021([FromQueryAttribute] RL2021ViewModel viewModel, int? page, bool export)
        {
            viewModel ??= new RL2021ViewModel();
            // Pagination
            const int pageSize = 25;
            var pageNumber = page ?? 1;

            // var query = await DataRepository.GetData<Mapping.Models.Species.SpeciesAssessment2021>(Constants.Filename.Species2021);
            var query = await DataRepository.GetMappedSpeciesAssessments(); // transformer modellen 

            // Søk
            if (!string.IsNullOrEmpty(viewModel.Name))
                query = query.Where(x => x.ScientificName.ToLower().Contains(viewModel.Name.Trim().ToLower()));

            // Filter

            // Categories
            
            ViewBag.AllCategories = _allCategories;
            List<string> chosenCategories = Helpers.findSelectedCategories( viewModel.Redlisted, viewModel.Endangered, viewModel.Category);

            // Criterias
            Dictionary<char, bool> criterias = new Dictionary<char, bool>
            {
                { 'A', viewModel.Criterias.CriteriaA },
                { 'B', viewModel.Criterias.CriteriaB },
                { 'C', viewModel.Criterias.CriteriaC },
                { 'D', viewModel.Criterias.CriteriaD },
            };
            char[] chosenCriterias = Helpers.findSelectedCriterias(criterias);

            // Regions
            Dictionary<string, bool> regions = new Dictionary<string, bool>
            {
                {Constants.Regions.Agder, viewModel.Regions.Agder},
                {Constants.Regions.Innlandet, viewModel.Regions.Innlandet},
                {Constants.Regions.VestfoldTelemark, viewModel.Regions.VestFoldTelemark},
                {Constants.Regions.MoreRomsdal, viewModel.Regions.MoreRomsdal},
                {Constants.Regions.Nordland, viewModel.Regions.Nordland},
                {Constants.Regions.Rogaland, viewModel.Regions.Rogaland},
                {Constants.Regions.TromsFinnmark, viewModel.Regions.TromsFinnmark},
                {Constants.Regions.Trondelag, viewModel.Regions.Trondelag},
                {Constants.Regions.Vestland, viewModel.Regions.Vestland},
                {Constants.Regions.VikenOslo, viewModel.Regions.VikenOslo},
                {Constants.Regions.Havomraader, viewModel.Regions.Havomroder}
            };
            List<string> chosenRegions = Helpers.findSelectedRegions(regions);

            // European population percentages
            Dictionary<string, bool> europeanPopulation = new Dictionary<string, bool>
            {
                {Constants.EuropeanPopulationPercentages.EuropeanPopLt5, viewModel.EuropeanPopLt5},
                {Constants.EuropeanPopulationPercentages.EuropeanPopRange5To25, viewModel.EuropeanPopRange5To25},
                {Constants.EuropeanPopulationPercentages.EuropeanPopRange25To50, viewModel.EuropeanPopRange25To50},
                {Constants.EuropeanPopulationPercentages.EuropeanPopGt50, viewModel.EuropeanPopGt50}
            };
            List<string> chosenEuropeanPopulation = Helpers.findEuropeanPopProcentages(europeanPopulation);

            if (chosenCategories?.Any() == true)
                query = query.Where(x => !string.IsNullOrEmpty(x.Category) && chosenCategories.Any(y => x.Category.Contains(y)));

            if (chosenCriterias?.Any() == true)
                query = query.Where(x => !string.IsNullOrEmpty(x.CriteriaSummarized) && x.CriteriaSummarized.IndexOfAny(chosenCriterias) != -1);

            if (viewModel.Area?.Any() == true)
                query = query.Where(x => viewModel.Area.Contains(x.AssessmentArea));

            if (chosenRegions?.Any() == true)
                query = query.Where(x => x.RegionOccurrences.Any(y => y.State <= 1 && chosenRegions.Contains(y.Fylke)));

            if (chosenEuropeanPopulation?.Any() == true)
                query = query.Where(x => !string.IsNullOrEmpty(x.PercentageEuropeanPopulation) && chosenEuropeanPopulation.Contains(x.PercentageEuropeanPopulation));

            if (viewModel.PresumedExtinct)
                query = query.Where(x => x.PresumedExtinct);

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

            viewModel.Redlist2021Results = query.ToPagedList(pageNumber, pageSize);

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
