using System.ComponentModel.DataAnnotations;

namespace Assessments.Data.Models
{
    public class FeedbackAttachment
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FileName { get; set; }

        [Required, MaxLength(200)]
        public string BlobName { get; set; }

        [Required]
        public int FeedbackId { get; set; }

        public Feedback Feedback { get; set; }
    }
}