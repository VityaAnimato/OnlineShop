using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }

        public void Edit(Product editedProduct)
        {
            var editedProductDb = new Product
            {
                Id = editedProduct.Id,
                Name = editedProduct.Name,
                Description = editedProduct.Description,
                Cost = editedProduct.Cost,
                Images = editedProduct.Images,
            };

            var products = databaseContext.Products.ToList();
            for (int i = 0; i < products.Count; i++)
            {
                if (editedProductDb.Id == products[i].Id)
                {
                    databaseContext.Remove(products[i]);
                    databaseContext.Update(editedProductDb);
                    databaseContext.SaveChanges();
                    return;
                }
            }
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.Include(x => x.Images).ToList();
        }

        public void Remove(Guid id)
        {
            var product = databaseContext.Products.FirstOrDefault(x => x.Id == id);
            databaseContext.Products.Remove(product);
            databaseContext.SaveChanges();
        }

        public List<Product> Search(Search search)
        {
            var products = databaseContext.Products.ToList();
            var searchedProducts = new List<Product>();

            foreach (var product in products)
            {
                if (product.Name.Contains(search.SearchString) || product.Description.Contains(search.SearchString))
                {
                    searchedProducts.Add(product);
                }
            }
            return searchedProducts;
        }

        public Product TryGetById(Guid id)
        {
            return databaseContext.Products.Include(x => x.Images).FirstOrDefault(product => product.Id == id);
        }

    }

}

