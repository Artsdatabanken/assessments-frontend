using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023Scale
    {
        [Display(Name = "begrenset")]
        Limited,

        [Display(Name = "storskala")]
        Large
    }
}