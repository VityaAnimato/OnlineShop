using OnlineShop.Db;
using OnlineShopWebApp.Helpers;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public List<CartItemViewModel> Items { get; set; }

        public OrderUserDataViewModel OrderUserData { get; set; }

        public Statuses Status { get; set; }

        public DateTime DateTime { get; set; }

        public OrderViewModel(OrderUserDataViewModel orderUserData)
        {
            Id = Guid.NewGuid();
            UserId = Constants.UserId;
            Status = Statuses.Created;
            DateTime = DateTime.Now;
            OrderUserData = (OrderUserDataViewModel)orderUserData.Clone();
        }

        public OrderViewModel() { }

        public decimal Cost()
        {
            if (Items == null || Items.Count == 0)
            {
                return 0;
            }

            decimal result = 0;
            foreach (var item in Items)
            {
                result += item.Cost;
            }
            return result;
        }
    }

}

