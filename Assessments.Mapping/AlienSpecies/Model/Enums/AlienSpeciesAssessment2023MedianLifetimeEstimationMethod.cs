using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023MedianLifetimeEstimationMethod
    {
        [Display(Name = "Forenklet anslag")]
        LifespanA1aSimplifiedEstimate,

        [Display(Name = "Numerisk estimering")]
        SpreadRscriptEstimatedSpeciesLongevity,

        [Display(Name = "Levedyktighetsanalyse")]
        ViableAnalysis,

        [Display(Name = "")]
        NotRelevant
    }
}