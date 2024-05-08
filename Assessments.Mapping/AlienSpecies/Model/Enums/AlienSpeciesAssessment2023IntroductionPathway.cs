using Assessments.Shared.Resources.Enums.AlienSpecies;
using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public class AlienSpeciesAssessment2023IntroductionPathway
    {
        public enum IntroductionSpread
        {
            [Display(Name = "")]
            NotChosen,

            [Display(Name = "Introduksjon")]
            Introduction,

            [Display(Name = "Spredning")]
            Spread
        }

        public enum InfluenceFactor
        {
            [Display(Name = "")]
            NotChosen,

            [Display(Name = nameof(AlienSpeciesAssessment2023ArrivedCountryFromResource.unknown), ResourceType = typeof(AlienSpeciesAssessment2023ArrivedCountryFromResource))]
            Unknown,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.numerous_yearly), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))]
            NumerousYearly,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.yearly), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))]
            Yearly,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.several_per_ten_years), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))]
            SeveralPr10years,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.rarer_than_ten_years), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))]
            RarerThan10years
        }

        public enum Magnitude
        {
            [Display(Name = "")]
            NotChosen,

            [Display(Name = nameof(AlienSpeciesAssessment2023ArrivedCountryFromResource.unknown), ResourceType = typeof(AlienSpeciesAssessment2023ArrivedCountryFromResource))]
            Unknown,

            [Display(Name = "1")]
            Smallest,

            [Display(Name = "2 - 10")]
            Small,

            [Display(Name = "11 - 100")]
            Medium,

            [Display(Name = "101 - 1000")]
            Large,

            [Display(Name = "> 1000")]
            MoreThan1000
        }

        public enum TimeOfIncident
        {
            [Display(Name = "")]
            NotChosen,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.historic), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))]
            Historic,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.ceased), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))]
            Ceased,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.ongoing), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))]
            Ongoing,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.future), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))]
            Future,

            [Display(Name = nameof(AlienSpeciesAssessment2023ArrivedCountryFromResource.unknown), ResourceType = typeof(AlienSpeciesAssessment2023ArrivedCountryFromResource))]
            Unknown
        }

        public enum MainCategory
        {
            [Display(Name = "")]
            Unknown,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.import), Description = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.import), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))]
            ImportDirect,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.intentionally_released), Description = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.intentionally_released), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))] 
            Released,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.escape), Description = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.escape), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))] 
            Escaped,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.contaminant), Description = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.contaminant_description), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))] 
            Transportpolution,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.stowaway),  Description = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.stowaway_description), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))] 
            Stowaway,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.corridor), Description = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.corridor_description), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))] 
            Corridor,

            [Display(Name = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.natural_dispersal), Description = nameof(AlienSpeciesAssessment2023IntroductionPathwayResource.natural_dispersal), ResourceType = typeof(AlienSpeciesAssessment2023IntroductionPathwayResource))] 
            NaturalDispersal

        }
    }
}
