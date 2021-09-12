namespace Assessments.Mapping.Models.Species
{
    // TODO: translate (and map) properties (or remove?)
    public class SpeciesAssessment2021ImpactFactor
    {
        /// <summary>
        /// How fast the reduction of mature individuals or area of occupancy is as a result of the threat.
        /// </summary>
        public string Severity { get; set; } // Alvorlighetsgrad

        //public string Beskrivelse { get; set; }

        //public string Forkortelse { get; set; }

        /// <summary>
        /// Hierarchical id of impactfactor
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Proportion of the population size that is affected by the threat
        /// </summary>
        public string PopulationScope { get; set; } // Omfang

        //public string OverordnetTittel { get; set; }

        /// <summary>
        /// Timing of the threat
        /// </summary>
        public string TimeScope { get; set; } // Tidspunkt

        /// <summary>
        /// The ImpackFactor
        /// </summary>
        public string Factor { get; set; } // Tittel
        
        /// <summary>
        /// Hierarchical classification of impactfactor. eg. ["top GroupingFactor","subgroup","factor"]
        /// </summary>
        public string[] FactorPath { get; set; } // Tittel

        /// <summary>
        /// Top grouping of factor
        /// </summary>
        public string GroupingFactor { get; set; } // ØversteTittel
    }
}