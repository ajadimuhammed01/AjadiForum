using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AjadiForum.Data;
using AjadiForum.Models;
using AjadiForum.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AjadiForum.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IApplicationUser _userService;
        private readonly IUpload _uploadService;
        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IUpload uploadService)
        {
            _userManager = userManager;
            _userService = userService;
            _uploadService = uploadService;
        }
        public IActionResult Detail(string id)
        {
            var model = new ProfileModel()
            {

            };
            return View(model);
        }
    }
}