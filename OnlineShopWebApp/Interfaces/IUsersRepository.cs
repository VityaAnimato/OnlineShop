using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface IUsersRepository
    {
        List<UserViewModel> Get();
        UserViewModel TryGetById(Guid id);
        void Add(UserViewModel user);
        void Remove(Guid id);
        bool Exists(string userName);
        bool Exists(string userName, string password);
    }
}
