namespace Assessments.Shared.Helpers
{
    public static class DataFilenames
    {
        public const string Species2021 = "species-2021.json";

        // filnavn for modeller lagret som "RL2019"
        public const string Species2021Temp = "species-2021-temp.json";

        public const string Species2015 = "species-2015.json";

        public const string Species2006 = "species-2006.json";

        public const string SpeciesExpertCommitteeMembers = "species-experts.csv";

        // TODO: midlertidige navn for horisontskanning, endre tilbake etter testing

        public const string AlienSpecies2023 = "alienspecies-2023-test.json";

        public const string AlienSpecies2023Temp = "alienspecies-temp-2023-test.json";

        public const string AlienSpeciesExpertCommitteeMembers = "alienspecies-experts.csv";

        public static string CalculateAlienSpecies2023AttachmentFilePath(int attachmentId, string fileName)
        {
            return "AlienSpecies2023Attachments\\" + attachmentId + "_" + fileName;
        }
    }
}
