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
using Assessments.Frontend.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Http.Extensions;

// ReSharper disable InconsistentNaming

namespace Assessments.Frontend.Web.Controllers
{
    [Route("rodlisteforarter")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class RedlistController : BaseController<RedlistController>
    {
        public IActionResult RodlisteForArter() => View("Species/Rodlisteforarter");

        private static readonly Dictionary<string, JObject> _resourceCache = new Dictionary<string, JObject>();
        private static readonly Dictionary<string, string> _allAreas = Constants.AllAreas;
        private static readonly Dictionary<string, string> _allCriterias = Constants.AllCriterias;
        private static readonly Dictionary<string, string> _allEuropeanPopulationPercentages = Constants.AllEuropeanPopulationPercentages;



        [Route("2021")]
        public async Task<IActionResult> Index2021([FromQueryAttribute] RL2021ViewModel viewModel, int? page, bool export)
        {
            viewModel ??= new RL2021ViewModel();

            ViewBag.glossary = await GetResource("wwwroot/json/glossary.json");

            ViewBag.speciesgroup = await GetResource("wwwroot/json/speciesgroup.json");

            ViewBag.kriterier = await GetResource("wwwroot/json/kriterier.json");

            ViewBag.habitat = await GetResource("wwwroot/json/habitat.json");

            ViewBag.categories = await GetResource("wwwroot/json/categories.json");


            // Pagination
            const int pageSize = 25;
            var pageNumber = page ?? 1;

            var query = await DataRepository.GetMappedSpeciesAssessments(); // transformer modellen 

            ViewBag.AllTaxonRanks = Helpers.getAllTaxonRanks(query.Select(x => x.TaxonRank).Distinct().ToArray());

            // Søk
            string name = String.Empty;

            if (!string.IsNullOrEmpty(viewModel.Name))
            {
                name = viewModel.Name.Trim().ToLower();
                string[] speciesHitScientificNames = query.Where(x => x.PopularName.ToLower().Contains(name)).Select(x => x.ScientificName).ToArray();

                query = query.Where(x => 
                    x.ScientificName.ToLower().Contains(name) ||                            // Match on scientific name.
                    speciesHitScientificNames.Any(hit => x.ScientificName.Contains(hit)) || // Search on species also finds supspecies.
                    x.PopularName.ToLower().Contains(name) ||                               // Match on popular name.
                    x.VurdertVitenskapeligNavnHierarki.ToLower().Contains(name) ||          // Match on taxonomic path.
                    x.SpeciesGroup.ToLower().Contains(name));                               // Match on species group.
            }

            // Filter

            // Areas
            ViewBag.AllAreas = _allAreas;

            if (viewModel.Area?.Any() == true)
                query = query.Where(x => viewModel.Area.Contains(x.AssessmentArea));

            // Categories
            viewModel.Category = Helpers.findSelectedCategories( viewModel.Redlisted, viewModel.Endangered, viewModel.Category);

            if (viewModel.Category?.Any() == true)
                query = query.Where(x => !string.IsNullOrEmpty(x.Category) && viewModel.Category.Any(y => x.Category.Contains(y)));

            // Criterias
            ViewBag.AllCriterias = _allCriterias;

            if (viewModel.Criterias?.Any() == true)
                query = query.Where(x => !string.IsNullOrEmpty(x.CriteriaSummarized) && viewModel.Criterias.Any(y => x.CriteriaSummarized.Contains(y)));

            // Habitat
            if (viewModel.Habitats?.Any() == true)
                query = query.Where(x => viewModel.Habitats.Any(y => x.MainHabitat.Contains(y)));

            // Regions
            ViewBag.AllRegions = Helpers.getRegionsDict();
            string[] chosenRegions = Helpers.findSelectedRegions(viewModel.Regions, ViewBag.AllRegions);

            if (chosenRegions?.Any() == true)
                query = query.Where(x => x.RegionOccurrences.Any(y => y.State == 0 && chosenRegions.Contains(y.Fylke)));

            // SpeciesGroups
            ViewBag.AllSpeciesGroups = Helpers.getAllSpeciesGroups(ViewBag.speciesgroup.ToObject<Dictionary<string, Dictionary<string, string>>>());
            ViewBag.AllInsects = Constants.AllInsects;

            if (viewModel.SpeciesGroups?.Any() == true)
            {
                if (viewModel.SpeciesGroups.Contains("Insekter"))
                    viewModel.SpeciesGroups = Helpers.getSelectedSpeciesGroups(viewModel.SpeciesGroups.ToList());
                    
                query = query.Where(x => !string.IsNullOrEmpty(x.SpeciesGroup) && viewModel.SpeciesGroups.Contains(x.SpeciesGroup));
            }

            // TaxonRank
            if (viewModel.TaxonRank?.Any() == true)
                query = query.Where(x => viewModel.TaxonRank.Contains(x.TaxonRank));

            // European population percentages
            ViewBag.AllEuroPop = _allEuropeanPopulationPercentages;
            string[] chosenEuropeanPopulation = Helpers.findEuropeanPopProcentages(viewModel.EuroPop);

            if (chosenEuropeanPopulation?.Any() == true)
                query = query.Where(x => !string.IsNullOrEmpty(x.PercentageEuropeanPopulation) && chosenEuropeanPopulation.Contains(x.PercentageEuropeanPopulation));

            // Extinct
            if (viewModel.PresumedExtinct)
                query = query.Where(x => x.PresumedExtinct);

            // Sort
            if (!string.IsNullOrEmpty(viewModel.Name) || !string.IsNullOrEmpty(viewModel.SortBy))
                query = Helpers.sortResults(query, viewModel.Name, viewModel.SortBy);

            if (export)
            {
                var assessmentsForExport = Mapper.Map<IEnumerable<SpeciesAssessment2021Export>>(query.ToList());
                var expertCommitteeMembers = await DataRepository.GetData<ExpertCommitteeMember>(Constants.Filename.SpeciesExpertCommitteeMembers);
                expertCommitteeMembers = expertCommitteeMembers.Where(x => x.Year == 2021);

                return new FileStreamResult(ExportHelper.GenerateSpeciesAssessment2021Export(assessmentsForExport, expertCommitteeMembers.ToList(), Request.GetDisplayUrl()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "rødliste-2021.xlsx"
                };
            }

            viewModel.Redlist2021Results = query.ToPagedList(pageNumber, pageSize);

            SetupStatisticsViewModel(query.ToList(), viewModel);

            return View("Species/2021/List/List", viewModel);
        }

        [Route("{id:required}")]
        public async Task<IActionResult> Detail(int id)
        {
            var data = await DataRepository.GetMappedSpeciesAssessments(); // transformer modellen 

            var assessment = data.FirstOrDefault(x => x.Id == id);

            if (assessment == null)
                return NotFound();

            ViewBag.kriterier = await GetResource("wwwroot/json/kriterier.json");
            
            ViewBag.glossary = await GetResource("wwwroot/json/glossary.json"); 
            
            ViewBag.categories = await GetResource("wwwroot/json/categories.json");
            
            ViewBag.habitat = await GetResource("wwwroot/json/habitat.json");

            ViewBag.speciesgroup = await GetResource("wwwroot/json/speciesgroup.json");

            ViewBag.impactfactors = await GetResource("wwwroot/json/impactfactors.json");

            return View("Species/2021/Assessment/SpeciesAssessment2021", assessment);
        }

        private static void SetupStatisticsViewModel(IList<SpeciesAssessment2021> data, RL2021ViewModel viewModel)
        {

            // STATISTICS.
            // INPUT dataset is an already filtered list, based on active filters in the view. 
            string[] relevantCategories = new string[]{"CR", "EN", "VU", "NT"};

            // CATEGORY
            var categories = data.Where(x => !string.IsNullOrEmpty(x.Category)).GroupBy(x => new
            {
                Category = x.Category[..2] // ignore degrees, ie "VUº = VU"
            }).Select(x => new KeyValuePair<string, int>(x.Key.Category, x.Count()));

            viewModel.Statistics.Categories = categories.ToDictionary(x => x.Key, x => x.Value);



            // For the following statistics, the active input should be filtered by only redlisted assessments. 
            // This needs to be re-inforced in the frontend-solution



            // SPECIES MAIN HABITAT

            // Fetch all habitat lists, flatten the lists and make it distinct to obtain all currently possible habitat names.
            var habitatNames = data
                .Where(x => relevantCategories.Contains(x.Category.Substring(0,2)))
                .Select(x => x.MainHabitat)
                .SelectMany(x => x)
                .Distinct()
                .ToList(); 

            // For each of the habitatnames - count each occurence in the main dataset
            var habitatStats = habitatNames.Select(name => new KeyValuePair<string, int>(name, data.Count(x => x.MainHabitat.Contains(name))))
                .ToDictionary(x => x.Key, x => x.Value);
            viewModel.Statistics.Habitat = habitatStats;


            // REGION
            var regionNames = Helpers.SortedRegions();
            var regionStats = regionNames.Select(name => new KeyValuePair<string, int>(name, data
                .Where(x => relevantCategories.Contains(x.Category.Substring(0, 2)))
                .Select(x => x.RegionOccurrences)
                .SelectMany(x => x)
                .Where(x => x.Fylke == name && x.State ==0).Count()))
                .ToDictionary(x => x.Key, x => x.Value);
            viewModel.Statistics.Region = regionStats;

            viewModel.Statistics.RegionNames = regionNames;




            // CRITERIA

            var criteriaStrings = data
                .Where(x => !string.IsNullOrEmpty(x.CriteriaSummarized) && relevantCategories.Contains(x.Category.Substring(0, 2)))
                .Select(x => x.CriteriaSummarized);
            var criteria = new List<string> { "A", "B", "C", "D" }.Select(item => new KeyValuePair<string, int>(item, criteriaStrings.Count(x => x.Contains(item))));
            viewModel.Statistics.Criteria = criteria.ToDictionary(x => x.Key, x => x.Value);

            //Example on how to print out while working
            /*
            for (int i = 0; i < habitatNames.Count; ++i)
            {
                Console.WriteLine(habitatNames[i] + ": " + habitatStats[habitatNames[i]].ToString());
            }
            */



            // IMPACTFACTORS

            string excludedGroupingFactor = "Ingen trussel";
            string excludedPopulationScope = "En ubetydelig del av populasjonen påvirkes";
            string excludedSeverity = "Ubetydelig/ingen nedgang";

            var impactFactors = data
                .Where(x => relevantCategories.Contains(x.Category.Substring(0, 2)))
                .Select(x => x.ImpactFactors
                    .Where(x => x.GroupingFactor != excludedGroupingFactor &&
                        x.PopulationScope != excludedPopulationScope &&
                        x.Severity != excludedSeverity)
                    .Select(x => x.GroupingFactor)
                    .Distinct())
                .SelectMany(x => x)
                .GroupBy((x => x), (key, value) => new
                {
                    key = key,
                    value = value.Count()
                });

            viewModel.Statistics.ImpactFactors = new Dictionary<string, int>();
            
            foreach (var item in impactFactors)
            {
                viewModel.Statistics.ImpactFactors.Add(item.key, item.value);
            }
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
