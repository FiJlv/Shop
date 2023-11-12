using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Shop.DAL;
using System;
using Shop.DAL.Repository;
using Shop.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Shop.BLL.Services;
using Shop.BLL.Intefaces;
using Shop.BLL.Mapping;

namespace Shop
{
    public class Startup 
    {
        private IConfigurationRoot _confstring;

        [Obsolete]
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
           .AddEntityFrameworkStores<AppDBContext>()
           .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
            });

            services.AddScoped<UnitOfWork>();
            services.AddScoped<CarService>();
            services.AddScoped<AdminPanelService>();
            services.AddScoped<OrderService>();
            services.AddAutoMapper(typeof(AppMappingProfile));

            services.AddTransient<IFileService, FileService>();          

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCartService.GetCart(sp));

            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {  
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext content = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                DBObjects.Initial(content);
            }
        }
    }
}
