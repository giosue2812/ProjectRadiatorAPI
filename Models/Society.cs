using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class Society
    {
        public Society()
        {
            People = new HashSet<People>();
            Project = new HashSet<Project>();
        }

        [Key]
        public int IdSociety { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("Is_Provider")]
        public bool IsProvider { get; set; }

        [ForeignKey(nameof(IdSociety))]
        [InverseProperty(nameof(ContactCarnet.Society))]
        public virtual ContactCarnet IdSocietyNavigation { get; set; }
        [InverseProperty("IdSocietyNavigation")]
        public virtual ICollection<People> People { get; set; }
        [InverseProperty("IdSocietyNavigation")]
        public virtual ICollection<Project> Project { get; set; }
    }
}
