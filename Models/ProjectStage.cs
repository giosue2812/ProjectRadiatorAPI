using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class ProjectStage
    {
        [Key]
        public int IdProject { get; set; }
        [Key]
        public int IdStage { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(IdProject))]
        [InverseProperty(nameof(Project.ProjectStage))]
        public virtual Project IdProjectNavigation { get; set; }
        [ForeignKey(nameof(IdStage))]
        [InverseProperty(nameof(Stages.ProjectStage))]
        public virtual Stages IdStageNavigation { get; set; }
    }
}
