using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public List<CartItem> Items { get; set; }

        public OrderUserData OrderUserData { get; set; }

        public Statuses Status { get; set; }

        public DateTime DateTime { get; set; }

        public Order(OrderUserData orderUserData)
        {
            UserId = Constants.UserId;
            Status = Statuses.Created;
            DateTime = DateTime.Now;
            OrderUserData = (OrderUserData)orderUserData.Clone();
        } 
        
        public Order() { }
    }

}

