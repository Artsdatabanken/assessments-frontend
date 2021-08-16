namespace Assessments.Mapping.Models.Species
{
    public class SpeciesAssessment2021BAii
    {
        /// <summary>
        /// Preliminary category that just the number of locations on Ba(ii) represents
        /// </summary>
        public string PreliminaryCategory { get; set; } // BA2FåLokaliteterKode

        public string Quantile { get; set; } // BA2FåLokaliteterProdukt

        public SpeciesAssessment2021MinMaxProbableIntervall Statistics { get; set; } = new(); // BaIntervallAntallLokaliteter
    }
}