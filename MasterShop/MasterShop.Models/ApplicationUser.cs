using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            base.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string ProfileImage { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
