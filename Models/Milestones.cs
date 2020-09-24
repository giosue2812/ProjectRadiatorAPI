using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class Milestones
    {
        public Milestones()
        {
            MilestonesProject = new HashSet<MilestonesProject>();
            MilestonesTypeMilestones = new HashSet<MilestonesTypeMilestones>();
        }

        public int IdMilestones { get; set; }
        public DateTime DateMilestones { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }

        public virtual ICollection<MilestonesProject> MilestonesProject { get; set; }
        public virtual ICollection<MilestonesTypeMilestones> MilestonesTypeMilestones { get; set; }
    }
}
