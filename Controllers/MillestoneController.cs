using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectRadiator.Models;
using ProjectRadiator.Models.Responses.Millestones;
using ProjectRadiator.Utilis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MillestoneController:ControllerBase
    {
        private readonly ProjectRadiatorContext _context;

        public MillestoneController(ProjectRadiatorContext context)
        {
            _context = context;
        }

        [HttpGet("GetMillestonesProject")]
        public MilestoneProjectResponse GetMilestonesProject()
        {
            var response = new MilestoneProjectResponse();

            response.Millestones = _context.Milestones
                    .Include(x => x.MilestonesProject)
                        .ThenInclude(x => x.IdProjectNavigation)
                    .Include(x => x.MilestonesTypeMilestones)
                        .ThenInclude(x => x.IdTypeMilestonesNavigation)
                    .Select(x => x.ToMilestonesProjectListDTO()).ToList();
            return response;
        }

        [HttpGet("GetMilestoneTypes")]
        public MilestoneTypesResponse GetMilestoneTypes()
        {
            var response = new MilestoneTypesResponse();

            response.MilestoneTypes = _context.MilestonesType
                .Select(x => x.ToMilestonesTypeDTO())
                .ToList();

            return response;
        }
    }
}
