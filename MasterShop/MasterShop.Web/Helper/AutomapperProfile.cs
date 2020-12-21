using AutoMapper;
using MasterShop.Models;
using MasterShop.Web.Models.Categories;
using MasterShop.Web.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterShop.Web.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Category, CategoryIndexViewModel>();
            CreateMap<Category, DetailsCategoryViewModel>();
            CreateMap<Category, DeleteCategoryViewModel>().ReverseMap();
            CreateMap<Category, EditCategoryViewModel>().ReverseMap();
            CreateMap<CreateCategoryViewModel, Category>();
            CreateMap<Product, ProductIndexViewModel>();
            CreateMap<Product, EditProductViewModel>().ReverseMap();
            CreateMap<Product, DetailsProductViewModel>();
            CreateMap<Product, DeleteProductViewModel>().ReverseMap();
            CreateMap<CreateProductViewModel, Product>();
        }
    }
}
