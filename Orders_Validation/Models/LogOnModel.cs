using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Orders_Validation.Models
{
    public class LogOnModel
    {
        [Required(ErrorMessage = "Поле Логін не може бути порожнім")]
        [Display(Name = "Логін")] 
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле Пароль не може бути порожнім")]
        [DataType(DataType.Password)] 
        [Display(Name = "Пароль")] 
        public string Password { get; set; }

        [Display(Name = "Запам'ятати")] 
        public bool RememberMe { get; set; }
    }
}