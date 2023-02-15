using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Логин должен быть от 2 до 25 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        public string OldUserName { get; set; }

        public Role Role { get; set; }

        public List<string> Roles { get; set; }
        public UserViewModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
            Id= Guid.NewGuid();
            Role = new Role("User");
        }

        public UserViewModel() 
        {
            Id = Guid.NewGuid();
            Role = new Role("User");
        }
    }
}
