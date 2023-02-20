using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    /// <summary>
    /// Rank of Scientific name
    /// </summary>
    public enum AlienSpeciesAssessment2023ScientificNameRank
    {
        // ReSharper disable InconsistentNaming
        Unknown = 0,
        Kingdom = 1,
        SubKingdom = 2,
        Phylum = 3,
        SubPhylum = 4,
        SuperClass = 5,
        Class = 6,
        SubClass = 7,
        InfraClass = 8,
        Cohort = 9,
        SuperOrder = 10,
        Order = 11,
        SubOrder = 12,
        InfraOrder = 13,
        SuperFamily = 14,
        Family = 15,
        SubFamily = 16,
        Tribe = 17,
        SubTribe = 18,
        Genus = 19,
        SubGenus = 20,
        Section = 21,
        [Display(Name = "Art")]
        Species = 22,

        [Display(Name = "Underart")]
        SubSpecies = 23,

        [Display(Name = "Varietet")]
        Variety = 24,

        Form = 25,

        [Display(Name = "Taksonomisk nivå")]
        ttn,

        [Display(Name = "Vurderes på et annet taksonomisk nivå ")]
        tva,

        [Display(Name = "Vurderes ikke på et annet taksonomisk nivå ")]
        tvi
    }
}