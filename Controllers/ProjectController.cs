using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectRadiator.DTO;
using ProjectRadiator.DTO.Projects;
using ProjectRadiator.Models;
using ProjectRadiator.Models.Responses;
using ProjectRadiator.Utilis;
using System;
using System.Collections.Generic;
using System.Globalization;
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


        //GET:api/project/GetShortProjects
        [HttpGet("GetShortProjects/{email}")]
        //This action return a short list of project
        public ProjectShortResponse GetShortProjects(string email)
        {
            var response = new ProjectShortResponse();
            response.Projects = _context.Project
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
                    .Where(x => x.ProjectPeople.Any(x => x.IdPeopleNavigation.IdPeopleNavigation.Email == email))
                .Select(x => x.ToProjectShortDTO())
                .ToList();

            return response;
        }

        //GET:api/Project/GetPartilListProject
        [HttpGet("GetPartialListProject")]
        //This action return a list of partial projects
        public ProjectPartialListResponse GetListPartialListProjects()
        {
            var response = new ProjectPartialListResponse();
            response.Projects = _context.Project
                .Include(x => x.IdSocietyNavigation)
                .Select(x => x.ToProjectPartialListDTO()).ToList();
            return response;

        }

        [HttpGet("GetProject/{id}")]
        public ProjectDetailResponse GetProject(int id)
        {
            var response = new ProjectDetailResponse();
            response.Projects = _context.Project
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

            return response;
        }

        [HttpGet("GetCountProjects")]
        public ProjectCountResponse GetCountProjects()
        {
            var response = new ProjectCountResponse();
            response.Projects = _context.Project.ToList();

            return response;
        }

        [HttpPost("PostNewProject")]
        public async Task<ActionResult<ProjectDetailResponse>> PostProjectDetail(Project project)
        {
            try
            {
                _context.Project.Add(project);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetProject", new { id = project.IdProject }, project);
            }
            catch
            {
                return new ProjectDetailResponse
                {
                    IsSucess = false,
                    Status = 500,
                    ErrorMessage = "Error rise. Please contact the administrator."
                };
            }
        }

        [HttpPut("PutProject/{id}")]
        public async Task<ActionResult<ProjectDetailResponse>> PutProjectDetail(int id,ProjectUpdateDTO projectUpdate)
        {

            var findTypeMilestone = _context.MilestonesType.Find(projectUpdate.MilestonesType.IdTypeMilestones);
            var findTypeFollow = _context.TypeFollow.Find(projectUpdate.IdTypeFollow);

            var findProject = _context.Project
                    .Include(x => x.IdSocietyNavigation)
                    .Include(x => x.MilestonesProject)
                        .ThenInclude(x => x.IdMilestonesNavigation)
                    .Include(x => x.Follow)
                        .ThenInclude(x => x.FollowTypeFollow)
                        .ThenInclude(x => x.IdTypeFollowNavigation)
                    .Include(x => x.ProjectStage)
                        .ThenInclude(x => x.IdStageNavigation.StagesTypeStages)
                        .ThenInclude(x => x.IdTypeStagesNavigation.StagesTypeStages)
                        .ThenInclude(x => x.IdTypeStagesNavigation)
                    .Include(x => x.ProjectPeople)
                    .Where(x => x.IdProject == id).FirstOrDefault();

            findProject.Title = projectUpdate.Title;
            findProject.Description = projectUpdate.Description;
            findProject.StartDate = projectUpdate.StartDate;
            findProject.ProjectStage.FirstOrDefault().IdStageNavigation.StagesTypeStages.IdTypeStages = projectUpdate.TypeStages.IdStages;

            var mile = _context.Milestones.Add(new Milestones
            {
                CreationDate = DateTime.Now,
                DateMilestones = projectUpdate.DateMilestones,
            });
            mile.Entity.MilestonesProject.Add(new MilestonesProject
            {
                IdMilestones = mile.Entity.IdMilestones,
                IdProject = findProject.IdProject
            });
            mile.Entity.MilestonesTypeMilestones.Add(new MilestonesTypeMilestones
            {
                IdMilestones = mile.Entity.IdMilestones,
                IdTypeMilestones = findTypeMilestone.IdTypeMilestones

            });

            var follow = _context.Follow.Add(new Follow
            {
                CommentDev = projectUpdate.CommentDev,
                DateFollow = DateTime.Now,
                IdProject = findProject.IdProject
            });
            follow.Entity.FollowPeople.Add(new FollowPeople
            {
                CreationDate = DateTime.Now,
                IdFollow = follow.Entity.IdFollow,
                IdPeople = findProject.ProjectPeople.FirstOrDefault().IdPeople
            });
            follow.Entity.FollowTypeFollow.Add(new FollowTypeFollow
            {
                IdFollow = follow.Entity.IdFollow,
                IdTypeFollow = findTypeFollow.IdTypeFollow
            });

            _context.Follow.Add(follow.Entity);
            _context.Milestones.Add(mile.Entity);

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetProject", new { id = findProject.IdProject }, projectUpdate);
            }
            catch
            {
                return new ProjectDetailResponse
                {
                    Status = 500,
                    IsSucess = false,
                    ErrorMessage = "error rise. please contact the administrator"
                };
            }
        }
    }
} 