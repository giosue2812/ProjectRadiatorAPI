using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class SecurityGroupeRole
    {
        public int IdRole { get; set; }
        public int IdGroupe { get; set; }

        public virtual SecurityGroupe IdGroupeNavigation { get; set; }
        public virtual SecurityRole IdRoleNavigation { get; set; }
    }
}
