using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class AddProductViewModel
    {

        [Required(ErrorMessage = "Не указано имя продукта")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Имя продукта должно быть от 1 до 25 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана цена продукта")]
        [Range(1,100000, ErrorMessage = "Цена должна быть от 1 до 100000 рублей, без копеек")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Цена должна быть целым положительным числом")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указано описание продукта")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Описание продукта должно быть от 10 до 100 символов")]
        public string Description { get; set; }
        
        public IFormFile[] UploadedFiles { get; set; }
    }
}
