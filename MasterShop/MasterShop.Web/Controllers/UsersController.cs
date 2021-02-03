using AutoMapper;
using MasterShop.Services.Contracts;
using MasterShop.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MasterShop.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IMapper mapper;

        public UsersController(IUsersService usersService, IMapper mapper)
        {
            this.usersService = usersService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Profile(string id)
        {
            var user = this.usersService.GetUserById(id);
            var userViewModel = this.mapper.Map<UsersProfileViewModel>(user);
            return this.View(userViewModel);
        }
    }
}
