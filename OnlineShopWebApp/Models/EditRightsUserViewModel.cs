using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class EditRightsUserViewModel
    {
        public UserViewModel User { get; set; }
        public List<Role> Roles { get; set; }
    }
}
