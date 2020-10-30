using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Credit_Relationship.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public int Days { get; set; }
        public int? CreditId { get; set; }
        public Credit Credit { get; set; }
    }
}