using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.DTO.Millestones
{
    public class MilestonesProjectListDTO
    {
        public string Project { get; set; }
        public System.DateTime MillestonesDate { get; set; }
        public IEnumerable<IEnumerable<MilestonesTypeDTO>> MillestonesTypeDTOs { get; set; }
    }
}
