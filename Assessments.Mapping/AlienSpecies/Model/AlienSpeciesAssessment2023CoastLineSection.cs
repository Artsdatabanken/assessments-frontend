using Assessments.Mapping.AlienSpecies.Model.Enums;
using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023CoastLineSection
    {
        public AlienSpeciesAssessment2023ClimateZones ClimateZone { get; set; }

        public bool None { get; set; }

        public bool OpenCoastLine { get; set; }

        public bool Skagerrak { get; set; }

        public List<string> ZoneList { get; set; }
    }
}
