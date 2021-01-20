using AutoMapper;
using MasterShop.Data;
using MasterShop.Models;
using MasterShop.Services.Contracts;
using MasterShop.Web.Helper;
using MasterShop.Web.Models.Orders;
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
        private readonly IUsersService usersService;

        public OrdersController(IOrdersService ordersService, IProductsService productsService, IMapper mapper, IUsersService usersService)
        {
            this.ordersService = ordersService;
            this.productsService = productsService;
            this.mapper = mapper;
            this.usersService = usersService;
        }

        [HttpGet]
        public IActionResult Create(CreateUnloggedUserOrderViewModel model)
        {
            var cart = this.mapper.Map<List<Product>>(SessionHelper.GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, "cart"));
            var userId = GetUserId();

            if (userId == null)
            {
                //When the user is not logged in he will need to add additional information for the order. 
                var user = this.mapper.Map<ApplicationUser>(model);
                this.usersService.CreateUser(user);
                this.usersService.Save();

                this.CreateOrder(cart, user.Id);
            }
            else
            {
                //When the user is logged in he wont need to write additional information like name address.  
                this.CreateOrder(cart, userId);
            }

            return this.RedirectToAction("Index", "ShoppingCart");
        }

        private string GetUserId()
        {
            return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private void CreateOrder(List<Product> products, string userId)
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
