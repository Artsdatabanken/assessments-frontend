using Assessments.Shared.Resources.Enums.AlienSpecies;
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
        [Display(Name = nameof(AlienSpeciesAssessment2023ScientificNameRankResource.species), Description = nameof(AlienSpeciesAssessment2023ScientificNameRankResource.species_description), ResourceType = typeof(AlienSpeciesAssessment2023ScientificNameRankResource))]
        Species = 22,

        [Display(Name = nameof(AlienSpeciesAssessment2023ScientificNameRankResource.subspecies), Description =  nameof(AlienSpeciesAssessment2023ScientificNameRankResource.subspecies_description), ResourceType = typeof(AlienSpeciesAssessment2023ScientificNameRankResource))]
        SubSpecies = 23,

        [Display(Name = nameof(AlienSpeciesAssessment2023ScientificNameRankResource.variety), Description = nameof(AlienSpeciesAssessment2023ScientificNameRankResource.variety_description), ResourceType = typeof(AlienSpeciesAssessment2023ScientificNameRankResource))]
        Variety = 24,

        [Display(Name = nameof(AlienSpeciesAssessment2023ScientificNameRankResource.form), Description = nameof(AlienSpeciesAssessment2023ScientificNameRankResource.form_description), ResourceType = typeof(AlienSpeciesAssessment2023ScientificNameRankResource))]
        Form = 25,

        [Display(Name = nameof(AlienSpeciesAssessment2023ScientificNameRankResource.hybrid), Description = nameof(AlienSpeciesAssessment2023ScientificNameRankResource.hybrid_description), ResourceType = typeof(AlienSpeciesAssessment2023ScientificNameRankResource))]
        tth,

        [Display(Name = nameof(AlienSpeciesAssessment2023ScientificNameRankResource.taxonomic_rank), ResourceType = typeof(AlienSpeciesAssessment2023ScientificNameRankResource))]
        ttn,

        [Display(Name = nameof(AlienSpeciesAssessment2023ScientificNameRankResource.assessed_at_another_rank), ResourceType = typeof(AlienSpeciesAssessment2023ScientificNameRankResource))]
        tva,

        [Display(Name = nameof(AlienSpeciesAssessment2023ScientificNameRankResource.not_assessed_at_another_rank), ResourceType = typeof(AlienSpeciesAssessment2023ScientificNameRankResource))]
        tvi
    }
}