using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class Follow
    {
        public Follow()
        {
            FollowPeople = new HashSet<FollowPeople>();
            FollowTypeFollow = new HashSet<FollowTypeFollow>();
        }

        [Key]
        public int IdFollow { get; set; }
        [Column("Date_Follow", TypeName = "datetime")]
        public DateTime DateFollow { get; set; }
        [Required]
        [StringLength(255)]
        public string CommentDev { get; set; }
        [StringLength(255)]
        public string CommentCustomer { get; set; }
        [Column("Is_SoftDeleted")]
        public bool IsSoftDeleted { get; set; }
        public int IdProject { get; set; }

        [ForeignKey(nameof(IdProject))]
        [InverseProperty(nameof(Project.Follow))]
        public virtual Project IdProjectNavigation { get; set; }
        [InverseProperty("IdFollowNavigation")]
        public virtual ICollection<FollowPeople> FollowPeople { get; set; }
        [InverseProperty("IdFollowNavigation")]
        public virtual ICollection<FollowTypeFollow> FollowTypeFollow { get; set; }
    }
}
