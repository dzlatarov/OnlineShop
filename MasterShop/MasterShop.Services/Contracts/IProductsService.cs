using MasterShop.Models;
using MasterShop.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterShop.Services.Contracts
{
    public interface IProductsService
    {
        IQueryable<Product> GetAllProducts();
        Product GetProductById(string id);
        void Insert(Product product);
        void Update(Product product);
        void Delete(Product product);
        void Save();
    }
}
