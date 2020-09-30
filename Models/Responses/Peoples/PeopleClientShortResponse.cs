using ProjectRadiator.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Models.Responses
{
    public class PeopleClientShortResponse
    {
        public List<ClientShortDTO> Peoples { get; set; }
        public int TotalPeopels
        {
            get
            {
                return Peoples.Count();
            }
        }

        public PeopleClientShortResponse()
        {
            Peoples = new List<ClientShortDTO>();
        }
    }
}
