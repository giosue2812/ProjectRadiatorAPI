using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class Stages
    {
        public Stages()
        {
            ProjectStage = new HashSet<ProjectStage>();
            StagesTypeStages = new HashSet<StagesTypeStages>();
        }

        [Key]
        public int IdStage { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LasModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }
        public int IdPeople { get; set; }

        [ForeignKey(nameof(IdPeople))]
        [InverseProperty(nameof(People.Stages))]
        public virtual People IdPeopleNavigation { get; set; }
        [InverseProperty("IdStageNavigation")]
        public virtual ICollection<ProjectStage> ProjectStage { get; set; }
        [InverseProperty("IdStagesNavigation")]
        public virtual ICollection<StagesTypeStages> StagesTypeStages { get; set; }
    }
}
