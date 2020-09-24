using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class MilestonesType
    {
        public MilestonesType()
        {
            MilestonesTypeMilestones = new HashSet<MilestonesTypeMilestones>();
        }

        public int IdTypeMilestones { get; set; }
        public string TypeMilestones { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }

        public virtual ICollection<MilestonesTypeMilestones> MilestonesTypeMilestones { get; set; }
    }
}
