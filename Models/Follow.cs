using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class Follow
    {
        public Follow()
        {
            FollowPeople = new HashSet<FollowPeople>();
            FollowTypeFollow = new HashSet<FollowTypeFollow>();
        }

        public int IdFollow { get; set; }
        public DateTime DateFollow { get; set; }
        public string CommentDev { get; set; }
        public string CommentCustomer { get; set; }
        public bool IsSoftDeleted { get; set; }
        public int IdProject { get; set; }

        public virtual Project IdProjectNavigation { get; set; }
        public virtual ICollection<FollowPeople> FollowPeople { get; set; }
        public virtual ICollection<FollowTypeFollow> FollowTypeFollow { get; set; }
    }
}
