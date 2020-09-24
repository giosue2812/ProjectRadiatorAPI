using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class SecurityUserRole
    {
        public int UserId { get; set; }
        public int IdRole { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual SecurityRole IdRoleNavigation { get; set; }
        public virtual Users User { get; set; }
    }
}
