using System;
using System.Collections.Generic;

namespace Assessments.Transformation.Database.Fab4.Models
{
    public partial class User
    {
        public User()
        {
            AssessmentLastUpdatedByUsers = new HashSet<Assessment>();
            AssessmentLockedForEditByUsers = new HashSet<Assessment>();
            UserRoleInExpertGroups = new HashSet<UserRoleInExpertGroup>();
        }

        public Guid Id { get; set; }
        public bool IsAdmin { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Application { get; set; }
        public bool HasAccess { get; set; }
        public bool HasAppliedForAccess { get; set; }
        public bool AccessDenied { get; set; }
        public DateTime DateGivenAccess { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastActive { get; set; }

        public virtual ICollection<Assessment> AssessmentLastUpdatedByUsers { get; set; }
        public virtual ICollection<Assessment> AssessmentLockedForEditByUsers { get; set; }
        public virtual ICollection<UserRoleInExpertGroup> UserRoleInExpertGroups { get; set; }
    }
}
