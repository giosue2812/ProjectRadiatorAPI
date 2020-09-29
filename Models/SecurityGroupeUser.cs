using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class SecurityGroupeUser
    {
        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Key]
        public int IdGroupe { get; set; }

        [ForeignKey(nameof(IdGroupe))]
        [InverseProperty(nameof(SecurityGroupe.SecurityGroupeUser))]
        public virtual SecurityGroupe IdGroupeNavigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.SecurityGroupeUser))]
        public virtual Users User { get; set; }
    }
}
