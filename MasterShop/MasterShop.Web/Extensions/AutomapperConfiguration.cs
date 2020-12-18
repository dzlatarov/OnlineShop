using AutoMapper;
using MasterShop.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterShop.Web.Extensions
{
    public static class AutomapperConfiguration
    {
        public static IMapper CreateMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutomapperProfile());
            });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
