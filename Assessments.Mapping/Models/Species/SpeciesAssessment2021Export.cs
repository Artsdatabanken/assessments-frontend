using System.ComponentModel;

namespace Assessments.Mapping.Models.Species
{
    public class SpeciesAssessment2021Export
    {
        [DisplayName("Vurderingsområde")]
        [Description("Er arten vurdert for Norge eller Svalbard")]
        public string AssessmentArea { get; set; }

        [DisplayName("Populærnavn")]
        [Description("Prioritert norsk populærnavn i henhold til Artsnavnebase")]
        public string PopularName { get; set; }
    }
}