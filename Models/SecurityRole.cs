using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class SecurityRole
    {
        public SecurityRole()
        {
            SecurityGroupeRole = new HashSet<SecurityGroupeRole>();
            SecurityUserRole = new HashSet<SecurityUserRole>();
        }

        [Key]
        public int IdRole { get; set; }
        [Required]
        [StringLength(50)]
        public string Label { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModificationDate { get; set; }
        [Column("IS_SoftDeleted")]
        public bool IsSoftDeleted { get; set; }

        [InverseProperty("IdRoleNavigation")]
        public virtual ICollection<SecurityGroupeRole> SecurityGroupeRole { get; set; }
        [InverseProperty("IdRoleNavigation")]
        public virtual ICollection<SecurityUserRole> SecurityUserRole { get; set; }
    }
}
