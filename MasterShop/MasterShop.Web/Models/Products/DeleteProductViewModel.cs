using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterShop.Web.Models.Products
{
    public class DeleteProductViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
