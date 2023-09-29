using System.ComponentModel.DataAnnotations;
using Assessments.Shared.Resources.Enums.AlienSpecies;

namespace Assessments.Mapping.AlienSpecies.Model.Enums;

// ReSharper disable InconsistentNaming
public enum AlienSpeciesAssessment2023Category
{
    [Display(Name = nameof(AlienSpeciesAssessment2023CategoryResource.SE), ResourceType = typeof(AlienSpeciesAssessment2023CategoryResource))] 
    SE,

    [Display(Name = "Høy risiko")]
    HI,

    [Display(Name = "Potensielt høy risiko")]
    PH,

    [Display(Name = "Lav risiko")]
    LO,

    [Display(Name = "Ingen kjent risiko")]
    NK,

    [Display(Name = "Ikke risikovurdert")]
    NR
}