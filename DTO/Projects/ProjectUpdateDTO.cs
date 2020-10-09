using ProjectRadiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.DTO.Projects
{
    public class ProjectUpdateDTO
    {
        public string Title { get; set; }
        public string Society { get; set; }
        public string Description { get; set; }
        public DateTime DateMilestones { get; set; }
        public MilestonesType MilestonesType { get; set; }
        public DateTime StartDate { get; set; }
        public TypeStages TypeStages { get; set; }
        public string CommentDev { get; set; }
        public int IdTypeFollow { get; set; }
    }
}
