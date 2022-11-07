namespace Assessments.Mapping.AlienSpecies.Helpers
{
    internal static class AlienSpeciesAssessment2023ExportProfileHelper
    {
        internal static string GetGeographicalVariation(string[] geoVar)
        {
            return string.Join(",", geoVar);
        }
    }
}