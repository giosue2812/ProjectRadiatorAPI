using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class Job
    {
        public Job()
        {
            PeopleJob = new HashSet<PeopleJob>();
        }

        [Key]
        public int IdJob { get; set; }
        [Required]
        [StringLength(50)]
        public string Label { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }

        [InverseProperty("IdJobNavigation")]
        public virtual ICollection<PeopleJob> PeopleJob { get; set; }
    }
}
