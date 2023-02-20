namespace Assessments.Mapping.AlienSpecies.Model
{
    /// <summary>
    /// File attachment associated with assessment
    /// </summary>
    public class AlienSpeciesAssessment2023Attachment
    {
        /// <summary>
        /// Id of attachment
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Textual description of attachment content
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Filename of attachment
        /// </summary>
        public string FileName { get; set; }
        
        /// <summary>
        /// Mimetype of attachment
        /// </summary>
        public string MimeType { get; set; }
    }
}
