using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectRadiator.Models;
using ProjectRadiator.Models.Responses;
using ProjectRadiator.Utilis;

namespace ProjectRadiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocietyController : ControllerBase
    {
        private readonly ProjectRadiatorContext _context;
          
        public SocietyController(ProjectRadiatorContext context)
        {
            _context = context;
        }

        [HttpGet("GetShortSocieties")]
        public SocietyShortResponse GetShortSocieties()
        {
            var response = new SocietyShortResponse();
            response.Societies = _context.Society
                .Include(x => x.IdSocietyNavigation)
                .Include(x => x.People)
                .Where(x => x.Name != "Bstorm")
                .Select(x => x.ToSocietyShortDTO())
                .ToList();

            return response;
        }
    }
}
