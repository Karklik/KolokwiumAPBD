using System.Collections.Generic;

namespace Kolokwium.Models
{
    public class Championship
    {
        public int IdChamptionship { get; set; }
        public string OfficialName { get; set; }
        public int Year { get; set; }
        public virtual ICollection<ChampionshipTeam> ChamptionshipTeams { get; set; }
    }
}
