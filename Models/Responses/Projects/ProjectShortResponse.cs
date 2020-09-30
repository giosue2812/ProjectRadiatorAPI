﻿using ProjectRadiator.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Models.Responses
{
    public class ProjectShortResponse
    {
        public List<ProjectShortDTO> Projects { get; set; }
        public int TotalProjects { get
            {
                return Projects.Count();
            }}
        public string MessageResponse { get 
                {
                    return "Short list of project";
                }}

        public ProjectShortResponse()
        {
            Projects = new List<ProjectShortDTO>();
        }
    }
}
