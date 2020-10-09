using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class Milestones
    {
        public Milestones()
        {
            MilestonesProject = new HashSet<MilestonesProject>();
            MilestonesTypeMilestones = new HashSet<MilestonesTypeMilestones>();
        }

        [Key]
        public int IdMilestones { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateMilestones { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        public bool IsSoftDeleted { get; set; }

        [InverseProperty("IdMilestonesNavigation")]
        public virtual ICollection<MilestonesProject> MilestonesProject { get; set; }
        [InverseProperty("IdMilestonesNavigation")]
        public virtual ICollection<MilestonesTypeMilestones> MilestonesTypeMilestones { get; set; }
    }
}
