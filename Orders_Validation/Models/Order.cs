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
        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "NameRequired")]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
        [StringLength(50, MinimumLength = 4, ErrorMessageResourceName = "StringLengthPerson", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string Person { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "AddressRequired")]
        [Display(Name = "Address", ResourceType = typeof(Resources.Resource))]
        [StringLength(40, MinimumLength = 10, ErrorMessageResourceName = "StringLengthAddress", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "AmountRequired")]
        [Display(Name = "Amount", ResourceType = typeof(Resources.Resource))]
        [Range(100, 1000000, ErrorMessageResourceName = "NumberLengthQuantity", ErrorMessageResourceType = typeof(Resources.Resource))]
        public int Quantity { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "DateRequired")]
        [Display(Name = "Date", ResourceType = typeof(Resources.Resource))]
        [RegularExpression("([0][1-9]|[2][0-9]|[3][0-1]|[1-9]|[1][0-9])/([0][1-9]|[1][0-2]|[1-9])/([1-2][0-9][0-9][0-9]|[0-9][0-9])", ErrorMessageResourceName ="DateValidation", ErrorMessageResourceType = typeof(Resources.Resource))]
        public String Date { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource), ErrorMessageResourceName = "AmountOfDaysRequired")]
        [Display(Name = "Number_of_days", ResourceType = typeof(Resources.Resource))]
        [Range(1, 99, ErrorMessageResourceName = "NumberLengthDays", ErrorMessageResourceType = typeof(Resources.Resource))]
        public int Days { get; set; }
    }
}