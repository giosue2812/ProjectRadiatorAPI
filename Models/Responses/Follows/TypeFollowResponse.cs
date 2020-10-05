using ProjectRadiator.DTO.TypeFollows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Models.Responses
{
    public class TypeFollowResponse:ResponseBase
    {
        public List<TypeFollowsDTO> TypeFollows { get; set; }

        public int TotalCount
        {
            get
            {
                return TypeFollows.Count();
            }
        }

        public TypeFollowResponse()
        {
            TypeFollows = new List<TypeFollowsDTO>();
        }
    }
}
