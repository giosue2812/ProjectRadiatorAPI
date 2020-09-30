using ProjectRadiator.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Models.Responses
{
    public class ProjectPartialListResponse
    {
        public List<ProjectPartialListDTO> Projects { get; set; }
        public int TotalProjects 
            { get
                {
                    return Projects.Count();
                }
            }
        public string MessageResponse
        {
            get
            {
                return "List of partial project";
            }
        }
        public ProjectPartialListResponse()
        {
             Projects = new List<ProjectPartialListDTO>();
        }
    }
}
