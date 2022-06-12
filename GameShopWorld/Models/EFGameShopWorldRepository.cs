using System.Linq;
namespace GameShopWorld.Models
{
    public class EFGameShopWorldRepository : IGameShopWorldRepository
    {
        private GameShopWorldDbContext context;
        public EFGameShopWorldRepository(GameShopWorldDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Game> Games => context.Games;
        public void CreateGame(Game b)
        {
            context.Add(b);
            context.SaveChanges();
        }
        public void DeleteGame(Game b)
        {
            context.Remove(b); context.SaveChanges();
        }
        public void SaveGame(Game b)
        {
            context.SaveChanges();
        }
    }
}
