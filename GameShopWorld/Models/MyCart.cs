using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GameShopWorld.Models
{
    public class MyCart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Game game, int quantity)
        {
            CartLine line = Lines
            .Where(b => b.Game.GameID == game.GameID)
            .FirstOrDefault(); if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Game = game,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Game game) =>
        Lines.RemoveAll(l => l.Game.GameID == game.GameID);
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.Game.Price * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Game Game { get; set; }
        public int Quantity { get; set; }
    }
}
