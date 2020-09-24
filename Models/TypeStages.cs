using System;
using System.Collections.Generic;

namespace ProjectRadiator.Models
{
    public partial class TypeStages
    {
        public TypeStages()
        {
            StagesTypeStages = new HashSet<StagesTypeStages>();
        }

        public int IdStages { get; set; }
        public string TypeStages1 { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }

        public virtual ICollection<StagesTypeStages> StagesTypeStages { get; set; }
    }
}
