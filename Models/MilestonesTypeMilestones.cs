using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class MilestonesTypeMilestones
    {
        public int IdTypeMilestones { get; set; }
        public int IdMilestones { get; set; }

        public virtual Milestones IdMilestonesNavigation { get; set; }
        public virtual MilestonesType IdTypeMilestonesNavigation { get; set; }
    }
}
