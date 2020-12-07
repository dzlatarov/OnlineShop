using MasterShop.Data;
using MasterShop.Models;
using MasterShop.Models.Enums;
using MasterShop.Services.Contracts;
using System;
using System.Collections.Generic;
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

        public void Create(string id, string name, string sku, StockType type, decimal price)
        {
            var product = new Product
            {
                Id = id,
                Name = name,
                SKU = sku,
                Stock = type,
                Price = price
            };

            db.Products.Add(product);
            db.SaveChanges();
        }
    }
}
