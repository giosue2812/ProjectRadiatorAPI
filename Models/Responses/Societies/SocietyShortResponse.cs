using ProjectRadiator.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ProjectRadiator.Models.Responses
{
    public class SocietyShortResponse:ResponseBase
    {
        public List<SocietyShortDTO> Societies {get;set;}

        public int TotalSociety
        {
            get
            {
                return Societies.Count();
            }
        }

        public SocietyShortResponse()
        {
            Societies = new List<SocietyShortDTO>();
        }
    }
}
