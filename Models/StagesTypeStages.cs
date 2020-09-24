using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class StagesTypeStages
    {
        public int IdStages { get; set; }
        public int IdTypeStages { get; set; }

        public virtual TypeStages IdStagesNavigation { get; set; }
        public virtual Stages IdTypeStagesNavigation { get; set; }
    }
}
