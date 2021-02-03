using MasterShop.Models;
using MasterShop.Services.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterShop.Services.Contracts
{
    public interface IUsersService
    {
        ApplicationUser GetUserById(string id);
        IQueryable<ApplicationUser> GetAllUsers();
        void CreateUser(ApplicationUser user);
        void DeleteUser(ApplicationUser user);
        void UpdateUser(UsersUpdateDto model);
        void Save();
    }
}
