using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023MajorTypeGroup
    {
        [Display(Name = "ukjent")]
        Unknown,

        [Display(Name = "Ferskvann")]
        Naf,

        [Display(Name = "Fjell og berg")]
        Nafb,

        [Display(Name = "Landform")]
        Nal,

        [Display(Name = "Marint dypvann")]
        Namd,

        [Display(Name = "Marint gruntvann")]
        Namger,

        [Display(Name = "Marint gruntvann, Svalbard")]
        NamgsrSvalbard,

        [Display(Name = "Semi-naturlig")]
        Nasn,

        [Display(Name = "Skog")]
        Nas,

        [Display(Name = "Svalbard")]
        Nasv,

        [Display(Name = "Våtmark")]
        Nav,
    }
}
