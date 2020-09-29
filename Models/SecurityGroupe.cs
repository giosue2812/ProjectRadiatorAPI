using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class SecurityGroupe
    {
        public SecurityGroupe()
        {
            SecurityGroupeRole = new HashSet<SecurityGroupeRole>();
            SecurityGroupeUser = new HashSet<SecurityGroupeUser>();
        }

        [Key]
        public int IdGroupe { get; set; }
        [Required]
        [StringLength(50)]
        public string Label { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModificationDate { get; set; }
        [Column("IS_SoftDeleted")]
        public bool IsSoftDeleted { get; set; }

        [InverseProperty("IdGroupeNavigation")]
        public virtual ICollection<SecurityGroupeRole> SecurityGroupeRole { get; set; }
        [InverseProperty("IdGroupeNavigation")]
        public virtual ICollection<SecurityGroupeUser> SecurityGroupeUser { get; set; }
    }
}
