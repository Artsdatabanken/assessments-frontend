using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums
{
    public enum AlienSpeciesAssessment2023YearFirstRecordType
    {
        [Display(Name = "Etablering i norsk natur")]
        EstablishedNature,

        [Display(Name = "Selvstendig reproduksjon i norsk natur")]
        ReproductionNature,

        [Display(Name = "Individ i norsk natur")]
        IndividualNature,

        [Display(Name = "Etablering på artens eget produksjonsareal")]
        EstablishedProductionArea,

        [Display(Name = "Selvstendig reproduksjon på artens eget produksjonsareal")]
        ReproductionProductionArea,

        [Display(Name = "Individ på artens eget produksjonsareal")]
        IndividualProductionArea,

        [Display(Name = "Selvstendig reproduksjon innendørs")]
        ReproductionIndoors,

        [Display(Name = "Individ innendørs")]
        IndividualIndoors
    }
}