using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;

        public CartViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(Constants.UserId);

            if (cart != null && cart.Items != null)
            {


                var cartViewModel = new CartViewModel
                {
                    Id = cart.Id,
                    UserId = cart.UserId,
                    Items = new List<CartItemViewModel>(),
                };
                for (int i = 0; i < cart.Items.Count; i++)
                {
                    var item = new CartItemViewModel
                    {
                        Id = cart.Items[i].Id,
                        Product = new ProductViewModel
                        {
                            Id = cart.Items[i].Product.Id,
                            Name = cart.Items[i].Product.Name,
                            Description = cart.Items[i].Product.Description,
                        },
                        Amount = cart.Items[i].Amount,
                    };
                    cartViewModel.Items.Add(item);
                }
                var productCounts = cartViewModel?.Amount ?? 0;

                return View("Cart", productCounts);
            }
            return View("Cart", (decimal)0);
        }
    }
}
