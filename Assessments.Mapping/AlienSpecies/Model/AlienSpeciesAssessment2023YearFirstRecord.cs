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
        public  AlienSpeciesAssessment2023YearFirstRecordType Item1 { get; set; }

        public  int Item2 { get; set; }

        public  bool Item3 { get; set; }
    }
}