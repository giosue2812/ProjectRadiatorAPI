using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class MettingPeople
    {
        public int IdMetting { get; set; }
        public int IdPeople { get; set; }

        public virtual Metting IdMettingNavigation { get; set; }
        public virtual People IdPeopleNavigation { get; set; }
    }
}
