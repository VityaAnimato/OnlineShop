using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Data;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class RoleController : Controller
    {      
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(IRolesRepository rolesRepository, UserManager<OnlineShop.Db.Models.User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get()
        {
            var roles = roleManager.Roles.ToList().ToListRoles();
            return View(roles);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (roleManager.FindByNameAsync(role.Name).Result != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                roleManager.CreateAsync(role.ToIdentityRole()).Wait();
                return RedirectToAction("Get");
            }
            return View(role);
        }

        public IActionResult Remove(string name)
        {
            var role = roleManager.FindByNameAsync(name).Result;
            roleManager.DeleteAsync(role);
            return RedirectToAction("Get");
        }
    }
}
