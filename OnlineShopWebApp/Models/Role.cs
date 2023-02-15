using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Role
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Минимум 3 буквы")]
        public string Name { get; set; }

        public Role(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }
        public Role() 
        {
            Id = Guid.NewGuid();
        }
    }

}

