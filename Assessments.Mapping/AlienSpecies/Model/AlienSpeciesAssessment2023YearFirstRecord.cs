using Assessments.Mapping.AlienSpecies.Model.Enums;
using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023YearFirstRecord
    {
        public List<(AlienSpeciesAssessment2023YearFirstRecordType recordType, int year, bool isUncertaintyYear)> ObservedEstablishmentInNorway { get; set; } = new();

        public string Description { get; set; }

    }
}