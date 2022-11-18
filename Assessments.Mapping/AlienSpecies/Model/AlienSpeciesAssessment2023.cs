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
        public int ScientificNameRank { get; set; }

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
        /// Taxonomy path
        /// </summary>
        public string TaxonHierarcy { get; set; }

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
        public uint? RiskAssessmentAOOknown { get; set; }

        /// <summary>
        /// Low estimate of area of occupancy (AOO) today. Only relevant if AlienSpeciesCategory is "AlienSpecie" or "RegionallyAlien"
        /// </summary>
        public uint? RiskAssessmentAOOtotalLow { get; set; }

        /// <summary>
        /// Best estimate of area of occupancy (AOO) today. Only relevant if AlienSpeciesCategory is "AlienSpecie" or "RegionallyAlien"
        /// </summary>
        public uint? RiskAssessmentAOOtotalBest { get; set; }

        /// <summary>
        /// High estimate of area of occupancy (AOO) today. Only relevant if AlienSpeciesCategory is "AlienSpecie" or "RegionallyAlien"
        /// </summary>
        public uint? RiskAssessmentAOOtotalHigh { get; set; }

        /// <summary>
        /// Low estimate of area of occupancy (AOO) in  10 (doorknockers) to 50 (alien species that reproduce unaided now) years from now. 
        /// </summary>
        public uint? RiskAssessmentAOOfutureLow { get; set; }

        /// <summary>
        /// Best estimate of area of occupancy (AOO) in  10 (doorknockers) to 50 (alien species that reproduce unaided now) years from now. 
        /// </summary>
        public uint? RiskAssessmentAOOfutureBest { get; set; }

        /// <summary>
        /// High estimate of area of occupancy (AOO) in  10 (doorknockers) to 50 (alien species that reproduce unaided now) years from now. 
        /// </summary>
        public uint? RiskAssessmentAOOfutureHigh { get; set; }

        /// <summary>
        /// The reasoning or assumptions behind future area of occupancy and regional distribution. 
        /// </summary>
        public string CurrentPresenceComment { get; set; }
    }
}