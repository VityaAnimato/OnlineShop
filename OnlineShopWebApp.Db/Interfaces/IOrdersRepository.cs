using OnlineShop.Db.Models;
using System.Collections.Generic;
using System;

namespace OnlineShop.Db.Interfaces
{
    public interface IOrdersRepository
    {
        List<Order> Get();
        Order TryGetById(Guid orderId);
        void Add(Order order);

        void UpdateStatus(Guid orderId, Statuses status);

    }
}
