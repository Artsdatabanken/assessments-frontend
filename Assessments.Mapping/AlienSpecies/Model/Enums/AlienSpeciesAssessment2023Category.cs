using System.ComponentModel.DataAnnotations;
using Assessments.Shared.Resources.Enums.AlienSpecies;

namespace Assessments.Mapping.AlienSpecies.Model.Enums;

// ReSharper disable InconsistentNaming
public enum AlienSpeciesAssessment2023Category
{
    [Display(Name = nameof(AlienSpeciesAssessment2023CategoryResource.SE), ResourceType = typeof(AlienSpeciesAssessment2023CategoryResource))] 
    SE,

    [Display(Name = nameof(AlienSpeciesAssessment2023CategoryResource.HI), ResourceType = typeof(AlienSpeciesAssessment2023CategoryResource))]
    HI,

    [Display(Name = nameof(AlienSpeciesAssessment2023CategoryResource.PH), ResourceType = typeof(AlienSpeciesAssessment2023CategoryResource))]
    PH,

    [Display(Name = nameof(AlienSpeciesAssessment2023CategoryResource.LO), ResourceType = typeof(AlienSpeciesAssessment2023CategoryResource))]
    LO,

    [Display(Name = nameof(AlienSpeciesAssessment2023CategoryResource.NK), ResourceType = typeof(AlienSpeciesAssessment2023CategoryResource))]
    NK,

    [Display(Name = nameof(AlienSpeciesAssessment2023CategoryResource.NR), ResourceType = typeof(AlienSpeciesAssessment2023CategoryResource))]
    NR
}