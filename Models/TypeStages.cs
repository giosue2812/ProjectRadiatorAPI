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
        [Required]
        [Column("TypeStages")]
        [StringLength(50)]
        public string TypeStages1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }

        [InverseProperty("IdStagesNavigation")]
        public virtual ICollection<StagesTypeStages> StagesTypeStages { get; set; }
    }
}
