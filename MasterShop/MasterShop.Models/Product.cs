﻿using MasterShop.Models.Enums;
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
            this.GalleryImages = new HashSet<Image>();
            this.CategoryProducts = new HashSet<CategoryProduct>();
            this.OrderProducts = new HashSet<OrderProduct>();
        }

        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string SKU { get; set; }

        public int Quantity { get; set; } = 1;

        [Required]
        public StockType Stock { get; set; }

        [Required]
        public decimal Price { get; set; }

        //public string OrderId { get; set; }

        //public Order Order { get; set; }

        public string ProductImage { get; set; }

        public ICollection<Image> GalleryImages { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
