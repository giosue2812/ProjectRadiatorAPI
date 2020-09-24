using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class MilestonesProject
    {
        public int IdMilestones { get; set; }
        public int IdProject { get; set; }

        public virtual Milestones IdMilestonesNavigation { get; set; }
        public virtual Project IdProjectNavigation { get; set; }
    }
}
