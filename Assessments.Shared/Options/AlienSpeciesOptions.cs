namespace Assessments.Shared.Options
{
    public class ApplicationOptions // configured in appsettings.json
    {
        public AlienSpeciesOptions AlienSpecies { get; set; }
    }

    public class AlienSpeciesOptions
    {
        public bool DisableExport { get; set; }
    }
}
