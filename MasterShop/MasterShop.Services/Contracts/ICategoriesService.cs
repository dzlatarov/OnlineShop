using MasterShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterShop.Services.Contracts
{
    public interface ICategoriesService
    {
        IQueryable<Category> GetAllCategory();
        Category GetCategoryById(string id);
        void Insert(Category category);
        void Update(Category category);
        void Delete(Category category);
        void Save();
    }
}
