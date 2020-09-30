using ProjectRadiator.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Models.Responses
{
    public class ProjectDetailResponse
    {
        public List<ProjectDetailDTO> Projects { get; set; }
        public int TotalProjects 
            { get
                {
                    return Projects.Count();
                }
            }
        public string messageResponse
        {
            get
            {
                return "Return details of one project";
            }
        }

        public ProjectDetailResponse()
        {
            Projects = new List<ProjectDetailDTO>();
        }
        
    }
}
