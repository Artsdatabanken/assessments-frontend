using System.Collections.Generic;
using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023
    {
        /// <summary>
        /// Evaluation  'tag' for the species. Evaluated categories are "AlienSpecie", "DoorKnocker", "RegionallyAlien" and "EffectWithoutReproduction"
        /// </summary>
        public string AlienSpeciesCategory { get; set; }

        /// <summary>
        /// Was the alien species established by year 1800? If true the alien species is not risk assessed
        /// </summary>
        public bool? AlienSpecieUncertainIfEstablishedBefore1800 { get; set; }

        /// <summary>
        /// Final category according to GEIAAS categories and criteria
        /// </summary>
        public AlienSpeciesAssessment2023Category Category { get; set; }

        /// <summary>
        /// Decisive criteria according to GEIAAS method
        /// </summary>
        public string Criteria { get; set; }

        /// <summary>
        /// Establishment category in Norway today. The alien species may not be in Norway, be represented in Norway by sporadic, ephemeral occurrences, or by populations that are locally self-sustaining or strongly expanding
        /// </summary>
        public string EstablishmentCategory { get; set; }

        /// <summary>
        /// Geographic area assessed
        /// </summary>
        public AlienSpeciesAssessment2023EvaluationContext EvaluationContext { get; set; }

        /// <summary>
        /// Name of ekspert committee that conducted the assessments 
        /// </summary>
        public string ExpertGroup { get; set; }

        /// <summary>
        /// The unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Free text field used to describe uncertainty around the species' status as alien
        /// </summary>
        public string IsAlien { get; set; }

        /// <summary>
        /// List including category and decisive criteria from previous assessments
        /// </summary>
        public List<AlienSpeciesAssessment2023PreviousAssessment> PreviousAssessments { get; set; } = new();

        /// <summary>
        /// A species that is used for production of goods or services in agriculture, forestry, horticulture, gardens, parks, aquaculture, farming, as pet, for hobby or leisure, or a species imported as food, fodder or bait
        /// </summary>
        public bool? ProductionSpecies { get; set; }

        /// <summary>
        /// When forming part of an Identification, this should be the name in lowest level taxonomic rank that can be determined
        /// </summary>
        public string ScientificName { get; set; }

        /// <summary>
        /// Author of the scienfic name
        /// </summary>
        public string ScientificNameAuthor { get; set; }

        /// <summary>
        /// An identifier for the nomenclatural (not taxonomic) details of a scientific name
        /// </summary>
        public int ScientificNameId { get; set; }

        /// <summary>
        /// The species' total score on the ecological effect axis
        /// </summary>
        public int? ScoreEcologicalEffect { get; set; }

        /// <summary>
        /// The species' total score on the invation axis
        /// </summary>
        public int? ScoreInvationPotential { get; set; }

        /// <summary>
        /// Taxonomy path
        /// </summary>
        public string TaxonHierarcy { get; set; }

        /// <summary>
        /// Norwegian common names
        /// </summary>
        public string VernacularName { get; set; }
    }
}