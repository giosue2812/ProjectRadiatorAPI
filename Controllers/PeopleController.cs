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
            var response = new PeopleClientShortResponse();

            response.Peoples = _context.People
                .Include(x => x.PeopleJob)
                    .ThenInclude(x => x.IdJobNavigation)
                .Include(x => x.IdSocietyNavigation)
                .Where(x => x.IdSocietyNavigation.Name != "Bstorm")
                .Select(x => x.ToClientShortDTO()).ToList();

            return response;
        }

        [HttpGet("GetPeoplesTeams")]
        public PeopleTeamsShortResponse GetPeopleTeams()
        {
            var response = new PeopleTeamsShortResponse();
            response.TeamsBstorm = _context.People
                .Include(x => x.IdSocietyNavigation)
                .Include(x => x.PeopleJob)
                    .ThenInclude(x => x.IdJobNavigation)
                .Where(x => x.IdSocietyNavigation.Name == "Bstorm")
                .Select(x => x.ToTeamsBstormShortDTO()).ToList();

            return response;
        }
        [HttpGet("GetPeoplesDetails/{id}")]
        public PeopleClientDetailsResponse GetPeopleClientDetails(int Id)
        {
            var response = new PeopleClientDetailsResponse();
            response.Client = _context.People
                .Include(x => x.IdPeopleNavigation)
                .Include(x => x.PeopleJob)
                    .ThenInclude(x => x.IdJobNavigation)
                .Include(x => x.IdSocietyNavigation)
                .Where(x => x.IdPeople == Id)
                .Select(x => x.ToClientDetailsDTO())
                .ToList();
            return response;
        }
    }
}
