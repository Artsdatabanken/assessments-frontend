using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023ChangedFromAlien
    {
        [Display(Name = "ikke endret fra fremmed")]
        Unknown,

        [Display(Name = "tidligere antatt fremmed")]
        WasThoughtToBeAlien,

        [Display(Name = "tidligere fremmed, men er nå etablert")]
        WasAlienButEstablishedNow,
    }
}
