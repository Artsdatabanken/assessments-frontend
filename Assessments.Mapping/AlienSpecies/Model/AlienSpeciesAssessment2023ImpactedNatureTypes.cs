using Assessments.Mapping.AlienSpecies.Model.Enums;
using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023ImpactedNatureTypes
    {
        /// <summary>
        /// Name of the ecosystem in Norwegian
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Time horizon of effect. I.e. whether the impact of the alien species is happening now or assumed in the futre
        /// </summary>
        public AlienSpeciesAssessment2023TimeHorizon TimeHorizon { get; set; }
        /// <summary>
        /// The proportion of the total area of the ecosystem(s) affected that will contain occurrences of the alien species within 50 years
        /// </summary>
        public string ColonizedArea { get; set; }
        /// <summary>
        /// The variables that the alien species brings about a substantial state change in
        /// </summary>
        public List<AlienSpeciesAssessment2023StateChange> StateChange { get; set; }

        /// <summary>
        /// The proportion of the total area of the ecosystem affected by a substantial state change caused by the alien species
        /// </summary>
        public string AffectedArea { get; set; }

        /// <summary>
        /// The assessment basis for the effects on the ecosystem
        /// </summary>
        public List<AlienSpeciesAssessment2023Background> Background { get; set; }
    }
}