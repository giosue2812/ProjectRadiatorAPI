using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class People
    {
        public People()
        {
            FollowPeople = new HashSet<FollowPeople>();
            MettingPeople = new HashSet<MettingPeople>();
            PeopleJob = new HashSet<PeopleJob>();
            ProjectPeople = new HashSet<ProjectPeople>();
            Stages = new HashSet<Stages>();
        }

        [Key]
        public int IdPeople { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public int? UserId { get; set; }
        [Column("Id_Society")]
        public int IdSociety { get; set; }

        [ForeignKey(nameof(IdPeople))]
        [InverseProperty(nameof(ContactCarnet.People))]
        public virtual ContactCarnet IdPeopleNavigation { get; set; }
        [ForeignKey(nameof(IdSociety))]
        [InverseProperty(nameof(Society.People))]
        public virtual Society IdSocietyNavigation { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.People))]
        public virtual Users User { get; set; }
        [InverseProperty("IdPeopleNavigation")]
        public virtual ICollection<FollowPeople> FollowPeople { get; set; }
        [InverseProperty("IdPeopleNavigation")]
        public virtual ICollection<MettingPeople> MettingPeople { get; set; }
        [InverseProperty("IdPeopleNavigation")]
        public virtual ICollection<PeopleJob> PeopleJob { get; set; }
        [InverseProperty("IdPeopleNavigation")]
        public virtual ICollection<ProjectPeople> ProjectPeople { get; set; }
        [InverseProperty("IdPeopleNavigation")]
        public virtual ICollection<Stages> Stages { get; set; }
    }
}
