using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectRadiator.DTO;
using ProjectRadiator.DTO.Projects;
using ProjectRadiator.Models;
using ProjectRadiator.Models.Responses;
using ProjectRadiator.Utilis;
using System;
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
        [HttpGet("GetShortProjects")]
        //This action return a short list of project
        public ProjectShortResponse GetShortProjects()
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
        public ActionResult<ProjectDetailResponse> PutProjectDetail(int id, ProjectDetailDTO projectDetail)
        {

            var findProject = _context.Project
                    .Include(x => x.IdSocietyNavigation)
                    .Where(x => x.IdProject == id).FirstOrDefault();

            findProject.Title = projectDetail.Titre;
            findProject.IdSocietyNavigation.Name = projectDetail.Society;
            findProject.Description = projectDetail.Description;
            projectDetail.StartDate = findProject.CreationDate;
            findProject.ProjectStage.FirstOrDefault().IdStageNavigation.StagesTypeStages.FirstOrDefault().IdTypeStagesNavigation.TypeStages1 = projectDetail.TypeStages;
            findProject.Follow.FirstOrDefault().FollowTypeFollow.FirstOrDefault().IdTypeFollowNavigation.Label = projectDetail.TypeFollows.FirstOrDefault().FirstOrDefault().Label;
            findProject.MilestonesProject.FirstOrDefault().IdMilestonesNavigation.DateMilestones = projectDetail.MillestoneDate.FirstOrDefault().Date;
            findProject.MilestonesProject.FirstOrDefault().IdMilestonesNavigation.MilestonesTypeMilestones.FirstOrDefault().IdTypeMilestonesNavigation.TypeMilestones = projectDetail.MilestonesTypes.FirstOrDefault().FirstOrDefault();

            try
            {
                _context.SaveChanges();
                return CreatedAtAction("GetProject", new { id = findProject.IdProject }, projectDetail);
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