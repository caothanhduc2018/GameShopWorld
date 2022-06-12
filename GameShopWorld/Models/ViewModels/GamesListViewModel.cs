using System.Collections.Generic;
namespace GameShopWorld.Models.ViewModels
{
    public class GamesListViewModel
    {
        public IEnumerable<Game> Games { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentGenre { get; set; }
    }
}
