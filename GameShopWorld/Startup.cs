using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameShopWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShopWorld
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<GameShopWorldDbContext>(opts => {
                opts.UseSqlServer(
                Configuration["ConnectionStrings:GameShopWorldConnection"]);
            });
                services.AddScoped<IGameShopWorldRepository,EFGameShopWorldRepository>();
                services.AddScoped<IOrderRepository, EFOrderRepository>();
                services.AddRazorPages();
                services.AddDistributedMemoryCache();
                services.AddSession();
                services.AddScoped<MyCart>(sp => MySessionCart.GetCart(sp));
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                services.AddServerSideBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();
            // old URL: http://localhost:44333/?bookPage=2
            // new URL: https://localhost:44333/Books/2

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("genpage",
                "{genre}/{gamePage:int}",
                new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("page", "{gamePage:int}",
                new { Controller = "Home", action = "Index", gamePage = 1 });
                endpoints.MapControllerRoute("genre", "{genre}",
                new { Controller = "Home", action = "Index", gamePage = 1 });
                endpoints.MapControllerRoute("pagination",
                "Games/{gamePage}", new { Controller = "Home", action = "Index", gamePage = 1 });
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}","/Admin/Index");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}