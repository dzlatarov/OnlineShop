using MasterShop.Data;
using MasterShop.Models;
using MasterShop.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterShop.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly MasterShopDbContext db;

        public CategoriesService(MasterShopDbContext db)
        {
            this.db = db;
        }
        public void Delete(Category category)
        {
            db.Categories.Remove(category);
        }

        public IQueryable<Category> GetAllCategory()
        {
            return db.Categories;
        }

        public Category GetCategoryById(string id)
        {
            return db.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Insert(Category category)
        {
            db.Categories.Add(category);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Category category)
        {
            db.Categories.Update(category);
        }
    }
}
