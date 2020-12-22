using AutoMapper;
using MasterShop.Models;
using MasterShop.Services.Contracts;
using MasterShop.Web.Helper;
using MasterShop.Web.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ICategoriesService categoriesService;
        private readonly IWebHostEnvironment env;

        public ProductsController(IProductsService productsService, IMapper mapper, ICategoriesService categoriesService, IWebHostEnvironment env)
        {
            this.productsService = productsService;
            this.mapper = mapper;
            this.categoriesService = categoriesService;
            this.env = env;
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
            CreateProductViewModel model = new CreateProductViewModel();
            model.Categories = this.categoriesService.GetAllCategory().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id
            }).ToList();
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel model)
        {
            var fileUpload = new FileUpload(env);
            var selectedCategories = model.Categories.Where(x => x.Selected).Select(x => x.Value).ToList();
            var imageFile = fileUpload.UploadFile(model.ProductImage);
            var product = new CreatePostProductViewModel
            {
                Name = model.Name,
                Description = model.Description,
                SKU = model.SKU,
                Price = model.Price,
                ProductImage = imageFile
            };
            var mappedProductFromModel = this.mapper.Map<Product>(product);
            this.productsService.Insert(mappedProductFromModel, selectedCategories);
            this.productsService.Save();

            return this.RedirectToAction("Index", "Products");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string id)
        {
            var product = this.productsService.GetProductById(id);
            var model = new EditProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                SKU = product.SKU,
                Price = product.Price
            };
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel model)
        {
            var fileUpload = new FileUpload(env);
            var imageFile = fileUpload.UploadFile(model.ProductImage);
            var editedProduct = new EditPostProductViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                SKU = model.SKU,
                Price = model.Price,
                ProductImage = imageFile
            };
            var mappedProduct = this.mapper.Map<Product>(editedProduct);
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
