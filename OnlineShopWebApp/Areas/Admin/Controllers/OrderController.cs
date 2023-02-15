using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository orderRepository;

        public OrderController(IOrdersRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IActionResult Get()
        {
            var ordersDb = orderRepository.Get();
            var ordersViewModel = new List<OrderViewModel>();
            foreach (var order in ordersDb) 
            {
                ordersViewModel.Add(order.ToOrderViewModel());
            }
            return View(ordersViewModel);
        }

        public IActionResult GetDetails(Guid orderId)
        {
            var order = orderRepository.TryGetById(orderId);
            return View(order.ToOrderViewModel());
        }

        public IActionResult UpdateStatus(Guid orderId, Statuses orderStatus)
        {
            orderRepository.UpdateStatus(orderId, orderStatus);
            var order = orderRepository.TryGetById(orderId);
            return View("GetDetails", order.ToOrderViewModel());

        }
    }
}
