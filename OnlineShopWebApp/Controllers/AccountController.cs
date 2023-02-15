using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IUsersRepository usersRepository, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginData() { ReturnUrl = returnUrl});
        }
        [HttpPost]
        public IActionResult Login(LoginData loginData)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(loginData.UserName, loginData.Password, loginData.KeepMeSignedIn, false).Result;
                if (result.Succeeded)
                {
                    if (loginData.ReturnUrl != null)
                        return Redirect(loginData.ReturnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                    
                else
                    ModelState.AddModelError("", "Неправильный пароль");
            }
            return View(loginData);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register(string returnUrl)
        {
            return View(new RegData() { ReturnUrl = returnUrl});
        }
        [HttpPost]
        public IActionResult Register(RegData regData)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Email = regData.UserName, UserName = regData.UserName };

                var result = _userManager.CreateAsync(user, regData.Password).Result;
                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, isPersistent: false).Wait();
                    if (regData.ReturnUrl != null)
                        return Redirect(regData.ReturnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (regData.Password.Length < 3)
                        ModelState.AddModelError("", "Длина пароля менее 3 символов");
                    if (_userManager.Users.Any(u => u.Email == regData.UserName))
                        ModelState.AddModelError("", "Пользователь существует");
                }
                    
            }
            return View(regData);
        }
    }
}
