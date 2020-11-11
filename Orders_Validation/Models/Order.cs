using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Credit_Relationship.Models
{
    public class Order
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле Ім'я не може бути порожнім")]
        [Display(Name = "Ім'я")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Довжина рядка повинна бути від 4 до 50 символів")]
        public string Person { get; set; }

        [Required(ErrorMessage = "Поле Адреса не може бути порожнім")]
        [Display(Name = "Адреса")]
        [StringLength(40, MinimumLength = 10, ErrorMessage = "Довжина рядка повинна бути від 10 до 40 символів")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Поле Кількість не може бути порожнім")]
        [Display(Name = "Кількість")]
        [Range(100, 1000000, ErrorMessage = "Довжина рядка повинна бути від 100 до 1 000 000 символів")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Поле Дата не може бути порожнім")]
        [Display(Name = "Дата")]
        [RegularExpression("([0][1-9]|[2][0-9]|[3][0-1]|[1-9]|[1][0-9])/([0][1-9]|[1][0-2]|[1-9])/([1-2][0-9][0-9][0-9]|[0-9][0-9])", ErrorMessage = "Некоректна дата")]
        public String Date { get; set; }

        [Required(ErrorMessage = "Поле Кількість днів не може бути порожнім")]
        [Display(Name = "Кількість днів")]
        [Range(1, 99, ErrorMessage = "Довжина рядка повинна бути від 1 до 2 символів")]
        public int Days { get; set; }
    }
}