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

            //When the user is not logged in he will need to add additional information for the order.
            if (!this.User.Identity.IsAuthenticated)
            {
                //Todo...
            }
            //When the user is logged in he wont need to write additional information like name address.
            this.CreateOrderLoggedUser(cart, userId);
            return this.RedirectToAction("Index", "ShoppingCart");
        }

        private string GetUserId()
        {
            return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private void CreateOrderLoggedUser(List<Product> products, string userId)
        {
            var order = new Order
            {
                DateOfCreation = DateTime.Now,
                UserId = userId
            };

            this.ordersService.CreateOrder(order, products);
            this.ordersService.Save();

            //foreach (var product in products)
            //{
            //    product.OrderId = order.Id;
            //    this.productsService.Update(product);
            //    this.productsService.Save();
            //}
            //order.Products = products;
            products.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", products);
        }
    }
}
