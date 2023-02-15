using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Shared.Helpers;
using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Helpers
{
    internal static class AlienSpeciesAssessment2023ExportProfileHelper
    {
        internal static string GetGeographicalVariation(List<AlienSpeciesAssessment2023GeographicalVariation> geoVar)
        {
            var valueList = new List<string>();
            foreach (var variation in geoVar)
            {
                valueList.Add(variation.DisplayName());
            }
            return string.Join(", ", valueList);
        }
    }
}
