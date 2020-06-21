using Kolokwium.DTOs.Requests;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IGamesDbService _dbService;
        public TeamsController(IGamesDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost("{id}/players")
        public IActionResult AddPlayer(AddPlayerRequest request)
        {
            return Ok();
        } 
    }
}