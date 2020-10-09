using ProjectRadiator.DTO.Millestones;
using ProjectRadiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.DTO
{
    public class ProjectShortDTO
    {
        public int IdProject { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Society { get; set; }
        public string TypeStages { get; set; }
        public System.DateTime? MettingDate { get; set; }
        public IEnumerable<MilestonesProjectListDTO> Milestone { get; set; }
        public List<TeamsBstormShortDTO> Peoples { get; set; }
    }
}
