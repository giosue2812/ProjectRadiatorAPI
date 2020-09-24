using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class Stages
    {
        public Stages()
        {
            ProjectStage = new HashSet<ProjectStage>();
            StagesTypeStages = new HashSet<StagesTypeStages>();
        }

        public int IdStage { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LasModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }
        public int IdPeople { get; set; }

        public virtual People IdPeopleNavigation { get; set; }
        public virtual ICollection<ProjectStage> ProjectStage { get; set; }
        public virtual ICollection<StagesTypeStages> StagesTypeStages { get; set; }
    }
}
