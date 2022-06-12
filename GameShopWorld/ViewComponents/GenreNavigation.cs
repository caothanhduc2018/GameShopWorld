using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameShopWorld.Models;
namespace GameShopWorld.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private IGameShopWorldRepository repository;
        public GenreNavigation(IGameShopWorldRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.Games
            .Select(x => x.Genre)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
