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
        /// The short reason why an earlier believed alien species is no longer considered alien (or null)
        /// </summary>
        public AlienSpeciesAssessment2023ChangedFromAlien ChangedFromAlien { get; set; }

        /// <summary>
        /// Explanation for why an earlier believed alien species is no longer considered alien. Free text field.
        /// </summary>
        public string ChangedFromAlienDescription { get; set; }
        
        /// <summary>
        /// Explanation for why the taxon is evaluated at another taxonomic rank. Free text field.
        /// </summary>
        public string ConnectedToHigherLowerTaxonDescription { get; set; }
        
        /// <summary>
        /// List including all criteria (A-I), their score and uncertainty
        /// </summary>
        public List<AlienSpeciesAssessment2023Criterion> Criteria { get; set; }

        /// <summary>
        /// Decisive criteria according to GEIAAS method
        /// </summary>
        public string DecisiveCriteria { get; set; }

        /// <summary>
        /// Fritekstfelt for å beskrive årsak til endring i kategori siden 2018
        /// </summary>
        public string ReasonsForChangeOfCategoryDescription { get; set; }

        /// <summary>
        /// Establishment category in Norway today. The alien species may not be in Norway, be represented in Norway by sporadic, ephemeral occurrences, or by populations that are locally self-sustaining or strongly expanding
        /// </summary>
        public string EstablishmentCategory { get; set; }

        /// <summary>
        /// Geographic area assessed
        /// </summary>
        public AlienSpeciesAssessment2023EvaluationContext EvaluationContext { get; set; }

        /// <summary>
        /// Tha taxon is assessed as living in a limnic, marine, and/or terrestrial enviroment
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
        public string AlienSpeciesDescription { get; set; }

        /// <summary>
        /// Does the taxons' pathway to norwegian nature go through indoor environments or its own production area
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
        /// Species' occurrence in counties/regions
        /// </summary>
        public List<AlienSpeciesAssessment2023RegionOccurrence> RegionOccurrences { get; set; } = new();

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
        public int? ScoreInvasionPotential { get; set; }

        /// <summary>
        /// The species group name, based on the taxon hierarchy
        /// </summary>
        public string SpeciesGroup { get; set; }

        /// <summary>
        /// Establishment category in Norway today from A-C3. The alien species may not be in Norway, be represented in Norway by sporadic, ephemeral occurrences, or by populations that are established
        /// </summary>
        public string SpeciesStatus { get; set; }

        /// <summary>
        /// Further information about the taxons' secondary spread (i.e. spread within Norwegian nature)
        /// </summary>
        public string SpreadFurtherSpreadFurtherInfo { get; set; }

        /// <summary>
        /// Further information about the taxons' entry to indoor environments or its own production area from abroad
        /// </summary>
        public string SpreadIndoorFurtherInfo { get; set; }

        /// <summary>
        /// Taxonomy path
        /// </summary>
        public string TaxonHierarcy { get; set; }

        /// <summary>
        /// Uncertainty around the establishment category. Free text field.
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
        /// Short conclusion/summary of the impact assessment. Free text field
        /// </summary>
        public string RiskAssessmentCriteriaDocumentation { get; set; }

        /// <summary>
        /// Description of the species' distribution in Norway. Free text field
        /// </summary>
        public string RiskAssessmentCriteriaDocumentationDomesticSpread { get; set; }

        /// <summary>
        /// Description and documentation of the species' ecological effects. Free text field
        /// </summary>
        public string RiskAssessmentCriteriaDocumentationEcoEffect { get; set; }

        /// <summary>
        /// Description and documentation of the species' invasion potential. Free text field
        /// </summary>
        public string RiskAssessmentCriteriaDocumentationInvasionPotential { get; set; }

        /// <summary>
        /// Description of relevant aspects of taxonomy, the species life history and ecology. Free text field
        /// </summary>
        public string RiskAssessmentCriteriaDocumentationSpeciesStatus { get; set; }

        /// <summary>
        /// Wether the species' score on the invation axis would be lower in the absence of current or future climate changes 
        /// </summary>
        public bool? RiskAssessmentClimateEffectsInvasionpotential { get; set; }

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

        /// <summary>
        /// Reasons for why a species' category has changed since the last assessment. List with up to 6 elements.
        /// </summary>
        public List<string> ReasonForChangeOfCategory { get; set; }

        /// <summary>
        /// Wether the species' may reproduce asexually or not
        /// </summary>
        public bool ReproductionAsexual { get; set; }

        /// <summary>
        /// Wether the species' may reproduce sexually or not
        /// </summary>
        public bool ReproductionSexual { get; set; }

        /// <summary>
        /// Known size of area of occupancy (AOO) today. Only relevant for AlienSpeciesCategory is "AlienSpecie" or "RegionallyAlien"
        /// </summary>
        public int? RiskAssessmentAOOknown { get; set; }

        /// <summary>
        /// Low estimate of area of occupancy (AOO) today. Only relevant if AlienSpeciesCategory is "AlienSpecie" or "RegionallyAlien"
        /// </summary>
        public int? RiskAssessmentAOOtotalLow { get; set; }

        /// <summary>
        /// Best estimate of area of occupancy (AOO) today. Only relevant if AlienSpeciesCategory is "AlienSpecie" or "RegionallyAlien"
        /// </summary>
        public int? AOOtotalBest { get; set; }

        /// <summary>
        /// High estimate of area of occupancy (AOO) today. Only relevant if AlienSpeciesCategory is "AlienSpecie" or "RegionallyAlien"
        /// </summary>
        public int? RiskAssessmentAOOtotalHigh { get; set; }

        /// <summary>
        /// Low estimate of area of occupancy (AOO) in  10 (doorknockers) to 50 (alien species that reproduce unaided now) years from now. 
        /// </summary>
        public int RiskAssessmentAOOfutureLow { get; set; }

        /// <summary>
        /// Best estimate of area of occupancy (AOO) in  10 (doorknockers) to 50 (alien species that reproduce unaided now) years from now. 
        /// </summary>
        public int AOOfutureBest { get; set; }

        /// <summary>
        /// High estimate of area of occupancy (AOO) in  10 (doorknockers) to 50 (alien species that reproduce unaided now) years from now. 
        /// </summary>
        public int RiskAssessmentAOOfutureHigh { get; set; }

        /// <summary>
        /// The reasoning or assumptions behind future area of occupancy and regional distribution. 
        /// </summary>
        public string CurrentPresenceComment { get; set; }

        /// <summary>
        /// Number of occurrences stemming from a single introduction event 10 years after the introduction took place (low estimate). Used to estimate future AOO for doorknockers. 
        /// </summary>
        public int? RiskAssessmentOccurrences1Low { get; set; }

        /// <summary>
        /// Number of occurrences stemming from a single introduction event 10 years after the introduction took place (best estimate). Used to estimate future AOO for doorknockers. 
        /// </summary>
        public int? RiskAssessmentOccurrences1Best { get; set; }

        /// <summary>
        /// Number of occurrences stemming from a single introduction event 10 years after the introduction took place (high estimate). Used to estimate future AOO for doorknockers. 
        /// </summary>
        public int? RiskAssessmentOccurrences1High { get; set; }

        /// <summary>
        /// Number of introductions (minus one) during a 10 years period (low estimate). Used to estimate future AOO for doorknockers. 
        /// </summary>
        public int? RiskAssessmentIntroductionsLow { get; set; }

        /// <summary>
        /// Number of introductions (minus one) during a 10 years period (best estimate). Used to estimate future AOO for doorknockers. 
        /// </summary>
        public int? RiskAssessmentIntroductionsBest { get; set; }

        /// <summary>
        /// Number of introductions (minus one) during a 10 years period (high estimate). Used to estimate future AOO for doorknockers. 
        /// </summary>
        public int? RiskAssessmentIntroductionsHigh { get; set; }

        /// <summary>
        /// The available methods to estimate the population lifetime of a species (or its likelihood of extinction) in Norway.
        /// </summary>
        public AlienSpeciesAssessment2023MedianLifetimeEstimationMethod MedianLifetimeEstimationMethod { get; set; }

        /// <summary>
        /// Is the median population lifetime that was automatically estimated based on estimation method "simplified estimation" accepted?
        /// </summary>
        public bool IsAcceptedSimplifiedEstimate { get; set; }

        /// <summary>
        /// Species' occurrence in water regions/areas. Only relevant for regionally alien freshwater fish.
        /// </summary>
        public AlienSpeciesAssessment2023FreshWaterRegionModel FreshWaterRegionModel { get; set; } = new();

        ///<summary>
        ///Reason for misidentification
        /// </summary>
        public string MisIdentifiedDescription { get; set; }

        ///<summary>
        /// The probability of extiction by 50 years deduced from the A-criterion score
        /// </summary>
        public AlienSpeciesAssessment2023ExtinctionProbability ExtinctionProbability { get; set; }

        ///<summary>
        /// The default, estimated score on criterion A (median lifetime) when using estimation method "simplified estimation"
        /// </summary>
        public int MedianLifetimeSimplifiedEstimationDefaultScore { get; set; }

        public AlienSpeciesAssessment2023ExpansionSpeedEstimationMethod ExpansionSpeedEstimationMethod { get; set; }
    }
}
