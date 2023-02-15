using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using OnlineShopWebApp.Helpers;
using OnlineShop.Db;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<OnlineShop.Db.Models.User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserController(UserManager<OnlineShop.Db.Models.User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Get()
        {
            var users = userManager.Users.ToList();
            return View(users.Select(user => user.ToUserViewModel()).ToList());
        }

        public IActionResult GetDetails(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            var roles = userManager.GetRolesAsync(user).Result;

            var userViewModel = user.ToUserViewModel();
            userViewModel.Roles = (List<string>)roles;

            return View(userViewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserViewModel user)
        {
            if (userManager.FindByNameAsync(user.UserName).Result != null)
            {
                ModelState.AddModelError("", $"Пользователь {user.UserName} уже существует");
                return View(user);
            }

            userManager.CreateAsync(user.ToUser(), user.Password).Wait();

            return RedirectToAction(nameof(Get));
        }



        public IActionResult EditInfo(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            return View(user.ToUserViewModel());
        }

        [HttpPost]
        public IActionResult EditInfo(UserViewModel editedUser)
        {
            var user = userManager.FindByNameAsync(editedUser.OldUserName).Result;
            if (user == null)
            {
                ModelState.AddModelError("", $"Пользователь не существует");
                return RedirectToAction(nameof(Get));
            }

            user.UserName = editedUser.UserName;

            userManager.UpdateAsync(user).Wait();


            return RedirectToAction(nameof(Get));
        }

        public IActionResult EditPassword(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            return View(user.ToUserViewModel());
        }

        [HttpPost]
        public IActionResult EditPassword(UserViewModel editedUser)
        {
            var user = userManager.FindByNameAsync(editedUser.UserName).Result;
            if (user == null)
            {
                ModelState.AddModelError("", $"Пользователь не существует");
                return RedirectToAction(nameof(Get));
            }

            var newHashPassword = userManager.PasswordHasher.HashPassword(user, editedUser.Password);
            user.PasswordHash = newHashPassword;
            userManager.UpdateAsync(user).Wait();

            return RedirectToAction(nameof(Get));
        }

        public IActionResult Remove(string name)
        {
            var user = userManager.FindByNameAsync(name).Result;
            if (user == null)
            {
                ModelState.AddModelError("", $"Пользователь не существует");
                return View(nameof(Get));
            }

            userManager.DeleteAsync(user);

            return RedirectToAction(nameof(Get));
        }

        public IActionResult EditRole(string userName)
        {
            var user = userManager.FindByNameAsync(userName).Result;
            var roles = roleManager.Roles.ToList();
            var editRightsUserViewModel = new EditRightsUserViewModel { User = user.ToUserViewModel(), Roles = roles.ToListRoles() };
            return View(editRightsUserViewModel);
        }

        public IActionResult ConfirmRole(string userName, string roleName, string oldRole)
        {
            if (userManager.FindByNameAsync(userName).Result == null)
            {
                ModelState.AddModelError("", $"Пользователь не существует");
                return RedirectToAction(nameof(Get));
            }

            var user = userManager.FindByNameAsync(userName).Result;

            userManager.AddToRoleAsync(user, roleName).Wait();
            userManager.RemoveFromRoleAsync(user, oldRole).Wait();
            

            return RedirectToAction(nameof(Get));
        }
    }
}
