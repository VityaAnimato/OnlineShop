using OnlineShop.Db.Models;
using System;

namespace OnlineShop.Db
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        Cart TryGetByUserId(string userId);
        void RemoveOneItem(Guid id);
        void Clear(string userId);
    }
}
