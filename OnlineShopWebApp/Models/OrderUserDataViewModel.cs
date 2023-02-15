using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class OrderUserDataViewModel : ICloneable
    {
        [Required(ErrorMessage = "Не указано ФИО")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "ФИО должно быть не менее 2 символов, но не более 100")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Адрес должен быть не менее 6 символов, но не более 100")]      
        public string Address { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Телефон должен быть не менее 10 символов")]   
        public string Phone { get; set; }


        public object Clone()
        {
            return new OrderUserDataViewModel
            {
                FullName = string.Copy(FullName), 
                Address = string.Copy(Address),
                Phone = string.Copy(Phone)
            };
        }
    }

}
