using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class TypeStages
    {
        public TypeStages()
        {
            StagesTypeStages = new HashSet<StagesTypeStages>();
        }

        [Key]
        public int IdStages { get; set; }
        [Column("TypeStages")]
        [StringLength(50)]
        public string TypeStages1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }

        [InverseProperty("IdTypeStagesNavigation")]
        public virtual ICollection<StagesTypeStages> StagesTypeStages { get; set; }
    }
}
