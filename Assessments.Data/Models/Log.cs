using System.ComponentModel.DataAnnotations;

namespace Assessments.Data.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTimeOffset Logged { get; set; }

        [Required]
        [MaxLength(64)]
        public string Level { get; set; }

        [Required]
        [MaxLength(4096)]
        public string Message { get; set; }

        [Required]
        [MaxLength(512)]
        public string Logger { get; set; }
        
        [MaxLength(8192)]
        public string Exception { get; set; }

        [MaxLength(1024)]
        public string Controller { get; set; }

        [MaxLength(1024)]
        public string Action { get; set; }

        [MaxLength(512)]
        public string Method { get; set; }
        
        [MaxLength(1024)]
        public string Url { get; set; }
        
        [MaxLength(1024)]
        public string QueryString { get; set; }

        [MaxLength(1024)]
        public string Referrer { get; set; }

        [MaxLength(1024)]
        public string Hostname { get; set; }        
        
        [MaxLength(1024)]
        public string Environment { get; set; }
    }
}
