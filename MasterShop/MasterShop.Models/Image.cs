using System;
using System.Collections.Generic;
using System.Text;

namespace MasterShop.Models
{
    public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string ImageFile { get; set; }

        public string ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
