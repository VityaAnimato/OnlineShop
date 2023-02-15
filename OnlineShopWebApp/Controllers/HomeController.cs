using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productStorage;

        public HomeController(IProductsRepository productStorage)
        {
            this.productStorage = productStorage;
        }

        public IActionResult Index()
        {
            var productsDb = productStorage.GetAll();

            var productsViewModels = new List<ProductViewModel>();
            foreach(var productDb in productsDb)
            {
                var productViewModel = productDb.ToProductViewModel();

                productsViewModels.Add(productViewModel);
            }
            return View(productsViewModels);
        }



        [HttpPost]
        public IActionResult Search(Search search)
        {
            var searchDb = new Search
            {
                SearchString = search.SearchString,
            };
            var searchedProducts = productStorage.Search(searchDb);

            return View(searchedProducts);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
