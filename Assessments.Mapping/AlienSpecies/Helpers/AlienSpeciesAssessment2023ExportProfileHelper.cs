using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Helpers
{
    internal static class AlienSpeciesAssessment2023ExportProfileHelper
    {
        private static Dictionary<string, string> GetGeoVarValues = new Dictionary<string, string>()
        {
            {"reproduksjonLimitedToCertainClimaticZones", "Artens evne til reproduksjon og/eller spredning er begrenset til visse bioklimatiske soner eller seksjoner" },
            {"ecologicalEffectLimitedToCertainClimaticZones","Artens økologiske effekter er begrenset til visse bioklimatiske soner eller seksjoner"},
            {"ecologicalEffectLimitedToCertainNatureTypes","Artens økologiske effekter er begrenset til bestemte naturtyper"},
            {"ecologicalEffectLimitedToIndigenousSpecies  ","Artens økologiske effekt består utelukkende i interaksjoner med stedegne arter som har svært begrenset utbredelse"}
        };

        internal static string GetGeographicalVariation(List<string> geoVar)
        {
            var valueList = new List<string>();
            foreach (string var in geoVar)
            {
                valueList.Add(GetGeoVarValues[var]);
            }
            return string.Join(", ", valueList);
        }
    }
}