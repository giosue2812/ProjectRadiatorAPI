using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class MettingController:ControllerBase
    {
        private readonly ProjectRadiatorContext _context;

        public MettingController(ProjectRadiatorContext context)
        {
            _context = context;
        }

        [HttpGet("GetMettings")]
        public MettingsResponse GetMettings()
        {
            var response = new MettingsResponse();
                response.Mettings = _context.Metting
                .Include(x => x.IdProjectNavigation)
                .Include(x => x.MettingPeople)
                    .ThenInclude(x => x.IdPeopleNavigation.IdPeopleNavigation)
                .Select(x => x.ToMettingListDTO()).ToList();

            return response;
        }
    }
}
