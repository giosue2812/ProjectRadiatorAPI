using Microsoft.AspNetCore.Mvc;
using ProjectRadiator.Models;
using ProjectRadiator.Models.Responses;
using ProjectRadiator.Utilis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectRadiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController:ControllerBase
    {
        private readonly ProjectRadiatorContext _context;

        public FollowController(ProjectRadiatorContext context)
        {
            _context = context;
        }

        [HttpGet("GetTypeFollow")]
        public TypeFollowResponse GetFollowType()
        {
            var response = new TypeFollowResponse();
            response.TypeFollows = _context.TypeFollow.Select(x => x.ToTypeFollowsDTO()).ToList();
            return response;
        }
    }
}
