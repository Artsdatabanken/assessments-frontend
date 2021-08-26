namespace Assessments.Mapping.Models.Species
{
    public class SpeciesAssessment2021B2
    {
        /// <summary>
        /// Preliminary category that just the area of occupancy (AOO) on B2 represents
        /// </summary>
        public string PreliminaryCategory { get; set; } // B2ForekomstarealKode

        public SpeciesAssessment2021MinMaxProbableIntervall Statistics { get; set; } = new(); // B2IntervallForekomstareal
    }
}