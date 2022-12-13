using Assessments.Frontend.Web.Models;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Shared.Helpers;
using System;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public static class QueryHelpers
    {
        public static IQueryable<AlienSpeciesAssessment2023> ApplyParameters(AlienSpeciesListParameters parameters, IQueryable<AlienSpeciesAssessment2023> query)
        {
            if (!string.IsNullOrEmpty(parameters.Name))
                query = ApplySearch(parameters.Name, query);

            if (parameters.Area.Any())
                query = query.Where(x => parameters.Area.ToEnumerable<AlienSpeciesAssessment2023EvaluationContext>().Contains(x.EvaluationContext) && x.AlienSpeciesCategory != AlienSpeciecAssessment2023AlienSpeciesCategory.RegionallyAlien); // remove "regionallyalien" assessments when filtering by evaluation context

            if (parameters.Category.Any())
                query = query.Where(x => parameters.Category.ToEnumerable<AlienSpeciesAssessment2023Category>().Contains(x.Category));

            if (parameters.EcologicalEffect.Any())
                query = query.Where(x => parameters.EcologicalEffect.Any(y => x.ScoreEcologicalEffect != null && y.Contains(x.ScoreEcologicalEffect.ToString())));

            if (parameters.InvasionPotential.Any())
                query = query.Where(x => parameters.InvasionPotential.Any(y => x.ScoreInvasionPotential != null && y.Contains(x.ScoreInvasionPotential.ToString())));

            if (parameters.CategoryChanged.Any())
                query = ApplyCategoryChange(parameters.CategoryChanged, query);

            if (parameters.DecisiveCriterias.Any())
                query = ApplyDecisiveCriteria(parameters.DecisiveCriterias, query);

            if (parameters.SpeciesStatus.Any())
                query = ApplySpeciesStatus(parameters.SpeciesStatus, query);

            if (parameters.ProductionSpecies.Any())
                query = query.Where(x => parameters.ProductionSpecies.Contains(x.ProductionSpecies.ToString()));

            if (parameters.SpeciesGroups.Any())
                query = query.Where(x => parameters.SpeciesGroups.Any(y => AlienSpeciesHelpers.GetSpeciesGroupByShortName(y) == x.SpeciesGroup));

            if (parameters.TaxonRank.Any())
                query = ApplyTaxonRank(parameters.TaxonRank, query);

            if (string.IsNullOrEmpty(parameters.SortBy) || parameters.SortBy.Equals(nameof(AlienSpeciesAssessment2023.ScientificName), StringComparison.InvariantCultureIgnoreCase))
                query = query.OrderBy(x => x.ScientificName);
            else if (parameters.SortBy.Equals(nameof(AlienSpeciesAssessment2023.VernacularName), StringComparison.InvariantCultureIgnoreCase))
                query = query.OrderBy(x => x.VernacularName);
            else if (parameters.SortBy.Equals(nameof(AlienSpeciesAssessment2023.Category), StringComparison.InvariantCultureIgnoreCase))
                query = query.OrderBy(x => x.Category);

            return query;
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplySearch(string searchString, IQueryable<AlienSpeciesAssessment2023> query)
        {
            var containsSubSpecies = query.Where(x =>
                !string.IsNullOrEmpty(x.VernacularName) &&
                x.VernacularName.ToLowerInvariant().Contains(searchString.ToLowerInvariant())).Select(x => x.ScientificName).ToArray();

            return query.Where(x =>
                x.ScientificName.ToLowerInvariant().Contains(searchString.ToLowerInvariant()) ||
                containsSubSpecies.Any(hit => x.ScientificName.Contains(hit)) || // Search on species also includes sub species
                !string.IsNullOrEmpty(x.VernacularName) &&
                x.VernacularName.ToLowerInvariant().Contains(searchString.ToLowerInvariant()) ||
                x.TaxonHierarcy.ToLowerInvariant().Contains(searchString.ToLowerInvariant()) ||
                x.SpeciesGroup.ToLowerInvariant().Contains(searchString.ToLowerInvariant()));
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplyCategoryChange(string[] changes, IQueryable<AlienSpeciesAssessment2023> query)
        {
            IQueryable<AlienSpeciesAssessment2023> newQuery = Enumerable.Empty<AlienSpeciesAssessment2023>().AsQueryable();
            var changedCriteria = "changedCriteria";
            var changedCriteriaInterpretation = "changedCriteriaInterpretation";
            var changedStatus = "changedStatus";
            var newInformation = "newInformation";
            var newInterpretation = "newInterpretation";
            var realChange = "realChange";

            foreach (var change in changes)
            {
                var assessments = change switch
                {
                    nameof(CategoryChangeEnum.ccvf) => query.Where(x => (x.PreviousAssessments.Count == 0 || x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category == AlienSpeciesAssessment2023Category.NR)) && x.Category != AlienSpeciesAssessment2023Category.NR),
                    nameof(CategoryChangeEnum.ccsk) => query.Where(x => x.PreviousAssessments.Count > 0 && x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category != AlienSpeciesAssessment2023Category.NR && x.Category == y.Category)),
                    nameof(CategoryChangeEnum.ccre) => query.Where(x => x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category != AlienSpeciesAssessment2023Category.NR && x.Category != y.Category && x.ReasonForChangeOfCategory.Contains(realChange))),
                    nameof(CategoryChangeEnum.ccnk) => query.Where(x => x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category != AlienSpeciesAssessment2023Category.NR && x.Category != y.Category && x.ReasonForChangeOfCategory.Contains(newInformation))),
                    nameof(CategoryChangeEnum.ccnt) => query.Where(x => x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category != AlienSpeciesAssessment2023Category.NR && x.Category != y.Category && x.ReasonForChangeOfCategory.Contains(newInterpretation))),
                    nameof(CategoryChangeEnum.ccea) => query.Where(x => x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category != AlienSpeciesAssessment2023Category.NR && x.Category != y.Category && x.ReasonForChangeOfCategory.Contains(changedCriteria))),
                    nameof(CategoryChangeEnum.ccet) => query.Where(x => x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category != AlienSpeciesAssessment2023Category.NR && x.Category != y.Category && x.ReasonForChangeOfCategory.Contains(changedCriteriaInterpretation))),
                    nameof(CategoryChangeEnum.cces) => query.Where(x => x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category != AlienSpeciesAssessment2023Category.NR && x.Category != y.Category && x.ReasonForChangeOfCategory.Contains(changedStatus))),
                    _ => null
                };
                if (assessments != null)
                    newQuery = newQuery.Concat(assessments);
            }
            return newQuery.Distinct();
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplyDecisiveCriteria(string[] criterias, IQueryable<AlienSpeciesAssessment2023> query)
        {
            IQueryable<AlienSpeciesAssessment2023> newQuery = Enumerable.Empty<AlienSpeciesAssessment2023>().AsQueryable();
            foreach (var criteria in criterias)
            {
                var assessments = criteria switch
                {
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcexa) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dcexa.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcexb) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dcexb.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcipab) => query.Where(x => DeciciveCriteria.DecisiveCriteriaEnum.dcipab.DisplayName().Any(y => x.DecisiveCriteria.Contains(y))),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcipc) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dcipc.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dceed) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dceed.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcipe) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dcipe.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dceef) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dceef.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcipg) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dcipg.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dceeh) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dceeh.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcipi) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dcipi.DisplayName())),
                    _ => null
                };
                if (assessments != null)
                    newQuery = newQuery.Concat(assessments);
            }
            return newQuery.Distinct();
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplySpeciesStatus(string[] speciesStatus, IQueryable<AlienSpeciesAssessment2023> query)
        {
            const string doorKnockerShort = "eda";

            return query.Where(x => speciesStatus.Contains(x.SpeciesStatus) ||
                                    (speciesStatus.Contains(doorKnockerShort) && (x.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.DoorKnocker || x.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.EffectWithoutReproduction)));
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplyTaxonRank(string[] taxonFilters, IQueryable<AlienSpeciesAssessment2023> query)
        {
            var newQuery = Enumerable.Empty<AlienSpeciesAssessment2023>().AsQueryable();
            var evaluatedAtAnotherLevel = AlienSpeciecAssessment2023AlienSpeciesCategory.TaxonEvaluatedAtAnotherLevel;

            foreach (var filter in taxonFilters)
            {
                var isInt = int.TryParse(filter, out int result);
                var assessments = filter switch
                {
                    nameof(TaxonRank.TaxonRankEnum.tva) => query.Where(x => x.AlienSpeciesCategory == evaluatedAtAnotherLevel),
                    nameof(TaxonRank.TaxonRankEnum.tvi) => query.Where(x => x.AlienSpeciesCategory != evaluatedAtAnotherLevel),
                    _ => isInt ? query.Where(x => ((int)x.ScientificNameRank) == result) : null
                };
                if (assessments != null)
                    newQuery = newQuery.Concat(assessments);
            }
            return newQuery.Distinct();
        }
    }
}
