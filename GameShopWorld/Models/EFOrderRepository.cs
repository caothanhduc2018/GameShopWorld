using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace GameShopWorld.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private GameShopWorldDbContext context;
        public EFOrderRepository(GameShopWorldDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Game);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Game));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
