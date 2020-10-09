﻿using ProjectRadiator.DTO.Millestones;
using ProjectRadiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.DTO
{
    public class ProjectDetailDTO
    {
        public int IdProject { get; set; }
        public string Titre { get; set; }
        public string Society { get; set; }
        public string Description { get; set; }
        public System.DateTime? StartDate {get;set;}
        public string TypeStages { get; set; }
        public IEnumerable<IEnumerable<TypeFollowForOneProjectDTO>> TypeFollows { get; set; }
        public IEnumerable<MilestonesProjectListDTO> Milestone { get; set; }
    }
}

