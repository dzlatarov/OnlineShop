using MasterShop.Data;
using MasterShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterShop.Web.Extensions
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+";
                options.User.RequireUniqueEmail = true;
            })
                .AddDefaultUI()
               .AddRoles<IdentityRole>()
               .AddRoleManager<RoleManager<IdentityRole>>()
               .AddDefaultTokenProviders()
               .AddEntityFrameworkStores<MasterShopDbContext>();

            return services;
        }
    }
}
