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
           
            return query;
        }
    }
}
