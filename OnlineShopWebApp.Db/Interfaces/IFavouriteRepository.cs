using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db.Interfaces
{
    public interface IFavouriteRepository
    {
        public List<Product> GetAll(string userId);
        public void Add(Product product, string userId);
        public void Remove(string userId, Product product);
        public void Clear(string userId);
    }
}
