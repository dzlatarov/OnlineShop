using MasterShop.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterShop.Services.Contracts
{
    public interface IProductsService
    {
        void Create(string id, string name, string sku, StockType type, decimal price);
    }
}
