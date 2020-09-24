using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class SecurityRole
    {
        public SecurityRole()
        {
            SecurityGroupeRole = new HashSet<SecurityGroupeRole>();
            SecurityUserRole = new HashSet<SecurityUserRole>();
        }

        public int IdRole { get; set; }
        public string Label { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }

        public virtual ICollection<SecurityGroupeRole> SecurityGroupeRole { get; set; }
        public virtual ICollection<SecurityUserRole> SecurityUserRole { get; set; }
    }
}
