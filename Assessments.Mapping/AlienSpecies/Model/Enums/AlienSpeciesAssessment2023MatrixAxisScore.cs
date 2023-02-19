using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public class AlienSpeciesAssessment2023MatrixAxisScore
    {
        public enum InvasionPotential
        {
            [Display(Name = "ukjent")]
            [Description("ip0")]
            Unknown,
            [Display(Name = "Lite")]
            [Description("ip1")]
            Small,
            [Display(Name = "Begrensa")]
            [Description("ip2")]
            Limited,
            [Display(Name = "Moderat")]
            [Description("ip3")]
            Moderate,
            [Display(Name = "Stor")]
            [Description("ip4")]
            Great,
        }

        public enum EcologicalEffect
        {
            [Display(Name = "ukjent")]
            [Description("ee0")]
            Unknown,
            [Display(Name = "Ingen kjent")]
            [Description("ee1")]
            NotKnown,
            [Display(Name = "Liten")]
            [Description("ee2")]
            Small,
            [Display(Name = "Middels")]
            [Description("ee3")]
            Medium,
            [Display(Name = "Stor")]
            [Description("ee4")]
            Great,
        }
    }
}
