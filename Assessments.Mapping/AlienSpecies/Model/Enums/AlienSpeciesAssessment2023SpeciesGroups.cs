using Assessments.Shared.Resources.Enums.AlienSpecies;
using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023SpeciesGroups
    {
        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.phaeophyceae), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Phaeophyceae,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.chlorophyta), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Chlorophyta,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.rhodophyta), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Rhodophyta,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.coleoptera), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Coleoptera,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.zygentoma), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Zygentoma,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.phthiraptera), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Phthiraptera,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.hemiptera), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Hemiptera,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.lepidoptera), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Lepidoptera,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.psocoptera), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Psocoptera,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.diptera), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Diptera,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.thysanoptera), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Thysanoptera,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.hymenoptera), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Hymenoptera,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.malacostraca), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Malacostraca,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.branchiopoda), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Branchiopoda,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.copepoda), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Copepoda,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.thecostraca), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Thecostraca,

        //[Display(Name = "Alger")]
        //Rhodophyta, Chlorophyta, Phaeophyceae,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.amphibia), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Amphibia,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.bacteria), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Bacteria,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.mollusca), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Mollusca,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.arachnida), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Arachnida,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.oomycota), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Oomycota,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.actinopterygii), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Actinopterygii,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.platyhelminthes), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Platyhelminthes,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.aves), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Aves,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.pycnogonida), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Pycnogonida,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.rotifera), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Rotifera,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.insecta), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Insecta,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.ctenophora), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Ctenophora,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.ascidiacea_tunicata), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Ascidiacea,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.ascidiacea_tunicata), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Tunicata,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.magnoliophyta_pinophyta_pteridophyta), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Magnoliophyta,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.magnoliophyta_pinophyta_pteridophyta), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Pinophyta,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.magnoliophyta_pinophyta_pteridophyta), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Pteridophyta,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.crustacea), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Crustacea,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.annelida), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Annelida,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.myriapoda_chilopoda_diplopoda_dauropoda_symphyla), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Myriapoda,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.myriapoda_chilopoda_diplopoda_dauropoda_symphyla), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Chilopoda,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.myriapoda_chilopoda_diplopoda_dauropoda_symphyla), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Diplopoda,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.myriapoda_chilopoda_diplopoda_dauropoda_symphyla), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Pauropoda,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.myriapoda_chilopoda_diplopoda_dauropoda_symphyla), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Symphyla,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.ectoprocta_entoprocta), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Ectoprocta,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.ectoprocta_entoprocta), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Entoprocta,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.bryophyta_marchantiophyta), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Bryophyta,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.bryophyta_marchantiophyta), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Marchantiophyta,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.mammalia), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Mammalia,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.cnidaria), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Cnidaria,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.echinodermata), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Echinodermata,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.reptilia), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Reptilia,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.nematoda), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Nematoda,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.porifera), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Porifera,

        [Display(Name = nameof(AlienSpeciesAssessment2023SpeciesGroupsResource.fungi), ResourceType = typeof(AlienSpeciesAssessment2023SpeciesGroupsResource))]
        Fungi,
    }
}
