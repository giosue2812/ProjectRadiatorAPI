using ProjectRadiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.DTO.Projects
{
    public class ProjectUpdateDTO
    {
        public int IdProject { get; set; }
        public string Title { get; set; }
        public Society Society { get; set; }
    }
}
