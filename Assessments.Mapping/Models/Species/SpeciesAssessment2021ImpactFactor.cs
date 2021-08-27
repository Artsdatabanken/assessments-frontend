namespace Assessments.Mapping.Models.Species
{
    // TODO: translate (and map) properties (or remove?)
    public class SpeciesAssessment2021ImpactFactor
    {
        /// <summary>
        /// How fast the reduction of mature individuals or area of occupancy is as a result of the threat.
        /// </summary>
        public string Severity { get; set; } // Alvorlighetsgrad

        public string Beskrivelse { get; set; }

        public string Forkortelse { get; set; }

        public string Id { get; set; }

        /// <summary>
        /// Proportion of the population size that is affected by the threat
        /// </summary>
        public string PopulationScope { get; set; } // Omfang

        public string OverordnetTittel { get; set; }

        /// <summary>
        /// Timing of the threat
        /// </summary>
        public string TimeScope { get; set; } // Tidspunkt

        public string Tittel { get; set; }

        public string ØversteTittel { get; set; }
    }
}