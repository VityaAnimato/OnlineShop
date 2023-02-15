using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DatabaseContext databaseContext;

        public CartsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if (existingCart != null)
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);

                if (existingCartItem == null)
                    existingCart.Items.Add(new CartItem()
                    {
                        Amount = 1,
                        Product = product,
                    });
                else
                    existingCartItem.Amount += 1;
            }
            else
            {
                var newCart = new Cart()
                {
                    UserId = userId,
                };
                newCart.Items = new List<CartItem>()
                {
                    new CartItem()
                    {
                        Amount = 1,
                        Product = product,
                    }
                };

                databaseContext.Add(newCart);
            }
            databaseContext.SaveChanges();
        }

        public Cart TryGetByUserId(string userId)
        {
            return databaseContext.Carts.Include(x => x.Items).
                ThenInclude(x => x.Product).
                FirstOrDefault(x => x.UserId == userId);
        }

        public void RemoveOneItem(Guid id)
        {
            var existingCart = TryGetByUserId(Constants.UserId);
            if (existingCart != null)
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == id);
                if (existingCartItem != null)
                {
                    existingCartItem.Amount -= 1;

                    if (existingCartItem.Amount == 0)
                    {
                        existingCart.Items = existingCart.Items.Where(x => x.Id != existingCartItem.Id).ToList();
                    }
                }
            }
            databaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(Constants.UserId);
            databaseContext.Carts.Remove(existingCart);
            databaseContext.SaveChanges();
        }
    }
}
