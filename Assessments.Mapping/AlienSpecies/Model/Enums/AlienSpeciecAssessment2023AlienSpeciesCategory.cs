using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciecAssessment2023AlienSpeciesCategory
    {
        [Display(Name = "Selvstendig reproduserende")]
        AlienSpecie,

        [Display(Name = "Dørstokkart")]
        DoorKnocker,

        [Display(Name = "Økologisk effekt uten selvstendig reproduksjon innen 50 år")] //treated like a doorknocker and will be visualised with "Dørstokkart" in the filter meny, but use this displayname in the species assessment site. 
        EffectWithoutReproduction,

        /// <summary>
        /// These are only alien in parts of Norway (they are resident species of Norway) and are therefore excluded from the filter on assessment area (EvaluationContext). 
        /// </summary>
        [Display(Name = "Regionalt fremmed")]
        RegionallyAlien,

        [Display(Name = "Ikke fremmed")]
        NotAlienSpecie,

        [Display(Name = "Vurderes på et annet taksonomisk nivå")]
        TaxonEvaluatedAtAnotherLevel,

        [Display(Name = "Etablert per år 1800")]
        UncertainBefore1800,

        [Display(Name = "Regionalt fremmed og etablert per år 1800")]
        RegionallyAlienEstablishedBefore1800,

        [Display(Name = "Tidligere feilbestemt")]
        MisIdentified,

        [Display(Name = "Ikke vurdert fordi det foreligger separate vurderinger av infraspesifikke taksa")]
        AllSubTaxaAssessedSeparately,

        [Display(Name = "Utenfor avgrensningen")]
        HybridWithoutOwnRiskAssessment
    }
}