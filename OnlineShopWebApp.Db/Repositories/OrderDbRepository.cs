using OnlineShop.Db.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using OnlineShop.Db.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Db.Repositories
{
    public class OrderDbRepository : IOrdersRepository
    {
        private readonly DatabaseContext databaseContext;

        public OrderDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Order> Get()
        {
            return databaseContext.Orders.
                Include(x => x.Items).
                ThenInclude(x => x.Product).
                Include(x => x.OrderUserData).
                ToList();
        }

        public void Add(Order order)
        {
            databaseContext.Orders.Add(order);
            databaseContext.SaveChanges();
        }

        public Order TryGetById(Guid orderId)
        {
            return databaseContext.Orders.
                Include(x => x.OrderUserData).
                Include(x => x.Items).
                ThenInclude(x => x.Product).
                FirstOrDefault(order => order.Id == orderId);
        }

        public void UpdateStatus(Guid orderId, Statuses status)
        {
            var order = TryGetById(orderId);
            order.Status = status;
            databaseContext.Orders.Update(order);
            databaseContext.SaveChanges();
        }
    }
}
