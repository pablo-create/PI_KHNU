using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Person { get; set; }
        public string Address { get; set; }
        public int CreditId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public int Days { get; set; }

    }
}