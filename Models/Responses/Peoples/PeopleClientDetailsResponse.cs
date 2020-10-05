using ProjectRadiator.DTO.Peoples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Models.Responses
{
    public class PeopleClientDetailsResponse:ResponseBase
    {
        public List<ClientDetailsDTO> Client { get; set; }
        public PeopleClientDetailsResponse()
        {
            Client = new List<ClientDetailsDTO>();
        }
    }
}
