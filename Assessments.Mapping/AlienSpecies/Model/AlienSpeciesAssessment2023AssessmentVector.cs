using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023AssessmentVector
    {
        public AlienSpeciesAssessment2023IntroductionPathway.InfluenceFactor InfluenceFactor { get; set; }

        public AlienSpeciesAssessment2023IntroductionPathway.Magnitude Magnitude { get; set; }

        public AlienSpeciesAssessment2023IntroductionPathway.TimeOfIncident TimeOfIncident { get; set; }

        public string Category { get; set; }

        public AlienSpeciesAssessment2023IntroductionPathway.MainCategory MainCategory { get; set; }
    }
}
