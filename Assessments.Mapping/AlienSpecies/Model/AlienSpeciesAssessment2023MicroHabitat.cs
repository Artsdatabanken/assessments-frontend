using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023MicroHabitat
    {
        /// <summary>
        /// Name of the chosen microhabitat used by the alien species
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The scientific name of the species used as microhabitat (if relevant)
        /// </summary>
        public string ScientificName { get; set; }

        /// <summary>
        /// Author of the scientific name
        /// </summary>
        public string ScientificNameAuthor { get; set; }

        /// <summary>
        /// The popular name of the species used as microhabitat (if relevant)
        /// </summary>
        public string VernacularName { get; set; }

        /// <summary>
        /// Time horizon of effect. I.e. whether the impact of the alien species is happening now or assumed in the futre
        /// </summary>
        public AlienSpeciesAssessment2023TimeHorizon TimeHorizon { get; set; }
    }
}