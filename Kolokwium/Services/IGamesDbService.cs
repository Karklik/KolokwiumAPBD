using Kolokwium.Models;
using System.Collections.Generic;

namespace Kolokwium.Services
{
    public interface IGamesDbService
    {
        public Championship GetChampionship(int IdChampionship);
        public IEnumerable<ChampionshipTeam> GetChamptionShipTeams(int IdChampionship);
    }
}
