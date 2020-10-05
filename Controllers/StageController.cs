using Microsoft.AspNetCore.Mvc;
using ProjectRadiator.Models;
using ProjectRadiator.Models.Responses.Stages;
using ProjectRadiator.Utilis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageController : ControllerBase
    {
        private readonly ProjectRadiatorContext _context;

        public StageController(ProjectRadiatorContext context)
        {
            _context = context;
        }

        [HttpGet("GetStageTypes")]
        public StageTypesResponse GetStageTypes()
        {
            var response = new StageTypesResponse();
            response.StageTypes = _context.TypeStages.Select(x => x.ToStageTypesDTO()).ToList();

            return response;
        }
    }
}
