namespace Assessments.Mapping.Models.Species
{
    public class SpeciesAssessment2021C1
    {
        public SpeciesAssessment2021MinMaxProbable Statistics { get; set; } = new(); // C1PågåendePopulasjonsreduksjonAntatt

        /// <summary>
        /// IUCN threshold value for the observed, estimated or projected continuing decline (unit: %). The decline is greater than or equal to this figure. Note different time periods for the different % declines.
        /// </summary>
        public string ThresholdValue { get; set; } // C1PågåendePopulasjonsreduksjonKode
    }
}