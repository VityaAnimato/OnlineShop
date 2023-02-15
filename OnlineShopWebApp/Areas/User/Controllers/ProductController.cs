using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.User.Controllers
{
    [Area("User")]

    public class ProductController : Controller
    {
        private readonly IProductsRepository productStorage;
        public ProductController(IProductsRepository productStorage)
        {
            this.productStorage = productStorage;
        }

        public IActionResult Index(Guid id)
        {
            var productDb = productStorage.TryGetById(id);

            var productViewModel = productDb.ToProductViewModel();
            return View(productViewModel);
        }
    }
}
