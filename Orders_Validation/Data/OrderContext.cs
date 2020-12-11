using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Orders_Validation.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("name=OrderContext")
        {
        }

        public System.Data.Entity.DbSet<Credit_Relationship.Models.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<Credit_Relationship.Models.Credit> Credits { get; set; }
    }
}
