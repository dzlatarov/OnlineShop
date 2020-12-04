using System;
using System.Collections.Generic;
using System.Text;

namespace MasterShop.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Products = new HashSet<Product>();
        }
        public string Id { get; set; }

        public int Count { get; set; }

        public DateTime DateOfCreation { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
