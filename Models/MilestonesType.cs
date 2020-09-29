using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class MilestonesType
    {
        public MilestonesType()
        {
            MilestonesTypeMilestones = new HashSet<MilestonesTypeMilestones>();
        }

        [Key]
        public int IdTypeMilestones { get; set; }
        [Required]
        [StringLength(50)]
        public string TypeMilestones { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }

        [InverseProperty("IdTypeMilestonesNavigation")]
        public virtual ICollection<MilestonesTypeMilestones> MilestonesTypeMilestones { get; set; }
    }
}
