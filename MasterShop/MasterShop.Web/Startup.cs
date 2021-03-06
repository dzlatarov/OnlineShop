using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MasterShop.Data;
using MasterShop.Models;
using MasterShop.Services;
using MasterShop.Services.Contracts;
using MasterShop.Web.Helper;
using MasterShop.Web.Extensions;
using MasterShop.Infrastructure;

namespace MasterShop.Web
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
            services.ConfigureApplicationCookie()
                .ConfigureCookiePolicy();
            services.AddDistributedMemoryCache();
            services.AddSessionConfig();

            services.AddDbContextPool<MasterShopDbContext>(options => options.UseSqlServer(Configuration.GetDefaultConnection()))
                .AddIdentity()
                .AddControllersWithViews();

            services.AddRazorPages();

            services.AddTransient<MasterShopDbContext>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddSingleton(AutomapperConfiguration.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MasterShopDbContext db)
        {
            var rolesConfig = new RolesExtensionsConfiguration(app, db);
            rolesConfig.CreateRoles().Wait();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler(GlobalConstants.ExeptionHandlerErr);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: GlobalConstants.Name,
                    pattern: GlobalConstants.Pattern);
                endpoints.MapRazorPages();
            });

        }
    }
}
