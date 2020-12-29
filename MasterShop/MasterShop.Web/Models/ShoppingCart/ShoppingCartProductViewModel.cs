using MasterShop.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterShop.Web.Models.ShoppingCart
{
    public class ShoppingCartProductViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SKU { get; set; }

        public int Quantity { get; set; } = 1;

        public StockType Stock { get; set; }

        public decimal Price { get; set; }
    }
}
