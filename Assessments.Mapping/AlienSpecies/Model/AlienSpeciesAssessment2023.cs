using Assessments.Mapping.AlienSpecies.Model.Enums;
using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023
    {
        /// <summary>
        /// Evaluation  'tag' for the species. Evaluated categories are "AlienSpecie", "DoorKnocker", "RegionallyAlien" and "EffectWithoutReproduction"
        /// </summary>

        public AlienSpeciecAssessment2023AlienSpeciesCategory AlienSpeciesCategory { get; set; }

        /// <summary>
        /// Was the alien species established by year 1800? If true the alien species is not risk assessed
        /// </summary>
        public bool? AlienSpecieUncertainIfEstablishedBefore1800 { get; set; }

        /// <summary>
        /// Final category according to GEIAAS categories and criteria
        /// </summary>
        public AlienSpeciesAssessment2023Category Category { get; set; }

        /// <summary>
        /// Explanation for a change in the assessment
        /// </summary>
        public string ChangedAssessment { get; set; }

        /// <summary>
        /// Decisive criteria according to GEIAAS method
        /// </summary>
        public string Criteria { get; set; }

        /// <summary>
        /// Lets see wht this is
        /// </summary>
        public string ConnectedToHigherLowerTaxonDescription { get; set; }

        /// <summary>
        /// Establishment category in Norway today. The alien species may not be in Norway, be represented in Norway by sporadic, ephemeral occurrences, or by populations that are locally self-sustaining or strongly expanding
        /// </summary>
        public string EstablishmentCategory { get; set; }

        /// <summary>
        /// Geographic area assessed
        /// </summary>
        public AlienSpeciesAssessment2023EvaluationContext EvaluationContext { get; set; }

        /// <summary>
        /// Tha taxon is assessed as living in either a limnic, marine, or terrestrial enviroment
        /// </summary>
        public AlienSpeciesAssessment2023Environment Environment { get; set; }

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
        /// The taxon was thought to be alien or is no longer alien, or null
        /// </summary>
        public AlienSpeciesAssessment2023ChangedFromAlien ChangedFromAlien { get; set; }

        /// <summary>
        /// Does the species live indoors
        /// </summary>
        public bool HasIndoorProduction { get; set; }

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
        /// The taxonomic rank of the evaluated scientific name
        /// </summary>
        public AlienSpeciesAssessment2023TaxonRank ScientificNameRank { get; set; }

        /// <summary>
        /// The species' total score on the ecological effect axis
        /// </summary>
        public int? ScoreEcologicalEffect { get; set; }

        /// <summary>
        /// The species' total score on the invation axis
        /// </summary>
        public int? ScoreInvationPotential { get; set; }

        /// <summary>
        /// The species group name, based on the taxon hierarchy
        /// </summary>
        public string SpeciesGroup { get; set; }

        /// <summary>
        /// Establishment category in Norway today from A-C3. The alien species may not be in Norway, be represented in Norway by sporadic, ephemeral occurrences, or by populations that are established
        /// </summary>
        public string SpeciesStatus { get; set; }

        /// <summary>
        /// Further info on how the further spread is spread further
        /// </summary>
        public string SpreadFurtherSpreadFurtherInfo { get; set; }

        /// <summary>
        /// Info text on how the spieces spreads indoors
        /// </summary>
        public string SpreadIndoorFurtherInfo { get; set; }

        /// <summary>
        /// info on how the introduces species spreads
        /// </summary>
        public string SpreadIntroductionFurtherInfo { get; set; }

        /// <summary>
        /// Taxonomy path
        /// </summary>
        public string TaxonHierarcy { get; set; }

        /// <summary>
        /// Uncertainty around the status description
        /// </summary>
        public string UncertaintyStatusDescription { get; set; }

        /// <summary>
        /// Description of the uncertainty of time of establishment
        /// </summary>
        public string UncertaintyEstablishmentTimeDescription { get; set; }

        /// <summary>
        /// Norwegian common names
        /// </summary>
        public string VernacularName { get; set; }

        /// <summary>
        /// Wether the species' score on the effect axis would be lower in the absence of current or future climate changes 
        /// </summary>
        public bool? RiskAssessmentClimateEffectsEcoEffect { get; set; }

        /// <summary>
        /// Further information about the effects of current or future climate changes 
        /// </summary>
        public string RiskAssessmentClimateEffectsDocumentation { get; set; }

        /// <summary>
        /// Documentation for the given criteria
        /// </summary>
        public string RiskAssessmentCriteriaDocumentation { get; set; }

        /// <summary>
        /// Spread in Norway
        /// </summary>
        public string RiskAssessmentCriteriaDocumentationDomesticSpread { get; set; }

        /// <summary>
        /// Documents the criteria for ecological effect
        /// </summary>
        public string RiskAssessmentCriteriaDocumentationEcoEffect { get; set; }

        /// <summary>
        /// Documents the criteria for invation potential
        /// </summary>
        public string RiskAssessmentCriteriaDocumentationInvationPotential { get; set; }

        /// <summary>
        /// Documentation for the given species status
        /// </summary>
        public string RiskAssessmentCriteriaDocumentationSpeciesStatus { get; set; }

        /// <summary>
        /// Wether the species' score on the invation axis would be lower in the absence of current or future climate changes 
        /// </summary>
        public bool? RiskAssessmentClimateEffectsInvationpotential { get; set; }

        /// <summary>
        /// Potential causes for/more detailed information about the geographic variance in category. Array with up to 4 elements 
        /// </summary>
        public List<string> RiskAssessmentGeographicalVariation { get; set; }

        /// <summary>
        /// Further information about the geographic variance in category 
        /// </summary>
        public string RiskAssessmentGeographicalVariationDocumentation { get; set; }

        /// <summary>
        /// Wether the species has a lower impact category in parts of the species’ range
        /// </summary>
        public bool? RiskAssessmentGeographicVariationInCategory { get; set; }
    }
}