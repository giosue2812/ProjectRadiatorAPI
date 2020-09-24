using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class Project
    {
        public Project()
        {
            Follow = new HashSet<Follow>();
            Metting = new HashSet<Metting>();
            MilestonesProject = new HashSet<MilestonesProject>();
            ProjectPeople = new HashSet<ProjectPeople>();
            ProjectStage = new HashSet<ProjectStage>();
        }

        public int IdProject { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }
        public int CreationDateUserId { get; set; }
        public int? LastModificationUserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int IdSociety { get; set; }

        public virtual Society IdSocietyNavigation { get; set; }
        public virtual ICollection<Follow> Follow { get; set; }
        public virtual ICollection<Metting> Metting { get; set; }
        public virtual ICollection<MilestonesProject> MilestonesProject { get; set; }
        public virtual ICollection<ProjectPeople> ProjectPeople { get; set; }
        public virtual ICollection<ProjectStage> ProjectStage { get; set; }
    }
}
