using MasterShop.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MasterShop.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Images = new HashSet<Image>();
            this.CategoryProducts = new HashSet<CategoryProduct>();
        }

        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string SKU { get; set; }

        [Required]
        public StockType Stock { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string OrderId { get; set; }

        public virtual Order Order { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
