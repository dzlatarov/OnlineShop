using AutoMapper;
using MasterShop.Services.Contracts;
using MasterShop.Web.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly IMapper mapper;

        public ProductsController(IProductsService productsService, IMapper mapper)
        {
            this.productsService = productsService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var allProducts = this.productsService.GetAllProducts().ToList();
            var mappedProduct = this.mapper.Map<List<ProductIndexViewModel>>(allProducts);
            return this.View(mappedProduct);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        public IActionResult Edit()
        {
            return this.View();
        }

        public IActionResult Details()
        {
            return this.View();
        }

        public IActionResult Delete()
        {
            return this.View();
        }
    }
}
