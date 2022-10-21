using Microsoft.EntityFrameworkCore;

namespace PlayersAPI.Context
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {

        }
        public DbSet<PlayersAPI.Models.Player> Player { get; set; }

    }
}
