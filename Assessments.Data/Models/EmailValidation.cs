using System.ComponentModel.DataAnnotations;

namespace Assessments.Data.Models
{
    public class EmailValidation
    {
        public int Id { get; set; }

        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;

        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required, MaxLength(200)]
        public string Email { get; set; }

        [Required]
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}
