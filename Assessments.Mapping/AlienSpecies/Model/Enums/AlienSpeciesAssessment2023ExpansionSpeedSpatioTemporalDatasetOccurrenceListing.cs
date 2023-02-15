using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023ExpansionSpeedSpatioTemporalDatasetOccurrenceListing
    {
        [Display(Name = "")]
        NotRelevant,

        [Display(Name = "bare første året de har blitt observert")]
        FirstYear,

        [Display(Name = "hvert år de har eksistert")]
        EveryYear
    }
}