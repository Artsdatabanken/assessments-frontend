using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023ExtinctionProbability
    {
        [Display(Name = "over 97%")]
        High,

        [Display(Name = "mellom 43% og 97%")]
        MediumHigh,

        [Display(Name = "mellom 5% og 43%")]
        MediumLow,

        [Display(Name = "under 5%")]
        Low,

        [Display(Name = "")]
        NotEvaluated
    }
}