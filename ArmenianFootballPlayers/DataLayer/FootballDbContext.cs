using ArmenianFootballPlayers.Models;
using Microsoft.EntityFrameworkCore;

namespace ArmenianFootballPlayers.DataLayer
{
    public class FootballDbContext : DbContext
    {
        public FootballDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
    }
}
