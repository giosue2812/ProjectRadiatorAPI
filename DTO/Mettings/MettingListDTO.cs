using ProjectRadiator.DTO.Peoples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.DTO.Mettings
{
    public class MettingListDTO
    {
        public string Project { get; set; }
        public System.DateTime? MettingDate { get; set; }
        public List<PeoplesMettingDTO> Peoples { get; set; }
    }
}
