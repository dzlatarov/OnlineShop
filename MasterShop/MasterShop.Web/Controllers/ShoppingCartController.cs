using AutoMapper;
using MasterShop.Models;
using MasterShop.Services.Contracts;
using MasterShop.Web.Helper;
using MasterShop.Web.Models.ShoppingCart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductsService productsService;

        public ShoppingCartController(IMapper mapper, IProductsService productsService)
        {
            this.mapper = mapper;
            this.productsService = productsService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var cartModel = SessionHelper.GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, "cart");
            var cart = this.mapper.Map<List<Product>>(cartModel);
            ViewBag.total = cart.Sum(p => p.Quantity * p.Price);
            return this.View(cartModel);
        }

        private int GetProductIndex(string id)
        {
            var cartModel = SessionHelper.GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, "cart");
            var cartProducts = this.mapper.Map<List<Product>>(cartModel);
            for (int i = 0; i < cartProducts.Count; i++)
            {
                if (cartProducts[i].Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult Buy(string id)
        {
            var cart = new List<ShoppingCartProductViewModel>();
            var product = this.productsService.GetProductById(id);
            var productModel = this.mapper.Map<ShoppingCartProductViewModel>(product);

            if (SessionHelper.GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, "cart") == null)
            {
                cart.Add(productModel);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cartModel = SessionHelper.GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, "cart");
                var index = this.GetProductIndex(id);
                if (index != -1)
                {
                    cartModel[index].Quantity++;
                }
                else
                {
                    cartModel.Add(productModel);
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cartModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Remove(string id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<ShoppingCartProductViewModel>>(HttpContext.Session, "cart");
            var index = this.GetProductIndex(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
    }
}
