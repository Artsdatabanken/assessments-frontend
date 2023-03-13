using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023NatureTypeMainGategoryGroup
    {
        [Display(Name = "Ukjent hovedtypegruppe")]
        Unknown,

        [Display(Name = "Limniske vannmasser")]
        F,

        [Display(Name = "Marine vannmasser")]
        H,

        [Display(Name = "Snø- og issystemer")]
        I,

        [Display(Name = "Innsjøbunnsystemer")]
        L,

        [Display(Name = "Saltvannsbunnsystemer")]
        M,

        [Display(Name = "Elvebunnsystemer")]
        O,

        [Display(Name = "Fastmarkssystemer")]
        T,

        [Display(Name = "Våtmarkssystemer")]
        V,
    }
}
