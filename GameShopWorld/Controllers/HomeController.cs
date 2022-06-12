using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GameShopWorld.Models;
using GameShopWorld.Models.ViewModels;

namespace GameShopWorld.Controllers
{

    //private readonly ILogger<HomeController> _logger;

    //public HomeController(ILogger<HomeController> logger)
    //{
    //    _logger = logger;
    //}

    //public IActionResult Index()
    //{
    //    return View();
    //}

    //public IActionResult Privacy()
    //{
    //    return View();
    //}

    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
    //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}
    public class HomeController : Controller
    {
        private IGameShopWorldRepository repository;
        public int PageSize = 3;
        public HomeController(IGameShopWorldRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(string genre, int gamePage = 1) 
            => View(new GamesListViewModel
        {
            Games = repository.Games
            .Where(p => genre == null || p.Genre == genre)
            .OrderBy(p => p.GameID)
            .Skip((gamePage - 1) * PageSize)
            .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = gamePage,
                ItemsPerPage = PageSize,
                TotalItems = genre == null ?
                repository.Games.Count() :
                repository.Games.Where(e =>
                e.Genre == genre).Count()
            },
            CurrentGenre = genre
        });
    }
}