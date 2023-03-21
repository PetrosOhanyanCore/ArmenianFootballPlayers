namespace ArmenianFootballPlayers.Models
{
    public class OrderFilterPagination
    {
        public int ItemInPage { get; set; } = 5;
        public int PageNumber { get; set; } = 1;

        public string? SortString { get; set; }

        public string? SearchByName { get; set; } = null;
        public string? SearchBySurName { get; set; } = null;
        public int? SearchByNumber { get; set; } = null;
        public bool? SearchByIsPlaying { get; set; } = null;
        public string? SearchByClub { get; set; } = null;
    }
}
