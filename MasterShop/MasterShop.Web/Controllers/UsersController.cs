using AutoMapper;
using MasterShop.Models;
using MasterShop.Services.Contracts;
using MasterShop.Services.Models.Users;
using MasterShop.Web.Helper;
using MasterShop.Web.Models.Users;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment env;

        public UsersController(IUsersService usersService, IMapper mapper, IWebHostEnvironment env)
        {
            this.usersService = usersService;
            this.mapper = mapper;
            this.env = env;
        }
        [HttpGet]
        public IActionResult Profile(string id)
        {
            var user = this.usersService.GetUserById(id);
            ViewData["ProfileImage"] = user.ProfileImage;
            var userViewModel = new UsersProfileViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber
            };
            return this.View(userViewModel);
        }

        [HttpPost]
        public IActionResult Edit(UsersProfileViewModel model)
        {
            var fileUpload = new FileUpload(env);
            var imageFile = fileUpload.UploadFile(model.ProfileImage);
            var editedModel = new UsersEditViewModel
            {
                Id = model.Id,
                UserName = model.UserName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Email = model.Email,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                ProfileImage = imageFile
            };
            var updateModel = this.mapper.Map<UsersUpdateDto>(editedModel);
            this.usersService.UpdateUser(updateModel);
            this.usersService.Save();
            return RedirectToAction(nameof(Profile), new { id = this.User.FindFirstValue(ClaimTypes.NameIdentifier) });
        }
    }
}
