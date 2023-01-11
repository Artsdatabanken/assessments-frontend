using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023TimeHorizon
    {
        [Display(Name = "Nå")]
        now,

        [Display(Name = "Fremtidig")]
        future
    }
}