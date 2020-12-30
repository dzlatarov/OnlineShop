using AutoMapper;
using MasterShop.Models;
using MasterShop.Services.Contracts;
using MasterShop.Web.Helper;
using MasterShop.Web.Models.ShoppingCart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MasterShop.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;
        private readonly IProductsService productsService;
        private readonly IMapper mapper;

        public OrdersController(IOrdersService ordersService, IProductsService productsService, IMapper mapper)
        {
            this.ordersService = ordersService;
            this.productsService = productsService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var cart = this.mapper.Map<List<Product>>(SessionHelper.GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, "cart"));
            var userId = GetUserId();
            var order = new Order
            {
                DateOfCreation = DateTime.Now,
                UserId = userId
            };

            this.ordersService.CreateOrder(order);
            this.ordersService.Save();
            foreach (var product in cart)
            {
                product.OrderId = order.Id;
                this.productsService.Update(product);
                this.productsService.Save();
            }
            cart.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return this.RedirectToAction("Index", "ShoppingCart");
        }

        private string GetUserId()
        {
            return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
