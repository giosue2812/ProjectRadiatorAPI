using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class FollowTypeFollow
    {
        public int IdFollow { get; set; }
        public int IdTypeFollow { get; set; }

        public virtual Follow IdFollowNavigation { get; set; }
        public virtual TypeFollow IdTypeFollowNavigation { get; set; }
    }
}
