using System.ComponentModel;

namespace Assessments.Mapping.RedlistSpecies
{
    public enum CategoryChangeReason
    {
        [Description("")]
        NoChange,
        
        [Description("Reell populasjonsendring")]
        RealPopulationChange,
        
        [Description("Endret (ny eller annen) kunnskap")]
        NewKnowledge, 

        [Description("Endrete kriterier eller tilpasning til regler")]
        CriteriaAdjustments,
        
        [Description("Ny tolkning av tidligere data")]
        NewIntepretation,
        
        [Description("Arten nyoppdaget eller nybeskrevet for landet")]
        NewSpecies, 
        
        [Description("Endret taksonomisk status")]
        TaxonomicChange,
        
        [Description("Endring i vurderingsområde")]
        AssessmentareChange, 
        
        [Description("Ikke vurdert: NA/NE art")]
        NotEvaluated2010, 
        
        [Description("Ikke vurdert: NA/NE art 2015")]
        NotEvaluated2015,
        
        [Description("Ikke vurdert: NA/NE art 2021")]
        NotEvaluated2021
    }
}