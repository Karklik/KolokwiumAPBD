namespace Kolokwium.Models
{
    public class ChampionshipTeam
    {
        public int IdTeam { get; set; }
        public int IdChampionship { get; set; }
        public float Score { get; set; }
        public virtual Team Team { get; set; }
        public virtual Championship Championship { get; set; }
    }
}
