using System;
using System.Collections.Generic;

namespace Assessments.Transformation.Database.Fab4.Models
{
    public partial class Assessment
    {
        public int Id { get; set; }
        public DateTime ChangedAt { get; set; }
        public string Expertgroup { get; set; }
        public Guid LastUpdatedByUserId { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public Guid? LockedForEditByUserId { get; set; }
        public DateTime LockedForEditAt { get; set; }
        public string Doc { get; set; }
        public bool? IsDeleted { get; set; }
        public int ScientificNameId { get; set; }

        public virtual User LastUpdatedByUser { get; set; }
        public virtual User LockedForEditByUser { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}
