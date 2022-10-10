namespace Assessments.Mapping.RedlistSpecies
{
    public class SpeciesAssessment2021B1
    {
        /// <summary>
        /// Preliminary category that just the extent of occurence (EOO) on B1 represents 		
        /// </summary>
        public string PreliminaryCategory { get; set; } // B1UtbredelsesområdeKode

        public SpeciesAssessment2021MinMaxProbableIntervall Statistics { get; set; } = new(); // B1IntervallUtbredelsesområde
    }
}