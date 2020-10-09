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
        public int IdTypeStages { get; set; }

        [ForeignKey(nameof(IdStages))]
        [InverseProperty(nameof(Stages.StagesTypeStages))]
        public virtual Stages IdStagesNavigation { get; set; }
        [ForeignKey(nameof(IdTypeStages))]
        [InverseProperty(nameof(TypeStages.StagesTypeStages))]
        public virtual TypeStages IdTypeStagesNavigation { get; set; }
    }
}
