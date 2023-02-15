using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using OnlineShop.Db;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;

namespace OnlineShopWebApp.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository orderRepository;
        private readonly ICartsRepository cartsRepository;


        public OrderController(IOrdersRepository orderRepository, ICartsRepository cartsRepository)
        {
            this.orderRepository = orderRepository;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(OrderUserDataViewModel orderUserData)
        {
            if (ModelState.IsValid)
            {
                var cart = cartsRepository.TryGetByUserId(Constants.UserId);

                var order = new Order
                {
                    OrderUserData = orderUserData.ToOrderUserData(),
                    Items = cart.Items,
                    DateTime = DateTime.Now,
                    UserId = Constants.UserId,
                };

                orderRepository.Add(order);

                cartsRepository.Clear(Constants.UserId);
                return View("Complete");
            }

            return View();
        }
    }
}
