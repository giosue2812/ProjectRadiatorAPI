using ProjectRadiator.DTO.Stages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Models.Responses.Stages
{
    public class StageTypesResponse:ResponseBase
    {
        public List<StageTypesDTO> StageTypes { get; set; }

        public int TotalCount
        {
            get
            {
               return StageTypes.Count();
            }
        }

        public StageTypesResponse()
        {
            StageTypes = new List<StageTypesDTO>();
        }
    }
}
