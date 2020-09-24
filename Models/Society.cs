using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class Society
    {
        public Society()
        {
            People = new HashSet<People>();
            Project = new HashSet<Project>();
        }

        public int IdSociety { get; set; }
        public string Name { get; set; }
        public bool IsProvider { get; set; }

        public virtual ContactCarnet IdSocietyNavigation { get; set; }
        public virtual ICollection<People> People { get; set; }
        public virtual ICollection<Project> Project { get; set; }
    }
}
