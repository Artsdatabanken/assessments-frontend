using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments.Transformation.Database.Fab4.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public int AssessmentId { get; set; }
        public Assessment Assessment { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public bool IsDeleted { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public AttachmentFile AttachmentFile { get; set; }
    }
    public class AttachmentFile
    {
        public int Id { get; set; }
        public byte[] File { get; set; }
    }
}
