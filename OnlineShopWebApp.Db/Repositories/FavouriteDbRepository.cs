using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories
{
    public class FavouriteDbRepository : IFavouriteRepository
    {
        private readonly DatabaseContext databaseContext;

        public FavouriteDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Product> GetAll(string userId)
        {
            return databaseContext.Favourites.Where(x => x.UserId == userId).
                Include(x => x.Product).
                Select(x => x.Product).
                ToList();
        }

        public void Add(Product product, string userId)
        {
            var favourite = databaseContext.Favourites.
                FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);

            if (favourite == null)
            {
                databaseContext.Favourites.Add(new Favourite {UserId = Constants.UserId, Product = product });
                databaseContext.SaveChanges();
            }      
        }

        public void Remove(string userId, Product product)
        {
            var favourite = databaseContext.Favourites.
                FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);

            if (favourite != null)
            {
                databaseContext.Favourites.Remove(favourite);
                databaseContext.SaveChanges();
            }
        }

        public void Clear(string userId)
        {
            var favourites = databaseContext.Favourites.
                Where(x => x.UserId == userId);

            if (favourites != null)
            {
                databaseContext.Favourites.RemoveRange(favourites);
                databaseContext.SaveChanges();
            }
        }
    }
}
