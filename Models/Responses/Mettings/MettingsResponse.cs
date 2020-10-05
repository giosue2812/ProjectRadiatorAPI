using ProjectRadiator.DTO.Mettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Models.Responses
{
    public class MettingsResponse:ResponseBase
    {
        public List<MettingListDTO> Mettings { get; set; }

        public int TotalMetting
        {
            get
            {
                return Mettings.Count();
            }
        }
        public MettingsResponse()
        {
            Mettings = new List<MettingListDTO>();
        }
    }
}
