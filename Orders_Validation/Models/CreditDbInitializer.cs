using Credit_Relationship.Models;
using Orders_Validation.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bank.Models
{
    public class CreditDbInitializer : DropCreateDatabaseAlways<OrderContext>
    {
        protected override void Seed(OrderContext db)
        {
            db.Credits.Add(new Credit { Type = "Big", MaxQuantity = 60000 });
            db.Credits.Add(new Credit { Type = "Small", MaxQuantity = 10000 });
            db.Credits.Add(new Credit { Type = "Medium", MaxQuantity = 30000 });
            base.Seed(db);
        }
    }

}