using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Orders_Validation.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Поле Логін не може бути порожнім")] 
        [Display(Name = "Логін")] 
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле Адреса не може бути порожнім")]
        [DataType(DataType.EmailAddress)] 
        [Display(Name = "Електронна пошта")] 
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле Пароль не може бути порожнім")]
        [StringLength(100, ErrorMessage = "Пароль повинен мати від 6 до 100 символів", MinimumLength = 6)] 
        [DataType(DataType.Password)] 
        [Display(Name = "Пароль")] 
        public string Password { get; set; }

        [DataType(DataType.Password)] 
        [Display(Name = "Підтвердити пароль")] 
        [Compare("Password", ErrorMessage = "Паролі не співпадають.")] 
        public string ConfirmPassword { get; set; }
    }
}