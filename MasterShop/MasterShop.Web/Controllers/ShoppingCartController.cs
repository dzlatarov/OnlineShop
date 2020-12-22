using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
           return this.View();
        }
    }
}
