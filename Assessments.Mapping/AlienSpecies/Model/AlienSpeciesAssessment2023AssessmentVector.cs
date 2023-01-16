using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023AssessmentVector
    {
        public AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread IntroductionSpread { get; set; }

        public AlienSpeciesAssessment2023IntroductionPathway.InfluenceFactor InfluenceFactor { get; set; }

        public AlienSpeciesAssessment2023IntroductionPathway.Magnitude Magnitude { get; set; }

        public string TimeOfIncident { get; set; }

        public string Category { get; set; }

        public string MainCategory { get; set; }

        public static AlienSpeciesAssessment2023IntroductionPathway.Magnitude GetMagnitude(string magnitude)
        {
            var x = magnitude;
            return magnitude switch
            {
                "unknown" => AlienSpeciesAssessment2023IntroductionPathway.Magnitude.Unknown,
                "1" => AlienSpeciesAssessment2023IntroductionPathway.Magnitude.Smallest,
                "2-10" => AlienSpeciesAssessment2023IntroductionPathway.Magnitude.Small,
                "11-100" => AlienSpeciesAssessment2023IntroductionPathway.Magnitude.Medium,
                "101-1000" => AlienSpeciesAssessment2023IntroductionPathway.Magnitude.Large,
                "moreThan1000" => AlienSpeciesAssessment2023IntroductionPathway.Magnitude.MoreThan1000,
                _ => AlienSpeciesAssessment2023IntroductionPathway.Magnitude.NotChosen
            };
        }
    }
}
