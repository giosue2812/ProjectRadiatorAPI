using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.DTO.Millestones
{
    public class MilestonesProjectListDTO
    {
        public string Project { get; set; }
        public System.DateTime MilestonesDate { get; set; }
        public IEnumerable<IEnumerable<MilestonesTypeDTO>> MilestonesType { get; set; }
    }
}
