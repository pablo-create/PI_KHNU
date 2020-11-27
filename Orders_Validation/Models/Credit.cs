using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Credit_Relationship.Models
{
    public class Credit
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int MaxQuantity { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}