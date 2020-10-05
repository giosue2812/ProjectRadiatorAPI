using ProjectRadiator.DTO.Millestones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Models.Responses.Millestones
{
    public class MilestoneProjectResponse
    {
        public List<MilestonesProjectListDTO> Millestones { get; set; }
        public int TotalCount
        {
            get
            {
                return Millestones.Count();
            }
        }

        public MilestoneProjectResponse()
        {
            Millestones = new List<MilestonesProjectListDTO>();
        }
    }
}
