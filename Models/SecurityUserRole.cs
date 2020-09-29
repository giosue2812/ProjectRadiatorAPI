using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class SecurityUserRole
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int IdRole { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(IdRole))]
        [InverseProperty(nameof(SecurityRole.SecurityUserRole))]
        public virtual SecurityRole IdRoleNavigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.SecurityUserRole))]
        public virtual Users User { get; set; }
    }
}
