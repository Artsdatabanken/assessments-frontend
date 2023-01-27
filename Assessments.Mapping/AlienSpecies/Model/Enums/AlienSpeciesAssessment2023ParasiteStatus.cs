using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023ParasiteStatus
    {
        [Display(Name = "ny for verten og fremmed")]
        NewAlien,

        [Display(Name = "ny for verten og stedegen")]
        NewNative,

        [Display(Name = "kjent for verten og fremmed")]
        KnownAlien,

        [Display(Name = "kjent for verten og stedegen")]
        KnownNative,
    }
}