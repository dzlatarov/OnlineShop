using MasterShop.Data;
using MasterShop.Models;
using MasterShop.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterShop.Services
{
    public class UsersService : IUsersService
    {
        private readonly MasterShopDbContext db;

        public UsersService(MasterShopDbContext db)
        {
            this.db = db;
        }
        public void CreateUser(ApplicationUser user)
        {
            this.db.Users.Add(user);
        }

        public void DeleteUser(ApplicationUser user)
        {
            this.db.Users.Remove(user);
        }

        public IQueryable<ApplicationUser> GetAllUsers()
        {
            return this.db.Users;
        }

        public ApplicationUser GetUserById(string id)
        {
            return this.db.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            this.db.SaveChanges();
        }

        public void UpdateUser(ApplicationUser user)
        {
            this.db.Users.Update(user);
        }
    }
}
