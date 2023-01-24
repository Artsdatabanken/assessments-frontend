using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023ParasitePathogenTransmission : AlienSpeciesAssessment2023SpeciesSpeciesInteraction
    {
        /// <summary>
        /// The scientific name of the parasite
        /// </summary>
        public string ParasiteScientificName { get; set; }

        /// <summary>
        /// The score that the parasite obtains for ecological effects according to criteria D-H
        /// </summary>
        public int ParasiteEcoEffect { get; set; }

        /// <summary>
        /// The status that the parasite has in Norway (alien vs. native) and to the host species (known vs. novel)
        /// </summary>
        public AlienSpeciesAssessment2023ParasiteStatus ParasiteStatus { get; set; }
    }
}