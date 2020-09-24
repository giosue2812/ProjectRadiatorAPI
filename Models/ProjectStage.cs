using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class ProjectStage
    {
        public int IdProject { get; set; }
        public int IdStage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Project IdProjectNavigation { get; set; }
        public virtual Stages IdStageNavigation { get; set; }
    }
}
