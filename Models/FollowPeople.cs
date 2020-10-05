using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class FollowPeople
    {
        [Key]
        public int IdPeople { get; set; }
        [Key]
        public int IdFollow { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModificationDate { get; set; }

        [ForeignKey(nameof(IdFollow))]
        [InverseProperty(nameof(Follow.FollowPeople))]
        public virtual Follow IdFollowNavigation { get; set; }
        [ForeignKey(nameof(IdPeople))]
        [InverseProperty(nameof(People.FollowPeople))]
        public virtual People IdPeopleNavigation { get; set; }
    }
}
