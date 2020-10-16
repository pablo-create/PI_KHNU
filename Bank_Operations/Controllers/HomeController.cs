using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bank_Operations.Models;

namespace Bank_Operations.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        CreditContext db = new CreditContext();
        DateTime date;
        public ActionResult Index()
        {
            return View(db.Credits);
        }

        [HttpGet]
        public ActionResult Order(int id) { ViewBag.CreditId = id; return View(); }

        [HttpPost]
        public string Order(Order order)
        {
            order.Date = date = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();
            return "Спасибі," + order.Person + ", за замовлення! Термін вашого кредиту закінчується " + date.AddDays(order.Days).ToShortDateString() + " числа!";
        }


        public ActionResult CreditView(int id) 
        { 
            var credit = db.Credits.Find(id); 
            if (credit != null) { 
                return View(credit); 
            } 
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public ActionResult EditCredit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Credit book = db.Credits.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost] 
        public ActionResult EditCredit(Credit credit) 
        { 
            db.Entry(credit).State = EntityState.Modified; 
            db.SaveChanges(); 
            return RedirectToAction("Index"); 
        }


        [HttpGet] public ActionResult Create() { return View(); }
        [HttpPost] public ActionResult Create(Credit credit) 
        { 
            db.Credits.Add(credit); 
            db.SaveChanges(); 
            return RedirectToAction("Index"); 
        }

        [HttpGet] 
        public ActionResult Delete(int? id) 
        { 
            if (id == null) { 
                return HttpNotFound(); 
            } 
            Credit b = db.Credits.Find(id); 
            if (b == null) { 
                return HttpNotFound(); 
            } 
            return View(b); }
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id) 
        { 
            if (id == null) { 
                return HttpNotFound(); 
            } 
            Credit b = db.Credits.Find(id); 
            if (b == null) { 
                return HttpNotFound(); 
            } 
            db.Credits.Remove(b); 
            db.SaveChanges(); 
            return RedirectToAction("Index"); 
        }
    }
}
