using ProjectRadiator.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ProjectRadiator.Models.Responses
{
    public class SocietyShortResponse
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
