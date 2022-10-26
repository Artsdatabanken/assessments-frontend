using System;
using System.Linq;
using Assessments.Frontend.Web.Models;
using Assessments.Mapping.AlienSpecies;

namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public static class QueryHelpers
    {
        public static IQueryable<AlienSpeciesAssessment2023> ApplyParameters(AlienSpeciesListParameters parameters, IQueryable<AlienSpeciesAssessment2023> query)
        {
            if (!string.IsNullOrEmpty(parameters.Name))
                query = query.Where(x => x.ScientificName.ToLowerInvariant()
                    .Contains(parameters.Name.ToLowerInvariant()));

            if (string.IsNullOrEmpty(parameters.SortBy) || parameters.SortBy.Equals(nameof(AlienSpeciesAssessment2023.ScientificName), StringComparison.InvariantCultureIgnoreCase))
            {
                query = query.OrderBy(x => x.ScientificName);
            }
            else if (parameters.SortBy.Equals(nameof(AlienSpeciesAssessment2023.VernacularName), StringComparison.InvariantCultureIgnoreCase))
            {
                query = query.OrderBy(x => x.VernacularName);
            }
            else if (parameters.SortBy.Equals(nameof(AlienSpeciesAssessment2023.Category), StringComparison.InvariantCultureIgnoreCase))
            {
                query = query.OrderBy(x => x.Category);
            }
           
            return query;
        }

        public static AlienSpeciesListParameters UpdateParameters(AlienSpeciesListParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.RemoveFilters))
            {
                parameters = new AlienSpeciesListParameters(parameters.IsCheck, parameters.Meta, parameters.Name);
            }
            return parameters;
        }
    }
}
