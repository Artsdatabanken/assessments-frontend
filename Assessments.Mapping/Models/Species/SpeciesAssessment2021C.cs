namespace Assessments.Mapping.Models.Species
{
    public class SpeciesAssessment2021C
    {
        /// <summary>
        /// Typical number of genets (genetically distinct colony) per location. Used for calculating the estimated number of mature individuals in clonal/colony-forming taxa.
        /// </summary>
        public string GenetsPerLocation { get; set; } // CAntallGeneter

        /// <summary>
        /// Typical number of ramets ("individuals") per genet (genetically distinct colony). Used for calculating the estimated number of mature individuals in clonal/colony-forming taxa. 
        /// </summary>
        public string RametsPerGenet { get; set; } // CAntallRameter

        /// <summary>
        /// The known number of mature individuals
        /// </summary>
        public string KnownPopulationSize { get; set; } // CKjentPopulasjonsstørrelse                

        /// <summary>
        /// The number of known locations where the taxon has been found. Used for calculating the estimated known number of mature individuals.
        /// </summary>
        public string NumberOfLocations { get; set; } // CNumberOfLocations // TODO

        /// <summary>
        /// Whether or not the number of mature individuals were estimated indirectly. 
        /// </summary>
        public string CPopulasjonsstørrelse { get; set; } = "Ikke aktuelt"; // CPopulasjonsstørrelse

        public SpeciesAssessment2021MinMaxProbableIntervall Statistics { get; set; } = new(); // CPopulasjonsstørrelseAntatt

        /// <summary>
        /// Preliminary category that just the number of mature individuals on the C-criterion represents. 
        /// </summary>
        public string PreliminaryCategory { get; set; } // CPopulasjonsstørrelseKode

        /// <summary>
        /// Typical number of mature individuals per location. Used for calculating the estimated number of mature individuals.
        /// </summary>
        public string IndividualsPerLocation { get; set; } // CReproductionDefinitionPerLocation

        /// <summary>
        /// Typical number of mature individuals per substrate unit. Used for calculating the estimated number of mature individuals. 
        /// </summary>
        public string IndividualsPerSubstrateUnit { get; set; } // CReproductionDefinitionPerTree

        /// <summary>
        /// Typical number of mature individuals per area unit. The metric area unit is stated in C:{IndividualsPerAreaUnit}. Used for calculating the estimated number of mature individuals. 
        /// </summary>
        public string IndividualsPerAreaValue { get; set; } // CReproductionDefinitionTemplate

        /// <summary>
        /// Metric unit of area for C:{IndividualsPerAreaValue}. Used for calculating the estimated number of mature individuals. 
        /// </summary>
        public string IndividualsPerAreaUnit { get; set; } // CReproductionDefinitionTemplateScale

        /// <summary>
        /// Typical number of substrate units per location. Used for calculating the estimated number of mature individuals. 
        /// </summary>
        public string SubstrateUnitsPerLocation { get; set; } // CSubstratenheter
    }
}