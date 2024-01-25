using System.ComponentModel.DataAnnotations;

namespace Assessments.Frontend.Web.Infrastructure.RedlistSpecies.Enums
{
    public enum RedlistSpeciesAssessment2021TaxonRank
    {
        [Display(Name = "Art")]
        Species ,

        [Display(Name = "Underart")]
        SubSpecies ,

        [Display(Name = "Varietet")]
        Variety 
    }
}
