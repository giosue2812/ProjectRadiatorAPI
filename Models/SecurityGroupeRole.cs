using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class SecurityGroupeRole
    {
        [Key]
        public int IdRole { get; set; }
        [Key]
        public int IdGroupe { get; set; }

        [ForeignKey(nameof(IdGroupe))]
        [InverseProperty(nameof(SecurityGroupe.SecurityGroupeRole))]
        public virtual SecurityGroupe IdGroupeNavigation { get; set; }
        [ForeignKey(nameof(IdRole))]
        [InverseProperty(nameof(SecurityRole.SecurityGroupeRole))]
        public virtual SecurityRole IdRoleNavigation { get; set; }
    }
}
