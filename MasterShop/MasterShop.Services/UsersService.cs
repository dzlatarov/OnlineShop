using AutoMapper;
using MasterShop.Data;
using MasterShop.Models;
using MasterShop.Services.Contracts;
using MasterShop.Services.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterShop.Services
{
    public class UsersService : IUsersService
    {
        private readonly MasterShopDbContext db;
        private readonly IMapper mapper;

        public UsersService(MasterShopDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
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

        public void UpdateUser(UsersUpdateDto model)
        {
            var userFromDb = this.GetUserById(model.Id);

            userFromDb.FirstName = model.Firstname;
            userFromDb.MiddleName = model.MiddleName;
            userFromDb.LastName = model.MiddleName;
            userFromDb.Email = model.Email;
            userFromDb.Address = model.Address;
            userFromDb.PhoneNumber = model.PhoneNumber;
            this.db.Update(userFromDb);
        }
    }
}
