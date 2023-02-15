using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System;

namespace OnlineShopWebApp.Interfaces
{
    public interface IRolesRepository
    {
        List<Role> Get();
        Role TryGetByName(string roleName);
        void Add(Role role);

        void Remove(Guid roleId);
    }
}
