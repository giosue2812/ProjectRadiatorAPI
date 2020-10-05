using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class MilestonesProject
    {
        [Key]
        public int IdMilestones { get; set; }
        [Key]
        public int IdProject { get; set; }

        [ForeignKey(nameof(IdMilestones))]
        [InverseProperty(nameof(Milestones.MilestonesProject))]
        public virtual Milestones IdMilestonesNavigation { get; set; }
        [ForeignKey(nameof(IdProject))]
        [InverseProperty(nameof(Project.MilestonesProject))]
        public virtual Project IdProjectNavigation { get; set; }
    }
}
