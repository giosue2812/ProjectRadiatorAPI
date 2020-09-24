using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class FollowPeople
    {
        public int IdPeople { get; set; }
        public int IdFollow { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }

        public virtual Follow IdFollowNavigation { get; set; }
        public virtual People IdPeopleNavigation { get; set; }
    }
}
