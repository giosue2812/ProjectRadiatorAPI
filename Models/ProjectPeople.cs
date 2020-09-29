using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class ProjectPeople
    {
        [Key]
        public int IdPeople { get; set; }
        [Key]
        public int IdProject { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(IdPeople))]
        [InverseProperty(nameof(People.ProjectPeople))]
        public virtual People IdPeopleNavigation { get; set; }
        [ForeignKey(nameof(IdProject))]
        [InverseProperty(nameof(Project.ProjectPeople))]
        public virtual Project IdProjectNavigation { get; set; }
    }
}
