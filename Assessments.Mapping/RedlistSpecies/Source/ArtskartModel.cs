namespace Assessments.Mapping.RedlistSpecies.Source
{
    public class ArtskartModel
    {
        public bool ExcludeGbif { get; set; }

        public int FromMonth { get; set; }

        public bool IncludeNorge { get; set; }

        public bool IncludeObjects { get; set; }

        public bool IncludeObservations { get; set; }

        public bool IncludeSvalbard { get; set; }

        public int ObservationFromYear { get; set; }

        public int ObservationToYear { get; set; }

        public int ToMonth { get; set; }
    }
}