using MasterShop.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterShop.Web.Extensions
{
    public class RolesExtensionsConfiguration
    {
        private readonly IApplicationBuilder app;
        private readonly MasterShopDbContext db;

        public RolesExtensionsConfiguration(IApplicationBuilder app, MasterShopDbContext db)
        {
            this.app = app;
            this.db = db;
        }

        private async void AddRoles()
        {
            if (this.db.Roles.Any())
            {
                return;
            }

            var serviceScope = this.app.ApplicationServices.CreateScope();

            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
        }

        public async Task CreateRoles()
        {
            Task.Run(AddRoles).Wait();
        }
    }
}
