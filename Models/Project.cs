using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class Project
    {
        public Project()
        {
            Follow = new HashSet<Follow>();
            Metting = new HashSet<Metting>();
            MilestonesProject = new HashSet<MilestonesProject>();
            ProjectPeople = new HashSet<ProjectPeople>();
            ProjectStage = new HashSet<ProjectStage>();
        }

        [Key]
        public int IdProject { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Column(TypeName = "datetime")]
        public DateTime? LastModificationDate { get; set; }
        public bool IsSoftDeleted { get; set; }
        [Column("CreationDateUserID")]
        public int CreationDateUserId { get; set; }
        [Column("LastModificationUserID")]
        public int? LastModificationUserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        public int IdSociety { get; set; }

        [ForeignKey(nameof(IdSociety))]
        [InverseProperty(nameof(Society.Project))]
        public virtual Society IdSocietyNavigation { get; set; }
        [InverseProperty("IdProjectNavigation")]
        public virtual ICollection<Follow> Follow { get; set; }
        [InverseProperty("IdProjectNavigation")]
        public virtual ICollection<Metting> Metting { get; set; }
        [InverseProperty("IdProjectNavigation")]
        public virtual ICollection<MilestonesProject> MilestonesProject { get; set; }
        [InverseProperty("IdProjectNavigation")]
        public virtual ICollection<ProjectPeople> ProjectPeople { get; set; }
        [InverseProperty("IdProjectNavigation")]
        public virtual ICollection<ProjectStage> ProjectStage { get; set; }
    }
}
