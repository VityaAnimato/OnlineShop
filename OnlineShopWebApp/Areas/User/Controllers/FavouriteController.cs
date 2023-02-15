using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class FavouriteController : Controller
    {
        private readonly IFavouriteRepository favouriteRepository;
        private readonly IProductsRepository productsRepository;

        public FavouriteController(IFavouriteRepository favouriteRepository, IProductsRepository productsRepository)
        {
            this.favouriteRepository = favouriteRepository;
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var favouritesDb = favouriteRepository.GetAll(Constants.UserId);
            return View(favouritesDb.ToProductsViewModel());
        }
        public IActionResult Add(Guid productId)
        {
            var productdB = productsRepository.TryGetById(productId);

            favouriteRepository.Add(productdB, Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            favouriteRepository.Remove(Constants.UserId, product);

            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            favouriteRepository.Clear(Constants.UserId);

            return RedirectToAction("Index");
        }
    }
}
