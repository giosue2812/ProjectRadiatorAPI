using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class TypeFollow
    {
        public TypeFollow()
        {
            FollowTypeFollow = new HashSet<FollowTypeFollow>();
        }

        [Key]
        public int IdTypeFollow { get; set; }
        [Required]
        [StringLength(50)]
        public string Label { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModificationDate { get; set; }
        [Column("IS_SoftDeleted")]
        public bool IsSoftDeleted { get; set; }

        [InverseProperty("IdTypeFollowNavigation")]
        public virtual ICollection<FollowTypeFollow> FollowTypeFollow { get; set; }
    }
}
