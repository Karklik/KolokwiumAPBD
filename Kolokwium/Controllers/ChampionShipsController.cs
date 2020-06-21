using Kolokwium.DTOs.Responses;
using Kolokwium.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipsController : ControllerBase
    {
        private readonly IGamesDbService _dbService;

        public ChampionshipsController(IGamesDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}/teams")]
        public IActionResult GetChamptionshipTeams(int id)
        {
            if (_dbService.GetChampionship(id) == null)
                return NotFound("Championship dosen't exists");

            var championshipTeams = _dbService.GetChamptionShipTeams(id);

            return Ok(championshipTeams.Select(ct => new GetChamptionshipTeamsResponse
            { 
                Team = ct.Team,
                Score = ct.Score
            }).ToList());
        }

    }
}