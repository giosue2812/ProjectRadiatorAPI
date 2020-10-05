using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectRadiator.Models
{
    public partial class FollowTypeFollow
    {
        [Key]
        public int IdFollow { get; set; }
        [Key]
        public int IdTypeFollow { get; set; }

        [ForeignKey(nameof(IdFollow))]
        [InverseProperty(nameof(Follow.FollowTypeFollow))]
        public virtual Follow IdFollowNavigation { get; set; }
        [ForeignKey(nameof(IdTypeFollow))]
        [InverseProperty(nameof(TypeFollow.FollowTypeFollow))]
        public virtual TypeFollow IdTypeFollowNavigation { get; set; }
    }
}
