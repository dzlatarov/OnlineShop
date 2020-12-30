using AutoMapper;
using MasterShop.Data;
using MasterShop.Models;
using MasterShop.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterShop.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly MasterShopDbContext db;

        public OrdersService(MasterShopDbContext db)
        {
            this.db = db;
        }

        public void CreateOrder(Order order)
        {
            this.db.Orders.Add(order);
        }

        public void Delete(Order order)
        {
            this.db.Orders.Remove(order);
        }

        public IQueryable<Order> GetAllOrders()
        {
            return this.db.Orders;
        }

        public Order GetOrderById(string id)
        {
            return this.db.Orders.Where(o => o.Id == id).FirstOrDefault();
        }

        public void Save()
        {
            this.db.SaveChanges();
        }

        public void Update(Order order)
        {
            this.db.Update(order);
        }
    }
}
