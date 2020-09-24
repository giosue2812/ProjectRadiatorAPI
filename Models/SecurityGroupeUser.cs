using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class SecurityGroupeUser
    {
        public int UserId { get; set; }
        public int IdGroupe { get; set; }

        public virtual SecurityGroupe IdGroupeNavigation { get; set; }
        public virtual Users User { get; set; }
    }
}
