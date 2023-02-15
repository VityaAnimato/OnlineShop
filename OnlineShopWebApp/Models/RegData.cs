using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class RegData
    {
        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Логин должен быть от 2 до 25 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmationPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}
