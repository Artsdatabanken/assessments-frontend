using Assessments.Mapping.AlienSpecies.Model.Enums;
using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023YearFirstRecord
    {
        public List<AlienSpeciesAssessment2023YearFirstRecordItem> ObservedEstablishmentInNorway { get; set; } = new();

        public string Description { get; set; }
    }

    public class AlienSpeciesAssessment2023YearFirstRecordItem
    {
        public AlienSpeciesAssessment2023YearFirstRecordType RecordType { get; set; }

        public int Year { get; set; }

        public bool IsUncertaintyYear { get; set; }
    }
}