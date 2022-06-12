using System.Linq;
using System.Linq;
namespace GameShopWorld.Models
{
    public interface IGameShopWorldRepository
    {
        IQueryable<Game> Games { get; }
        void SaveGame(Game b);
        void CreateGame(Game b);
        void DeleteGame(Game b);
    }
}