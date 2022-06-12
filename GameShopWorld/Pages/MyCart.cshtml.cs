using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GameShopWorld.MyTagHelper;
using GameShopWorld.Models;
using System.Linq;
namespace GameShopWorld.Pages
{
    public class MyCartModel : PageModel
    {
        private IGameShopWorldRepository repository;
        public MyCartModel(IGameShopWorldRepository repo, MyCart myCartService)
        {
            repository = repo;
            myCart = myCartService;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long gameId, string returnUrl)
        {
            Game game = repository.Games
            .FirstOrDefault(b => b.GameID == gameId);
            myCart.AddItem(game, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long gameId, string returnUrl)
        {
            myCart.RemoveLine(myCart.Lines.First(cl =>
            cl.Game.GameID == gameId).Game);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
