using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums;

public enum AlienSpeciesAssessment2023HorizonEstablismentPotential
{
    [Display(Name = "Ingen. Det vil si at arten har dødd ut fra introduksjonsstedet.")]
    Zero,

    [Display(Name = "En. Det vil si at arten har verken dødd ut eller ekspandert.")]
    One,

    [Display(Name = "To eller flere. Det vil si at arten har ekspandert.")]
    TwoOrMore
}