namespace Assessments.Mapping.Models.Species
{
    public class SpeciesAssessment2021C
    {
        public SpeciesAssessment2021MinMaxProbableIntervall Statistics { get; set; } = new(); // CPopulasjonsstørrelseAntatt

        /// <summary>
        /// Preliminary category that just the number of mature individuals on the C-criterion represents. 
        /// </summary>
        public string PreliminaryCategory { get; set; } // CPopulasjonsstørrelseKode
        
        /// <summary>
        /// Typical number of substrate units per location. Used for calculating the estimated number of mature individuals. 
        /// </summary>
        public string SubstrateUnitsPerLocation { get; set; } // CSubstratenheter
    }
}