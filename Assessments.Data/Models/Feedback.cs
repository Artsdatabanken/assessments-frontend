
using System.ComponentModel.DataAnnotations;

namespace Assessments.Data.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;

        public int AssessmentId { get; set; }

        public int Year { get; set; }

        public FeedbackType Type { get; set; }
            
        [Required, MaxLength(100)]
        public string ExpertGroup { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, MaxLength(200)]
        public string Email { get; set; }

        [Required, MaxLength(10000)]
        public string Comment { get; set; }

        public List<FeedbackAttachment> Attachments { get; set; }
    }

    public enum FeedbackType
    {
        AlienSpecies = 0
    }
}
