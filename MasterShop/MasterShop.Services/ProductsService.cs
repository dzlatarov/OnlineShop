using MasterShop.Data;
using MasterShop.Models;
using MasterShop.Models.Enums;
using MasterShop.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterShop.Services
{
    public class ProductsService : IProductsService
    {
        private readonly MasterShopDbContext db;

        public ProductsService(MasterShopDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Product> GetAllProducts()
        {
            return db.Products;
        }

        public void Insert(Product product, List<string> categories)
        {
            foreach (var item in categories)
            {
                product.CategoryProducts.Add(new CategoryProduct()
                { 
                    Product = product,
                    CategoryId = item
                });
            }

            db.Products.Add(product);
        }

        public void Delete(Product product)
        {
            db.Products.Remove(product);
        }

        public Product GetProductById(string id)
        {
            return db.Products.Include(p => p.CategoryProducts).ThenInclude(cp => cp.Category).Where(p => p.Id == id).FirstOrDefault();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Product product)
        {
            db.Products.Update(product);
        }
    }
}
