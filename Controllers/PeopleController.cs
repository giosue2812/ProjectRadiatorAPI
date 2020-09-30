using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectRadiator.DTO;
using ProjectRadiator.Models;
using ProjectRadiator.Models.Responses;
using ProjectRadiator.Utilis;

namespace ProjectRadiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly ProjectRadiatorContext _context;

        public PeopleController(ProjectRadiatorContext context)
        {
            _context = context;
        }

        [HttpGet("GetPeoplesClient")]
        public PeopleClientShortResponse GetPeoplesClient()
        {
            var peoples = _context.People
                .Include(x => x.PeopleJob)
                    .ThenInclude(x => x.IdJobNavigation)
                .Include(x => x.IdSocietyNavigation)
                .Where(x => x.IdSocietyNavigation.Name != "Bstorm")
                .Select(x => x.ToClientShortDTO()).ToList();

            var response = new PeopleClientShortResponse
            {
                Peoples = peoples
            };

            return response;
        }

        [HttpGet("GetPeoplesTeams")]
        public PeopleTeamsShortResponse GetPeopleTeams()
        {
            var peoples = _context.People
                .Include(x => x.IdSocietyNavigation)
                .Include(x => x.PeopleJob)
                    .ThenInclude(x => x.IdJobNavigation)
                .Where(x => x.IdSocietyNavigation.Name == "Bstorm")
                .Select(x => x.ToTeamsBstormShortDTO()).ToList();

            var response = new PeopleTeamsShortResponse
            {
                TeamsBstorm = peoples
            };
            return response;
        }
    }
}
