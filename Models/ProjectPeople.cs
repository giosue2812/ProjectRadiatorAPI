using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class ProjectPeople
    {
        public int IdPeople { get; set; }
        public int IdProject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual People IdPeopleNavigation { get; set; }
        public virtual Project IdProjectNavigation { get; set; }
    }
}
