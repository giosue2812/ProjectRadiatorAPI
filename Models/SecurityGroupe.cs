using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class SecurityGroupe
    {
        public SecurityGroupe()
        {
            SecurityGroupeRole = new HashSet<SecurityGroupeRole>();
            SecurityGroupeUser = new HashSet<SecurityGroupeUser>();
        }

        public int IdGroupe { get; set; }
        public string Label { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }

        public virtual ICollection<SecurityGroupeRole> SecurityGroupeRole { get; set; }
        public virtual ICollection<SecurityGroupeUser> SecurityGroupeUser { get; set; }
    }
}
