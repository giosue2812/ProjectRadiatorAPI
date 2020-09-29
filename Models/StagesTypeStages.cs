using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class StagesTypeStages
    {
        [Key]
        public int IdStages { get; set; }
        [Key]
        public int IdTypeStages { get; set; }

        [ForeignKey(nameof(IdStages))]
        [InverseProperty(nameof(TypeStages.StagesTypeStages))]
        public virtual TypeStages IdStagesNavigation { get; set; }
        [ForeignKey(nameof(IdTypeStages))]
        [InverseProperty(nameof(Stages.StagesTypeStages))]
        public virtual Stages IdTypeStagesNavigation { get; set; }
    }
}
