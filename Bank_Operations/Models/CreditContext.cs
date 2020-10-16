using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bank_Operations.Models
{
    public class CreditContext : DbContext
    {
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}