using Microsoft.EntityFrameworkCore;
namespace GameShopWorld.Models
{
    public class GameShopWorldDbContext : DbContext
    {
        public GameShopWorldDbContext(DbContextOptions<GameShopWorldDbContext>
        options) : base(options) { }
        public DbSet<Game> Games { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
