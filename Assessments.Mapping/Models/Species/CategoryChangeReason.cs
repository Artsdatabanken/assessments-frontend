namespace Assessments.Mapping.Models.Species
{
    public enum CategoryChangeReason
    {
        NoChange,
        RealPopulationChange, //Reell populasjonsendring,
        NewKnowledge, //Endret (ny eller annen) kunnskap,
        CriteriaAdjustments, //Endrete kriterier eller tilpasning til regler,
        NewIntepretation, //Ny tolkning av tidligere data,
        NewSpecies, //Arten nyoppdaget eller nybeskrevet for landet,
        TaxonomicChange, //Endret taksonomisk status,
        AssessmentareChange, //Endring i vurderingsområde,
        NotEvaluated2010, // Ikke vurdert: NA/NE art,
        NotEvaluated2015, //Ikke vurdert: NA/NE art 2015
        NotEvaluated2021
    }
}