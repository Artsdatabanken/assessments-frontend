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

        public static AlienSpeciesAssessment2023IntroductionPathway.InfluenceFactor GetInfluenceFactor(string influenceFactor)
        {
            return influenceFactor switch
            {
                "unknown" => AlienSpeciesAssessment2023IntroductionPathway.InfluenceFactor.Unknown,
                "numerousYearly" => AlienSpeciesAssessment2023IntroductionPathway.InfluenceFactor.NumerousYearly,
                "yearly" => AlienSpeciesAssessment2023IntroductionPathway.InfluenceFactor.Yearly,
                "severalPr10years" => AlienSpeciesAssessment2023IntroductionPathway.InfluenceFactor.SeveralPr10years,
                "rarerThan10years" => AlienSpeciesAssessment2023IntroductionPathway.InfluenceFactor.RarerThan10years,
                _ => AlienSpeciesAssessment2023IntroductionPathway.InfluenceFactor.NotChosen
            };
        }

        public static AlienSpeciesAssessment2023IntroductionPathway.Magnitude GetMagnitude(string magnitude)
        {
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

        public static AlienSpeciesAssessment2023IntroductionPathway.TimeOfIncident GetTimeOfIncident(string timeOfIncident)
        {
            return timeOfIncident switch
            {
                "unknown" => AlienSpeciesAssessment2023IntroductionPathway.TimeOfIncident.Unknown,
                "historic" => AlienSpeciesAssessment2023IntroductionPathway.TimeOfIncident.Historic,
                "ceased" => AlienSpeciesAssessment2023IntroductionPathway.TimeOfIncident.Ceased,
                "ongoing" => AlienSpeciesAssessment2023IntroductionPathway.TimeOfIncident.Ongoing,
                "future" => AlienSpeciesAssessment2023IntroductionPathway.TimeOfIncident.Future,
                _ => AlienSpeciesAssessment2023IntroductionPathway.TimeOfIncident.NotChosen
            };
        }

        public static AlienSpeciesAssessment2023IntroductionPathway.MainCategory GetMainCategory(string mainCategory)
        {
            return mainCategory switch
            {
                "Rømning/forvilling" => AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Escaped,
                "Blindpassasjer med transport" => AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Stowaway,
                "Korridor" => AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Corridor,
                "Tilsiktet utsetting" => AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Released,
                "Egenspredning" => AlienSpeciesAssessment2023IntroductionPathway.MainCategory.NaturalDispersal,
                "Forurensning av vare" => AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Transportpolution,
                _ => AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Unknown
            };
        }
    }
}
