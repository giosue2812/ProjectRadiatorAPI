using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class MilestonesTypeMilestones
    {
        [Key]
        public int IdTypeMilestones { get; set; }
        [Key]
        public int IdMilestones { get; set; }

        [ForeignKey(nameof(IdMilestones))]
        [InverseProperty(nameof(Milestones.MilestonesTypeMilestones))]
        public virtual Milestones IdMilestonesNavigation { get; set; }
        [ForeignKey(nameof(IdTypeMilestones))]
        [InverseProperty(nameof(MilestonesType.MilestonesTypeMilestones))]
        public virtual MilestonesType IdTypeMilestonesNavigation { get; set; }
    }
}
