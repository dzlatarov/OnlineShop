using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterShop.Web.Extensions
{
    public static class ConnectionStringConfiguration
    {
        public static string GetDefaultConnection(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");
    }
}
