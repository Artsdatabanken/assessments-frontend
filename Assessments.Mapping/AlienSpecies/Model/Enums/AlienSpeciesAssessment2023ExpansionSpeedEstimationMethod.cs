using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023ExpansionSpeedEstimationMethod
    {
        [Display(Name = "")]
        NotRelevant,

        [Display(Name = "Datasett med tid- og stedfesta observasjoner")]
        SpatioTemporalDataset,

        [Display(Name = "Anslått økning i artens forekomstareal")]
        EstimatedIncreaseInAOOReproducingUnaided,

        [Display(Name = "Anslått økning i artens forekomstareal og ekspansjon er forventet større framover i tid")]
        EstimatedIncreaseInAOOReproducingUnaidedFutureExpansion,

        [Display(Name = "Anslått økning i artens forekomstareal")]
        EstimatedIncreaseInAOODoorKnockers,

    }
}