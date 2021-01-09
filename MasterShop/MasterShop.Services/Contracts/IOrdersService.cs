using MasterShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterShop.Services.Contracts
{
    public interface IOrdersService
    {
        IQueryable<Order> GetAllOrders();
        Order GetOrderById(string id);
        void CreateOrder(Order order, List<Product> products);
        void Update(Order order);
        void Delete(Order order);
        void Save();
    }
}
