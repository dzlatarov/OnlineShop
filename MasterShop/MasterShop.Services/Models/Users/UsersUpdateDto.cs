using System;
using System.Collections.Generic;
using System.Text;

namespace MasterShop.Services.Models.Users
{
    public class UsersUpdateDto
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string ProfileImage { get; set; }
    }
}
