using ProjectRadiator.DTO.Millestones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Models.Responses.Millestones
{
    public class MilestoneTypesResponse:ResponseBase
    {
        public List<MilestonesTypeDTO> MilestoneTypes { get; set; }

        public int TotalCount
        {
            get
            {
                return MilestoneTypes.Count();
            }
        }

        public MilestoneTypesResponse()
        {
            MilestoneTypes = new List<MilestonesTypeDTO>();
        }
    }
}
