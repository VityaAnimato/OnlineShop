using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using OnlineShopWebApp.Interfaces;

namespace OnlineShopWebApp.Repositories
{
    public class InMemoryRolesRepository : IRolesRepository
    {
        private List<Role> roles = new List<Role>()
        {
            new Role("Admin"),
            new Role("Boss"),
            new Role("User")
        };

        public void Add(Role role)
        {
            roles.Add(role);
        }

        public List<Role> Get()
        {
            return roles;
        }

        public void Remove(Guid roleId)
        {
            roles = roles.Where(role => role.Id != roleId).ToList();
        }

        public Role TryGetByName(string roleName)
        {
            return roles.FirstOrDefault(role => role.Name == roleName);
        }
    }
}
