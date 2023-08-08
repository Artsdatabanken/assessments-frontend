using Assessments.Shared.Helpers;
using CsvHelper.Configuration.Attributes;

namespace Assessments.Mapping.AlienSpecies.Model
{
    public class AlienSpeciesAssessment2023ExpertGroupMember
    {
        public string ExpertGroup { get; set; }

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FirstNameInitials { get; set; }

        public string ExpertGroupRole { get; set; }

        /// <summary>
        /// Assessment Id
        /// </summary>
        [Optional]
        [TypeConverter(typeof(StringToNullableIntConverter))]
        public int? Id { get; set; }

        /// <summary>
        /// Sortorder when Id is available
        /// </summary>
        [Optional]
        [TypeConverter(typeof(StringToNullableIntConverter))]
        public int? CitationOrder { get; set; }
    }
}
