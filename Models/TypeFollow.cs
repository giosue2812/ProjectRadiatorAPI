using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class TypeFollow
    {
        public TypeFollow()
        {
            FollowTypeFollow = new HashSet<FollowTypeFollow>();
        }

        public int IdTypeFollow { get; set; }
        public string Label { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }

        public virtual ICollection<FollowTypeFollow> FollowTypeFollow { get; set; }
    }
}
