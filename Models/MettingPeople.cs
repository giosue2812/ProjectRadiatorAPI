using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class MettingPeople
    {
        [Key]
        public int IdMetting { get; set; }
        [Key]
        public int IdPeople { get; set; }

        [ForeignKey(nameof(IdMetting))]
        [InverseProperty(nameof(Metting.MettingPeople))]
        public virtual Metting IdMettingNavigation { get; set; }
        [ForeignKey(nameof(IdPeople))]
        [InverseProperty(nameof(People.MettingPeople))]
        public virtual People IdPeopleNavigation { get; set; }
    }
}
