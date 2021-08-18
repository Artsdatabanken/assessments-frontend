namespace Assessments.Mapping.Models.Species
{
    public class SpeciesAssessment2021C2Aii
    {
        /// <summary>
        /// IUCN threshold value for the % of mature individuals in one subpopulation. The percentage is greater than or equal to this figure.
        /// </summary>
        public string ThresholdValue { get; set; } // C2A2PågåendePopulasjonsreduksjonKode

        /// <summary>
        /// The assessor's most likely estimate of the % of mature individuals in one subpopulation.
        /// </summary>
        public string PercentageOneSubpop { get; set; } // C2A2ReproduksjonsdyktigeIndivid

        /// <summary>
        /// The truth value indicates the assessor's confidence in the stated value of most likely % in one subpopulation (C2aiiPercentageOneSubpop). A truth value of 1 indicates 100 % confidence, while 0.5 indicates 50 % confidence etc. 
        /// </summary>
        public string TruthValue { get; set; } // C2A2SannhetsverdiKode
    }
}