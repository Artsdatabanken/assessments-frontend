namespace Assessments.Shared.Options
{
    public class ApplicationOptions
    {
        public AlienSpeciesOptions AlienSpecies { get; set; }
    }

    public class AlienSpeciesOptions
    {
        public bool DisableExport { get; set; }
    }
}
