using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class Job
    {
        public Job()
        {
            PeopleJob = new HashSet<PeopleJob>();
        }

        public int IdJob { get; set; }
        public string Label { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }

        public virtual ICollection<PeopleJob> PeopleJob { get; set; }
    }
}
