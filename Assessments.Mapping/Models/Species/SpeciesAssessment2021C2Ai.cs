namespace Assessments.Mapping.Models.Species
{
    public class SpeciesAssessment2021C2Ai
    {
        public SpeciesAssessment2021MinMaxProbable Statistics { get; set; } = new(); // C2A1PågåendePopulasjonsreduksjonAntatt

        /// <summary>
        /// IUCN threshold value for the size of the largest subpopulation (unit: number of mature individuals). The number is smaller than or equal to this figure.
        /// </summary>
        public string ThresholdValue { get; set; } // C2A1PågåendePopulasjonsreduksjonKode
    }
}