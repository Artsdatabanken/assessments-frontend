using System;
using System.Collections.Generic;

namespace Assessments.Transformation.Database.Fab4.Models
{
    public partial class UserRoleInExpertGroup
    {
        public string ExpertGroupName { get; set; }
        public Guid UserId { get; set; }
        public bool Admin { get; set; }
        public bool WriteAccess { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid RoleGivenByUserId { get; set; }

        public virtual User User { get; set; }
    }
}
