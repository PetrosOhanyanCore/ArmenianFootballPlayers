namespace ArmenianFootballPlayers.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Number { get; set; }
        public bool? IsPlaying { get; set; }
        public string? Club { get; set; }
        public string? Image { get; set; }
    }
}
