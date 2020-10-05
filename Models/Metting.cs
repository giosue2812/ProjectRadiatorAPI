using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class Metting
    {
        public Metting()
        {
            MettingPeople = new HashSet<MettingPeople>();
        }

        [Key]
        public int IdMetting { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? MettingDate { get; set; }
        [StringLength(255)]
        public string MettingResult { get; set; }
        public bool IsSoftDeleted { get; set; }
        public int IdProject { get; set; }

        [ForeignKey(nameof(IdProject))]
        [InverseProperty(nameof(Project.Metting))]
        public virtual Project IdProjectNavigation { get; set; }
        [InverseProperty("IdMettingNavigation")]
        public virtual ICollection<MettingPeople> MettingPeople { get; set; }
    }
}
