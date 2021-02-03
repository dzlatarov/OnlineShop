using AutoMapper;
using MasterShop.Models;
using MasterShop.Services.Contracts;
using MasterShop.Services.Models.Users;
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

        [HttpPost]
        public IActionResult Edit(UsersEditViewModel model)
        {
            var updateModel = this.mapper.Map<UsersUpdateDto>(model);
            this.usersService.UpdateUser(updateModel);
            this.usersService.Save();
            return RedirectToAction(nameof(Profile), new { id = this.User.FindFirstValue(ClaimTypes.NameIdentifier) });
        }
    }
}
