using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Repositories
{
    public class InMemoryUsersRepository : IUsersRepository
    {
        private List<UserViewModel> users = new List<UserViewModel>()
        {
            new UserViewModel("Admin", "123"),
            new UserViewModel("Joseph", "123"),
            new UserViewModel("Vitya", "123")
        };

        public List<UserViewModel> Get()
        {
            return users;
        }

        public void Add(UserViewModel user)
        {
            users.Add(user);
        }

        public void Remove(Guid id)
        {
            users = users.Where(user => user.Id != id).ToList();
        }

        public UserViewModel TryGetById(Guid id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }

        public bool Exists(string userName)
        {
            return users.FirstOrDefault(x=> x.UserName == userName) != null;
        }

        public bool Exists(string userName, string password)
        {
            return users.FirstOrDefault(x => x.UserName == userName && x.Password == password) != null;
        }
    }
}
