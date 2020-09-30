using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Models.Responses
{
    public class ProjectCountResponse
    {
        public List<Project> Projects { get; set; }
        public int OpenProject 
        { 
            get
            {
                return Projects.Where(x => x.EndDate == null).Count();
            }
        }
        public int ColoseProject
        {
            get
            {
                return Projects.Where(x => x.EndDate != null).Count();
            }
        }

        public ProjectCountResponse()
        {
            Projects = new List<Project>();
        }
    }
}
