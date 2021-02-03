using AutoMapper;
using MasterShop.Models;
using MasterShop.Services.Models.Users;
using MasterShop.Web.Models.Categories;
using MasterShop.Web.Models.Orders;
using MasterShop.Web.Models.Products;
using MasterShop.Web.Models.ShoppingCart;
using MasterShop.Web.Models.Users;
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
            // Category
            CreateMap<Category, CategoryIndexViewModel>();
            CreateMap<Category, DetailsCategoryViewModel>();
            CreateMap<Category, DeleteCategoryViewModel>().ReverseMap();
            CreateMap<Category, EditCategoryViewModel>().ReverseMap();
            CreateMap<CreateCategoryViewModel, Category>();

            // Product
            CreateMap<Product, ProductIndexViewModel>();
            CreateMap<Product, DetailsProductViewModel>()
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(crc => crc.CategoryProducts.Select(n => n.Category)));
            CreateMap<CreatePostProductViewModel, Product>();
            CreateMap<Product, DeleteProductViewModel>().ReverseMap();
            CreateMap<EditPostProductViewModel, Product>().ReverseMap();
            CreateMap<Product, ShoppingCartProductViewModel>().ReverseMap();

            // User
            CreateMap<ApplicationUser, CreateUnloggedUserOrderViewModel>().ReverseMap();
            CreateMap<ApplicationUser, UsersProfileViewModel>().ReverseMap();
            CreateMap<UsersEditViewModel, UsersUpdateDto>();
        }
    }
}
