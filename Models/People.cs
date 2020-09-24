using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class People
    {
        public People()
        {
            FollowPeople = new HashSet<FollowPeople>();
            MettingPeople = new HashSet<MettingPeople>();
            PeopleJob = new HashSet<PeopleJob>();
            ProjectPeople = new HashSet<ProjectPeople>();
            Stages = new HashSet<Stages>();
        }

        public int IdPeople { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? UserId { get; set; }
        public int IdSociety { get; set; }

        public virtual ContactCarnet IdPeopleNavigation { get; set; }
        public virtual Society IdSocietyNavigation { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<FollowPeople> FollowPeople { get; set; }
        public virtual ICollection<MettingPeople> MettingPeople { get; set; }
        public virtual ICollection<PeopleJob> PeopleJob { get; set; }
        public virtual ICollection<ProjectPeople> ProjectPeople { get; set; }
        public virtual ICollection<Stages> Stages { get; set; }
    }
}
