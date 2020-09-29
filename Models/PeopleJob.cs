using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class PeopleJob
    {
        [Key]
        public int IdPeople { get; set; }
        [Key]
        public int IdJob { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(IdJob))]
        [InverseProperty(nameof(Job.PeopleJob))]
        public virtual Job IdJobNavigation { get; set; }
        [ForeignKey(nameof(IdPeople))]
        [InverseProperty(nameof(People.PeopleJob))]
        public virtual People IdPeopleNavigation { get; set; }
    }
}
