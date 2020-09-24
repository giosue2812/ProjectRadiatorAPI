using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class Metting
    {
        public Metting()
        {
            MettingPeople = new HashSet<MettingPeople>();
        }

        public int IdMetting { get; set; }
        public DateTime? MettingDate { get; set; }
        public string MettingResult { get; set; }
        public bool IsSoftDeleted { get; set; }
        public int IdProject { get; set; }

        public virtual Project IdProjectNavigation { get; set; }
        public virtual ICollection<MettingPeople> MettingPeople { get; set; }
    }
}
