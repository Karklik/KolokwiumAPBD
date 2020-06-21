namespace Kolokwium.Models
{
    public class PlayerTeam
    {
        public int IdPlayer { get; set; }
        public int IdTeam { get; set; }
        public int NumOnShirt { get; set; }
        public string Comment { get; set; }
        public virtual Player Player { get; set; }
        public virtual Team Team { get; set; }
    }
}
