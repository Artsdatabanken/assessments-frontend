using System.ComponentModel.DataAnnotations;
using Assessments.Shared.Resources.Enums.AlienSpecies;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023ReasonForChangeOfCategory
    {
        [Display(Name = nameof(AlienSpeciesAssessment2023ReasonForChangeOfCategoryResource.NewKnowledge), ResourceType = typeof(AlienSpeciesAssessment2023ReasonForChangeOfCategoryResource))]
        NewKnowledge,

        [Display(Name = nameof(AlienSpeciesAssessment2023ReasonForChangeOfCategoryResource.newInterpretation), ResourceType = typeof(AlienSpeciesAssessment2023ReasonForChangeOfCategoryResource))]
        NewInterpretation,

        [Display(Name = nameof(AlienSpeciesAssessment2023ReasonForChangeOfCategoryResource.changedGuidelines), ResourceType = typeof(AlienSpeciesAssessment2023ReasonForChangeOfCategoryResource))]
        ChangedGuidelines,

        [Display(Name = nameof(AlienSpeciesAssessment2023ReasonForChangeOfCategoryResource.changedGuidelinesInterpretation), ResourceType = typeof(AlienSpeciesAssessment2023ReasonForChangeOfCategoryResource))]
        ChangedGuidelinesInterpretation,

        [Display(Name = nameof(AlienSpeciesAssessment2023ReasonForChangeOfCategoryResource.changedStatus), ResourceType = typeof(AlienSpeciesAssessment2023ReasonForChangeOfCategoryResource))]
        ChangedStatus
    }
}