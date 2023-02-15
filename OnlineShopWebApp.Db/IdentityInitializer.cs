using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using System.Xml.XPath;

namespace OnlineShop.Db
{
    public class IdentityInitializer
    {
        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "admin";
            var adminPassword = "123";

            var defaultUserEmail = "user";
            var defaultUserPassword = "123";

            if (roleManager.FindByNameAsync(Constants.AdminRoleName).Result == null)
                roleManager.CreateAsync(new IdentityRole(Constants.AdminRoleName)).Wait();

            if (roleManager.FindByNameAsync(Constants.UserRoleName).Result == null)
                roleManager.CreateAsync(new IdentityRole(Constants.UserRoleName)).Wait();

            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail };
                var result = userManager.CreateAsync(admin, adminPassword).Result;

                if (result.Succeeded)
                    userManager.AddToRoleAsync(admin, Constants.AdminRoleName).Wait();
            }

            if (userManager.FindByNameAsync(defaultUserEmail).Result == null)
            {
                var defaultUser = new User { Email = defaultUserEmail, UserName = defaultUserEmail };
                var result = userManager.CreateAsync(defaultUser, defaultUserPassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(defaultUser, Constants.UserRoleName).Wait();
                }
            }
        }
    }
}
