using System;
using System.Collections.Generic;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface IProductsRepository
    {
        void Add(Product product);
        void Edit(Product editedProduct);
        List<Product> GetAll();
        void Remove(Guid id);
        Product TryGetById(Guid id);
        List<Product> Search(Search search);
    }

}

