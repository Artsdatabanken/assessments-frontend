namespace Assessments.Mapping.RedlistSpecies
{
    /// <summary>
    /// Species' occurrence in counties/regions.
    /// </summary>
    public class SpeciesAssessment2021RegionOccurrence
    {
        /// <summary>
        /// Predefined regions (for the most part corresponding to existing counties) and oceans within the assessment area
        /// </summary>
        public string Fylke { get; set; } // TODO: english

        /// <summary>
        /// Detailed presence or absence within a region or ocean. Codes: 0 = …
        /// </summary>
        public int State { get; set; }

        // TODO add region? https://github.com/Artsdatabanken/Rodliste2019/blob/4918668043d7d5b2e5978e29e5028bc68fd1a643/Prod.LoadingCSharp/TransformRodliste2019toDatabankRL2021.cs#L18
    }
}