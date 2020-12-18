using System;
using System.Collections.Generic;
using System.Text;

namespace MasterShop.Models
{
    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CategoryProducts = new HashSet<CategoryProduct>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
