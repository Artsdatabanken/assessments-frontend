using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Helpers
{
    public static class AlienSpeciesAssessment2023Extensions
    {
        public static string Description(this AlienSpeciesAssessment2023Criterion criterion)
        {
            var description = string.Empty;

            switch (criterion.CriteriaLetter)
            {
                case AlienSpeciesAssessment2023CriteriaLetter.A:
                    description = criterion.Value switch
                    {
                        1 => "mindre enn 10 år",
                        2 => "mellom 10 og 59 år",
                        3 => "mellom 60 og 649 år",
                        4 => "minimum 650 år",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.B:
                    description = criterion.Value switch
                    {
                        1 => "mindre enn 50 m/år",
                        2 => "mellom 50 og 159 m/år",
                        3 => "mellom 160 og 499 m/år",
                        4 => "minimum 500 m/år",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.C:
                    description = criterion.Value switch
                    {
                        1 => "mindre enn 5%",
                        2 => "minimum 5%",
                        3 => "minimum 10%",
                        4 => "minimum 20%",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.D:
                    description = criterion.Value switch
                    {
                        1 => "fraværende",
                        2 => "svak styrke og begrenset omfang",
                        3 => "svak styrke og storskala omfang ELLER moderat styrke og begrenset omfang",
                        4 => "moderat styrke og storskala omfang ELLER fortrengning",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.E:
                    description = criterion.Value switch
                    {
                        1 => "svak styrke ELLER moderat styrke og begrenset omfang",
                        2 => "moderat styrke og storskala omfang",
                        3 => "fortrengning i begrenset omfang",
                        4 => "fortrengning i storskala omfang",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.F:
                    description = criterion.Value switch
                    {
                        1 => "0%",
                        2 => "over 0%",
                        3 => "minimum 2%",
                        4 => "minimum 5%",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.G:
                    description = criterion.Value switch
                    {
                        1 => "mindre enn 5%",
                        2 => "minimum 5%",
                        3 => "minimum 10%",
                        4 => "minimum 20%",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.H:
                    description = criterion.Value switch
                    {
                        1 => "ingen overføring",
                        2 => "begrenset til rødlistevurdert art",
                        3 => "storskala til rødlistevurdert art ELLER begrenset til truet art eller nøkkelart",
                        4 => "storskala til truet art eller nøkkelart",
                        _ => description
                    };
                    break;
                case AlienSpeciesAssessment2023CriteriaLetter.I:
                    description = criterion.Value switch
                    {
                        1 => "ingen overføring ELLER begrenset til art som allerede er vert for denne parasitten",
                        2 => "storskala til art som allerede er vert for denne parasitten ELLER begrenset til ny vert",
                        3 => "storskala av eksisterende parasitt til ny vert ELLER begrenset til ny truet vert",
                        4 => "storskala av eksisterende parasitt til ny truet vert ELLER storskala eller begrenset av en fremmed parasitt",
                        _ => description
                    };
                    break;
                default:
                    return description;
            }

            return description;
        }
    }
}