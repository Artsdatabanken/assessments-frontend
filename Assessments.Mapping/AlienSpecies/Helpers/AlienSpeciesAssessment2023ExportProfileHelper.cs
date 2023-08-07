using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Shared.Helpers;
using System;
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

        private static long RoundToSignificantDecimals(double? num) //median lifetime can be a larger number than long can handle..
        {
            if (!num.HasValue) return 0;
            long result =
                (num >= 10000000) ? (long)Math.Floor((double)(num / 1000000)) * 1000000 :
                (num >= 1000000) ? (long)Math.Floor((double)(num / 100000)) * 100000 :
                (num >= 100000) ? (long)Math.Floor((double)(num / 10000)) * 10000 :
                (num >= 10000) ? (long)Math.Floor((double)(num / 1000)) * 1000 :
                (num >= 1000) ? (long)Math.Floor((double)(num / 100)) * 100 :
                (num >= 100) ? (long)Math.Floor((double)(num / 10)) * 10 :
                (long)num.Value;
            return result;
        }

        internal static long GetMedianLifespan(AlienSpeciesAssessment2023MedianLifetimeEstimationMethod estimationMethod, long medianLifeSpanNumerical, int criterionAScore)
        {
            bool isSimplifiedEstimation = estimationMethod == AlienSpeciesAssessment2023MedianLifetimeEstimationMethod.SimplifiedEstimation;
            if (isSimplifiedEstimation)
            {
                return criterionAScore switch
                {
                    1 => 3,
                    2 => 25,
                    3 => 200,
                    4 => 2000,
                    _ => 0
                };
            }

            return RoundToSignificantDecimals(medianLifeSpanNumerical);
        }
    }
}
