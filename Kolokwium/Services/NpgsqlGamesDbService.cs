using Kolokwium.Models;
using System.Collections.Generic;
using System.Linq;

namespace Kolokwium.Services
{
    public class NpgsqlGamesDbService : IGamesDbService
    {
        private readonly GamesDbContext _dbContext;

        public NpgsqlGamesDbService(GamesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Championship GetChampionship(int IdChampionship)
        {
            return _dbContext.Championships
                .Where(c => c.IdChamptionship == IdChampionship)
                .FirstOrDefault();
        }

        public IEnumerable<ChampionshipTeam> GetChamptionShipTeams(int IdChampionship)
        {
            return _dbContext.ChamptionshipTeams
                .Where(cp => cp.IdChampionship == IdChampionship)
                .OrderBy(cp => cp.Score)
                .Select(cp => cp);
        }
    }
}
