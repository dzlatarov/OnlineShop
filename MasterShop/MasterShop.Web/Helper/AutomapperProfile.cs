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
            CreateMap<Product, DetailsProductViewModel>()
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(crc => crc.CategoryProducts.Select(n => n.Category)));
            CreateMap<CreatePostProductViewModel, Product>();
            CreateMap<Product, DeleteProductViewModel>().ReverseMap();
            CreateMap<EditPostProductViewModel, Product>().ReverseMap();
        }
    }
}
