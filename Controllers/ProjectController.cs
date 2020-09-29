using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectRadiator.DTO;
using ProjectRadiator.Models;
using ProjectRadiator.Utilis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        //Declaration of variable type ProjectRadiatorContext to link to models DB
        private readonly ProjectRadiatorContext _context;

        //Constructor of ProjectController which need a context DB
        public ProjectController(ProjectRadiatorContext context)
        {
            _context = context;
        }


        //GET:api/project
        [HttpGet]
        public IEnumerable<ProjectShortDTO> Get()
        {
            var projects = _context.Project
                .Include(x => x.IdSocietyNavigation)
                .Include(x => x.ProjectStage)
                    .ThenInclude(x => x.IdStageNavigation)
                    .ThenInclude(x => x.StagesTypeStages)
                    .ThenInclude(x => x.IdTypeStagesNavigation)
                    .ThenInclude(x => x.StagesTypeStages)
                    .ThenInclude(x => x.IdStagesNavigation)
                .Select(x => x.ToProjectShortDTO())
                .ToList();

            return projects;

        }
    }
}