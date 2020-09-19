using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bank.Models
{
    public class CreditDbInitializer : DropCreateDatabaseAlways<CreditContext>
    {
        protected override void Seed(CreditContext db)
        {
            db.Credits.Add(new Credit { Type = "Big", MaxQuantity = 60000 });
            db.Credits.Add(new Credit { Type = "Small", MaxQuantity = 10000 });
            db.Credits.Add(new Credit { Type = "Medium", MaxQuantity = 30000 });
            base.Seed(db);
        }
    }

}