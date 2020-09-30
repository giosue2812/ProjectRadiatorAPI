using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectRadiator.DTO;
using ProjectRadiator.Models;
using ProjectRadiator.Models.Responses;
using ProjectRadiator.Utilis;
using System.Collections.Generic;
using System.Linq;

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


        //GET:api/project/GetShortProjects
        [HttpGet("GetShortProjects")]
        //This action return a short list of project
        public ProjectShortResponse GetShortProjects()
        {
            var projects = _context.Project
                .Include(x => x.IdSocietyNavigation)
                .Include(x => x.ProjectStage)
                    .ThenInclude(x => x.IdStageNavigation)
                    .ThenInclude(x => x.StagesTypeStages)
                    .ThenInclude(x => x.IdTypeStagesNavigation)
                .Include(x => x.Metting)
                .Include(x => x.MilestonesProject)
                    .ThenInclude(x => x.IdMilestonesNavigation)
                    .ThenInclude(x => x.MilestonesTypeMilestones)
                    .ThenInclude(x => x.IdTypeMilestonesNavigation)
                .Include(x => x.ProjectPeople)
                    .ThenInclude(x => x.IdPeopleNavigation)
                    .ThenInclude(x => x.PeopleJob)
                    .ThenInclude(x => x.IdJobNavigation)
                .Select(x => x.ToProjectShortDTO())
                .ToList();

            var response = new ProjectShortResponse
            {
                Projects = projects
            };

            return response;

        }

        //GET:api/Project/GetPartilListProject
        [HttpGet("GetPartialListProject")]
        //This action return a list of partial projects
        public ProjectPartialListResponse GetListPartialListProjects()
        {
            var projects = _context.Project
                .Include(x => x.IdSocietyNavigation)
                .Select(x => x.ToProjectPartialListDTO()).ToList();

            var response = new ProjectPartialListResponse
            {
                Projects = projects
            };
            return response;
                
        }

        [HttpGet("GetProject/{id}")]
        public ProjectDetailResponse GetProject(int id)
        {
            var projects = _context.Project
                .Include(x => x.IdSocietyNavigation)
                .Include(x => x.ProjectStage)
                    .ThenInclude(x => x.IdStageNavigation.StagesTypeStages)
                    .ThenInclude(x => x.IdTypeStagesNavigation)
                .Include(x => x.Follow)
                    .ThenInclude(x => x.FollowTypeFollow)
                    .ThenInclude(x => x.IdTypeFollowNavigation)
                .Include(x => x.MilestonesProject)
                    .ThenInclude(x => x.IdMilestonesNavigation)
                .Include(x => x.MilestonesProject)
                    .ThenInclude(x => x.IdMilestonesNavigation.MilestonesTypeMilestones)
                    .ThenInclude(x => x.IdTypeMilestonesNavigation)
                .Where(x => x.IdProject == id)
                .Select(x => x.ToProjectDetailDTO()).ToList();

            var response = new ProjectDetailResponse
            {
                Projects = projects
            };

            return response;
        }

        [HttpGet("GetCountProjects")]
        public ProjectCountResponse GetCountProjects()
        {
            var result = _context.Project.ToList();

            var response = new ProjectCountResponse()
            {
                Projects = result
            };

            return response;
        }
    }
}