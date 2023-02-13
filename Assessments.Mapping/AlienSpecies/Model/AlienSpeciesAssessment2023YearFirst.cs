using Assessments.Mapping.AlienSpecies.Model.Enums;
using System.Collections.Generic;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023YearFirstObserved
    {
        public List<(AlienSpeciesAssessment2023YearFirstEstablishmentType establishmentType, int year, bool uncertaintyYear)> ObservedEstablishmentInNorway { get; set; } = new();

        //public List<int> Year { get; set; }

        public string Description { get; set; }

    }
}