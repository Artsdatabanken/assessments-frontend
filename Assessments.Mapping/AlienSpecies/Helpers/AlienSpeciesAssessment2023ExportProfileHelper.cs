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

        internal static string GetArrivedCountryFrom(List<AlienSpeciesAssessment2023ArrivedCountryFrom> arrivedCountryFrom)
        {
            var valueList = new List<string>();
            foreach (var variation in arrivedCountryFrom)
            {
                valueList.Add(variation.DisplayName());
            }
            return string.Join(", ", valueList);
        }
    }
}
