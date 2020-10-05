using ProjectRadiator.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Models.Responses
{
    public class PeopleTeamsShortResponse:ResponseBase
    {
        public List<TeamsBstormShortDTO> TeamsBstorm { get; set; }

        public int TotalTeams
        {
            get
            {
                return TeamsBstorm.Count();
            }
        }

        public PeopleTeamsShortResponse()
        {
            TeamsBstorm = new List<TeamsBstormShortDTO>();
        }
    }
}
