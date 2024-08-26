using System.ComponentModel.DataAnnotations;

namespace Assessments.Mapping.AlienSpecies.Model.Enums;

public enum AlienSpeciesAssessment2023HorizonEcologicalEffect
{
    [Display(Name = "Fraværende")]
    No,

    [Display(Name = "Kjent eller antatt, men bare så lenge arten er til stede. Det vil si at effekten utgår når arten forsvinner.")]
    YesWhilePresent,

    [Display(Name = "Kjent eller antatt, og effekten vedvarer også etter at arten er borte.")]
    YesAfterGone
}