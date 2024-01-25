using System.ComponentModel.DataAnnotations;
using Assessments.Shared.Resources.Enums.AlienSpecies;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023EvaluationContext
    {
        [Display(Name = nameof(AlienSpeciesAssessment2023EvaluationContextResource.mainland_ocean_Norway), ResourceType = typeof(AlienSpeciesAssessment2023EvaluationContextResource))]
        N,

        [Display(Name = nameof(AlienSpeciesAssessment2023EvaluationContextResource.Svalbard), ResourceType = typeof(AlienSpeciesAssessment2023EvaluationContextResource))]
        S
    }
}