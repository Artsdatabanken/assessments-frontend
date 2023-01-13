using Assessments.Mapping.AlienSpecies.Model.Enums;
using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023SpeciesSpeciesInteractionThreatenedSpecies
    {   
        /// <summary>
        /// The scientific name of the red listed species
        /// </summary>
        public string ScientificName { get; set; }

        /// <summary>
        /// Author of the scientific name
        /// </summary>
        public string ScientificNameAuthor { get; set; }

        /// <summary>
        /// The popular name of the red listed species
        /// </summary>
        public string VernacularName { get; set; }

        /// <summary>
        /// The red list category of the species
        /// </summary>
        public string RedListCategory { get; set; }

        /// <summary>
        /// Whether the species is a key stone species or not
        /// </summary>
        public bool KeyStoneSpecie { get; set; }

        /// <summary>
        /// The strength of the interaction between the alien species and the red listed species
        /// </summary>
        public AlienSpeciesAssessment2023InteractionStrength InteractionStrength { get; set; }
        
        /// <summary>
        /// The type of interaction/negative effect induced by the alien species on the red listed species
        /// </summary>
        public AlienSpeciesAssessment2023InteractionType InteractionType { get; set; }

        /// <summary>
        /// The geographical extent of the interaction between the alien species and the red listed species
        /// </summary>
        public AlienSpeciesAssessment2023Scale Scale { get; set; }

        /// <summary>
        /// The assessment basis for the effects on the ecosystem
        /// </summary>
        public List<AlienSpeciesAssessment2023Background> Background { get; set; } //public List<string> BasisOfAssessment { get; set; } = new List<string>();
    }
}