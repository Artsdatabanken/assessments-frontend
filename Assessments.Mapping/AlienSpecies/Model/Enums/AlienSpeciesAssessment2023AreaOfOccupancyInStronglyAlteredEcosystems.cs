using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023AreaOfOccupancyInStronglyAlteredEcosystems
    {
        [Display(Name = "")]
        NotChosen,

        [Display(Name = "under 5 %")]
        Value0,

        [Display(Name = "fra og med 5 % til 25 %")]
        Value5,

        [Display(Name = "fra og med 25 % til og med 75 %")]
        Value25,

        [Display(Name = "fra 75 % til og med 95 %")]
        Value75,

        [Display(Name = "over 95 %")]
        Value95
    }
}