using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

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
        public List<string> ImagesPaths { get; set; }
        public string ImagePath => ImagesPaths.Count == 0 ? "/images/Products/image5.jpg" : ImagesPaths[0];
    }
}
