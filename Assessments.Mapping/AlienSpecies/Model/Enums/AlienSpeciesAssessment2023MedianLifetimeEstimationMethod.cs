using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023MedianLifetimeEstimationMethod
    {
        [Display(Name = "Forenklet anslag")]
        SimplifiedEstimation,

        [Display(Name = "Numerisk estimering")]
        NumericalEstimation,

        [Display(Name = "Levedyktighetsanalyse")]
        ViableAnalysis,

        [Display(Name = "")]
        NotRelevant
    }
}