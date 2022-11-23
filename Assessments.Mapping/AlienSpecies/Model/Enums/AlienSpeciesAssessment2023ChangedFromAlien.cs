using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023ChangedFromAlien
    {
        [Display(Name = "ikke endret fra fremmed")]
        Unknown,

        [Display(Name = "tidligere antatt fremmed, men kunnskapsgrunnlaget/tolkninga er endra")]
        WasThoughtToBeAlien,

        [Display(Name = "tidligere vært fremmed, men har nå etablert minst én stedegen bestand")]
        WasAlienButEstablishedNow,
    }
}
