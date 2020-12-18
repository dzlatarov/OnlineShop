using AutoMapper;
using MasterShop.Models;
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

        [HttpGet]
        public IActionResult Index()
        {
            var allProducts = this.productsService.GetAllProducts().ToList();
            var mappedProduct = this.mapper.Map<List<ProductIndexViewModel>>(allProducts);
            return this.View(mappedProduct);
        }       

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var mappedProductFromModel = this.mapper.Map<Product>(model);
            this.productsService.Insert(mappedProductFromModel);
            this.productsService.Save();

            return this.RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var product = this.productsService.GetProductById(id);
            var mappedProduct = this.mapper.Map<EditProductViewModel>(product);
            return this.View(mappedProduct);
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel model)
        {
            var mappedProduct = this.mapper.Map<Product>(model);
            this.productsService.Update(mappedProduct);
            this.productsService.Save();
            return this.Redirect($"/Products/Details/{mappedProduct.Id}");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var product = this.productsService.GetProductById(id);
            var mappedProduct = this.mapper.Map<DetailsProductViewModel>(product);
            return this.View(mappedProduct);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var product = this.productsService.GetProductById(id);
            var mappedProduct = this.mapper.Map<DeleteProductViewModel>(product);
            return this.View(mappedProduct);
        }

        [HttpPost]
        public IActionResult Delete(DeleteProductViewModel model)
        {
            var mappedProductFromModel = this.mapper.Map<Product>(model);
            productsService.Delete(mappedProductFromModel);
            productsService.Save();
            return this.RedirectToAction("Index", "Products");
        }
    }
}
