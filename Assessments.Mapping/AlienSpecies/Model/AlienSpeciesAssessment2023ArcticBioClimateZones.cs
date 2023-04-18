using Assessments.Mapping.AlienSpecies.Model.Enums;
using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023ArcticBioClimateZones
    {
        public AlienSpeciesAssessment2023ClimateZones ClimateZone { get; set; }

        public bool WeakOceanic { get; set; }

        public bool TransferSection { get; set; }

        public bool WeakContinental { get; set; }

        public bool ClearContinental { get; set; }

        public List<string> ZoneList { get; set; }
    }
}
