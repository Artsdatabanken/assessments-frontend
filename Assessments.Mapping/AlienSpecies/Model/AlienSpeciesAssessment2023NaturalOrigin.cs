using Assessments.Mapping.AlienSpecies.Model.Enums;
using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023NaturalOrigin
    {
        public AlienSpeciesAssessment2023NaturalOriginClimateZone ClimateZone { get; set; }

        public List<AlienSpeciesAssessment2023NaturalOriginContinent> Continent { get; set; }

    }
}