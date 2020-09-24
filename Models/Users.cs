using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class Users
    {
        public Users()
        {
            People = new HashSet<People>();
            SecurityGroupeUser = new HashSet<SecurityGroupeUser>();
            SecurityUserRole = new HashSet<SecurityUserRole>();
        }

        public int UserId { get; set; }
        public string Password { get; set; }
        public bool IsSoftDeleted { get; set; }

        public virtual ICollection<People> People { get; set; }
        public virtual ICollection<SecurityGroupeUser> SecurityGroupeUser { get; set; }
        public virtual ICollection<SecurityUserRole> SecurityUserRole { get; set; }
    }
}
