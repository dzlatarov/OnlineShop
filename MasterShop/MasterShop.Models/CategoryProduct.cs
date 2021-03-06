﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MasterShop.Models
{
    public class CategoryProduct
    {
        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
