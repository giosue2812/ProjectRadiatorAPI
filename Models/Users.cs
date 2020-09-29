using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("IS_SoftDeleted")]
        public bool IsSoftDeleted { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<People> People { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<SecurityGroupeUser> SecurityGroupeUser { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<SecurityUserRole> SecurityUserRole { get; set; }
    }
}
