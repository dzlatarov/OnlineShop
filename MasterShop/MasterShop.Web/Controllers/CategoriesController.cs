using AutoMapper;
using MasterShop.Models;
using MasterShop.Services.Contracts;
using MasterShop.Web.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterShop.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IMapper mapper;

        public CategoriesController(ICategoriesService categoriesService, IMapper mapper)
        {
            this.categoriesService = categoriesService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = this.categoriesService.GetAllCategory().ToList();
            var mappedCategories = this.mapper.Map<List<CategoryIndexViewModel>>(categories);

            return this.View(mappedCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var categoryFromModel = this.mapper.Map<Category>(model);
            this.categoriesService.Insert(categoryFromModel);
            this.categoriesService.Save();

            return this.RedirectToAction("Index", "Categories");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var category = this.categoriesService.GetCategoryById(id);
            var mappedCategory = this.mapper.Map<EditCategoryViewModel>(category);
            return this.View(mappedCategory);
        }

        [HttpPost]
        public IActionResult Edit(EditCategoryViewModel model)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var categoryFromModel = this.mapper.Map<Category>(model);
            this.categoriesService.Update(categoryFromModel);
            this.categoriesService.Save();
            return this.RedirectToAction("Index", "Categories");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var category = this.categoriesService.GetCategoryById(id);
            var mappedCategory = this.mapper.Map<DetailsCategoryViewModel>(category);
            return this.View(mappedCategory);
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var category = this.categoriesService.GetCategoryById(id);
            var mappedCategory = this.mapper.Map<DeleteCategoryViewModel>(category);
            return this.View(mappedCategory);
        }

        [HttpPost]
        public IActionResult Delete(DeleteCategoryViewModel model)
        {
            var mappedCategoryFromModel = this.mapper.Map<Category>(model);
            this.categoriesService.Delete(mappedCategoryFromModel);
            this.categoriesService.Save();
            return this.RedirectToAction("Index", "Categories");
        }
    }
}
