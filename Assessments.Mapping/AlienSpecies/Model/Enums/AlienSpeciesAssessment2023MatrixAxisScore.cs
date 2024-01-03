using Assessments.Shared.Resources.Enums.AlienSpecies;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public class AlienSpeciesAssessment2023MatrixAxisScore
    {
        public enum InvasionPotential
        {
            [Display(Name = nameof(AlienSpeciesAssessment2023MatrixAxisScoreResource.unknown), ResourceType = typeof(AlienSpeciesAssessment2023MatrixAxisScoreResource))]
            [Description("ip0")]
            Unknown,
            [Display(Name = nameof(AlienSpeciesAssessment2023MatrixAxisScoreResource.small), ResourceType = typeof(AlienSpeciesAssessment2023MatrixAxisScoreResource))]
            [Description("ip1")]
            Small,
            [Display(Name = nameof(AlienSpeciesAssessment2023MatrixAxisScoreResource.limited), ResourceType = typeof(AlienSpeciesAssessment2023MatrixAxisScoreResource))]
            [Description("ip2")]
            Limited,
            [Display(Name = nameof(AlienSpeciesAssessment2023MatrixAxisScoreResource.moderate), ResourceType = typeof(AlienSpeciesAssessment2023MatrixAxisScoreResource))]
            [Description("ip3")]
            Moderate,
            [Display(Name = nameof(AlienSpeciesAssessment2023MatrixAxisScoreResource.great), ResourceType = typeof(AlienSpeciesAssessment2023MatrixAxisScoreResource))]
            [Description("ip4")]
            Great,
        }

        public enum EcologicalEffect
        {
            [Display(Name = nameof(AlienSpeciesAssessment2023MatrixAxisScoreResource.unknown), ResourceType = typeof(AlienSpeciesAssessment2023MatrixAxisScoreResource))]
            [Description("ee0")]
            Unknown,
            [Display(Name = nameof(AlienSpeciesAssessment2023MatrixAxisScoreResource.no_known), ResourceType = typeof(AlienSpeciesAssessment2023MatrixAxisScoreResource))]
            [Description("ee1")]
            NotKnown,
            [Display(Name = nameof(AlienSpeciesAssessment2023MatrixAxisScoreResource.little), ResourceType = typeof(AlienSpeciesAssessment2023MatrixAxisScoreResource))]
            [Description("ee2")]
            Small,
            [Display(Name = nameof(AlienSpeciesAssessment2023MatrixAxisScoreResource.medium), ResourceType = typeof(AlienSpeciesAssessment2023MatrixAxisScoreResource))]
            [Description("ee3")]
            Medium,
            [Display(Name = nameof(AlienSpeciesAssessment2023MatrixAxisScoreResource.large), ResourceType = typeof(AlienSpeciesAssessment2023MatrixAxisScoreResource))]
            [Description("ee4")]
            Great,
        }
    }
}
