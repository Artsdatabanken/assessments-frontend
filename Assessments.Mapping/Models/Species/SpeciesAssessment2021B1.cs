namespace Assessments.Mapping.Models.Species
{
    public class SpeciesAssessment2021B1
    {
        public string Quantile { get; set; } // B1BeregnetAreal

        public SpeciesAssessment2021MinMaxProbableIntervall Statistics { get; set; } = new(); // B1IntervallUtbredelsesområde
        
        public string PreliminaryCategory { get; set; } // B1UtbredelsesområdeKode
    }
}