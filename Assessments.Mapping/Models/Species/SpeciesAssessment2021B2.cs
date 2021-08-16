namespace Assessments.Mapping.Models.Species
{
    public class SpeciesAssessment2021B2
    {
        /// <summary>
        /// Calculated area of occupancy (AOO) based on at least a given minimum and maximum AOO using a 0.3 quantile and linear interpolation 
        /// </summary>
        public string Quantile { get; set; } // B2BeregnetAreal

        /// <summary>
        /// Preliminary category that just the area of occupancy (AOO) on  B2 represents
        /// </summary>
        public string PreliminaryCategory { get; set; } // B2ForekomstarealKode

        public SpeciesAssessment2021MinMaxProbableIntervall Statistics { get; set; } = new(); // B2IntervallForekomstareal
    }
}