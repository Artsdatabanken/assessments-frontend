using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023ExpansionSpeedSpatioTemporalDatasetModel
    {
        [Display(Name = "")]
        NotRelevant,

        [Display(Name = "Konstant ekspansjon og oppdagbarhet")]
        ConstantDetectability,

        [Display(Name = "Oppdagbarhet endres én gang")]
        ChangeDetectabilityOnce,

        [Display(Name = "Test modell (1) Konstant ekspansjon og oppdagbarhet og (2) Oppdagbarhet endres én gang")]
        TestTwoModels,

        [Display(Name = "Kjent innsamlingsinnsats")]
        KnownSamplingEffort
    }
}