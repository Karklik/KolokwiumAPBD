using System.Collections.Generic;

namespace Kolokwium.Models
{
    public class Team
    {
        public int IdTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }
        public virtual ICollection<PlayerTeam> PlayerTeams { get; set; }
        public virtual ICollection<ChampionshipTeam> ChamptionshipTeams { get; set; }
    }
}
