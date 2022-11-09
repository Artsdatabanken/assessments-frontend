using Assessments.Frontend.Web.Models;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Web;

namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public static class QueryHelpers
    {
        public static IQueryable<AlienSpeciesAssessment2023> ApplyParameters(AlienSpeciesListParameters parameters, IQueryable<AlienSpeciesAssessment2023> query)
        {
            if (!string.IsNullOrEmpty(parameters.Name))
                query = query.Where(x => x.ScientificName.ToLowerInvariant().Contains(parameters.Name.ToLowerInvariant()));

            if (parameters.Area.Any())
                query = query.Where(x => parameters.Area.ToEnumerable<AlienSpeciesAssessment2023EvaluationContext>().Contains(x.EvaluationContext) && x.AlienSpeciesCategory != AlienSpeciecAssessment2023AlienSpeciesCategory.RegionallyAlien); // remove "regionallyalien" assessments when filtering by evaluation context

            if (parameters.Category.Any())
                query = query.Where(x => parameters.Category.ToEnumerable<AlienSpeciesAssessment2023Category>().Contains(x.Category));

            if (parameters.CategoryChanged.Any())
                query = ApplyCategoryChange(parameters.CategoryChanged, query);

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

        public static string UpdateParameters(HttpRequest request, AlienSpeciesListParameters parameters)
        {
            var queryParams = HttpUtility.ParseQueryString(request.QueryString.ToString());
            var newQueryParams = HttpUtility.ParseQueryString(request.QueryString.ToString());
            var url = request.PathBase.HasValue ? request.PathBase + request.Path : request.Path;
            if (!string.IsNullOrEmpty(parameters.RemoveFilters))
            {
                string[] keepParameters =
                {
                    $"Parameters.{nameof(parameters.IsCheck)}",
                    $"Parameters.{nameof(parameters.Meta)}",
                    $"Parameters.{nameof(parameters.Name)}",
                    $"Parameters.{nameof(parameters.SortBy)}"
                };

                foreach (var item in queryParams)
                {
                    if (!keepParameters.Contains(item))
                        newQueryParams.Remove(item.ToString());
                }

                return $"{url}?{newQueryParams}";
            }

            if (!string.IsNullOrEmpty(parameters.RemoveSearch))
            {
                queryParams.Remove($"Parameters.{nameof(parameters.Name)}");
                queryParams.Remove($"Parameters.{nameof(parameters.RemoveSearch)}");
                return $"{url}?{queryParams}";
            }

            return string.Empty;
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplyCategoryChange(string[] changes, IQueryable<AlienSpeciesAssessment2023> query)
        {
            IQueryable<AlienSpeciesAssessment2023> newQuery = Enumerable.Empty<AlienSpeciesAssessment2023>().AsQueryable();

            foreach (var change in changes)
            {
                // TODO: fill inn more after Cagetory2018 and ReasonForChangeOfCategory is made available in the model
                var assessments = change switch
                {
                    nameof(CategoryChangeEnum.ccvf) => query.Where(x => x.PreviousAssessments.Count == 0),
                    nameof(CategoryChangeEnum.ccsk) => query.Where(x => x.PreviousAssessments.Count > 0),
                    nameof(CategoryChangeEnum.ccre) => query.Where(x => x.PreviousAssessments.Count == 0),
                    nameof(CategoryChangeEnum.ccnk) => query.Where(x => x.PreviousAssessments.Count == 0),
                    nameof(CategoryChangeEnum.ccnt) => query.Where(x => x.PreviousAssessments.Count == 0),
                    nameof(CategoryChangeEnum.ccea) => query.Where(x => x.PreviousAssessments.Count == 0),
                    nameof(CategoryChangeEnum.ccet) => query.Where(x => x.PreviousAssessments.Count == 0),
                    nameof(CategoryChangeEnum.cces) => query.Where(x => x.PreviousAssessments.Count == 0),
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
                    _ => isInt ? query.Where(x => x.ScientificNameRank == result) : null
                };
                if (assessments != null)
                    newQuery = newQuery.Concat(assessments);
            }
            return newQuery.Distinct();
        }
    }
}