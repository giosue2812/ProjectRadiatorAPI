using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class PeopleJob
    {
        public int IdPeople { get; set; }
        public int IdJob { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Job IdJobNavigation { get; set; }
        public virtual People IdPeopleNavigation { get; set; }
    }
}
