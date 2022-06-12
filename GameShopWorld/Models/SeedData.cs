using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace GameShopWorld.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            GameShopWorldDbContext context =
    app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService < 
    GameShopWorldDbContext > ();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Games.Any())
            {
                context.Games.AddRange(
                new Game
                {
                    Title = "Dying Light 2",
                    Description = "nhân vật chính Kyle Crane đã tạm thời cứu được thành phố Harran khỏi bị quân đội tiêu diệt và vạch mặt bọn tập đoàn GRE xấu xa định trục lợi từ loại virus chết người gây ra đại dịch xác sống",
                    Genre = "Sinh Tồn",
                    Price = 50.99m
                },
                new Game
                {
                    Title = "How to Win Friends & Influence People",
                    Description = "Câu chuyện của trò chơi bắt đầu với ba nhân vật Valkyries đang huấn luyện (Kiana Kaslana, Mei Raiden và Bronya Zaychik) lên chiếc Selene, một tàu chiến bay của địch.",
                    Genre = "Cốt Truyện",
                    Price = 70.99m
                },
                new Game
                {
                    Title = "Genshin Impact",
                    Description = "What the Rich Teach Their Kids Ab Money That the Poor and Middle Class Do Not!",
                    Genre = "Tự Do",
                    Price = 40.41m
                },
                new Game
                {
                    Title = "Elden Ring",
                    Description = "một hành trình đặc biệt đưa bạn từ một kẻ lưu đày vô danh thành một vị chúa tể hùng mạnh của cả vương quốc",
                    Genre = "Khám Phá",
                    Price = 18.69m
                },
                new Game
                {
                    Title = "Counter Side",
                    Description = "kể về cuộc chiến giữa loài người (Watch Counter) và những sinh vật ngoài hành tinh. Chúng muốn xâm chiếm địa cầu và hủy diệt thế giới loài người.",
                    Genre = "Đội Hình",
                    Price = 31.26m
                }
                ); context.SaveChanges();
            }
        }
    }
}
