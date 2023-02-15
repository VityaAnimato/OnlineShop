using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;

        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            var cartDb = cartsRepository.TryGetByUserId(Constants.UserId).ToCartViewModel();

            return View(cartDb);
        }

        public IActionResult Add(Guid productId)
        {
            var productDb = productsRepository.TryGetById(productId);

            cartsRepository.Add(productDb, Constants.UserId);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveOne(Guid productId)
        {
            cartsRepository.RemoveOneItem(productId);

            return RedirectToAction("Index");
        }
        public IActionResult Clear()
        {
            cartsRepository.Clear(Constants.UserId);

            return RedirectToAction("Index");
        }
    }
}
