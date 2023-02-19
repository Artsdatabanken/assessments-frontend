using System.Text.RegularExpressions;
using Assessments.Mapping.AlienSpecies.Model.Enums;

namespace Assessments.Mapping.AlienSpecies.Model
{
    /// <summary>
    /// Short representation of ScientificName
    /// </summary>
    public class AlienSpeciesAssessment2023ScientificName
    {
        private static string StripFormatting(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) { return name; }

            return Regex.Replace(name, "<[^>]*>", string.Empty).Replace(" ", " ");
        }

        /// <summary>
        /// Optional id of name from Artsnavnebase
        /// </summary>
        public int? ScientificNameId { get; set; }

        /// <summary>
        /// Scientific name
        /// </summary>
        public string ScientificName => StripFormatting(ScientificNameFormatted); 

        /// <summary>
        /// Scientific Name with html formatting (italic)
        /// </summary>
        public string ScientificNameFormatted { get; set; }

        /// <summary>
        /// Name of Author for Scientific Name
        /// </summary>
        public string ScientificNameAuthor { get; set; }

        /// <summary>
        /// Name rank
        /// </summary>
        public AlienSpeciesAssessment2023ScientificNameRank ScientificNameRank { get; set; }
    }
}