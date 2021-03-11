using System;
using System.Collections.Generic;
using System.Text;

namespace MasterShop.Infrastructure
{
    public class GlobalConstants
    {
        // Roles
        public const string AdminRole = "Admin";
        public const string UserRole = "User";

        // Database connection
        public const string ConnectionName = "DefaultConnection";

        //Coockie paths
        public const string LoginPath = "/Identity/Account/Login";
        public const string LogoutPath = "/Identity/Account/Logout";
    }
}
