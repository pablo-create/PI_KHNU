using Credit_Relationship.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Credit_Relationship.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        CreditContext db = new CreditContext(); 
        public ActionResult Index() {
            var orders = db.Orders.Include(p => p.Credit);
            
            return View(orders.ToList()); 
        }

        public ActionResult ListCredits()
        {
            return View(db.Credits);
        }

        public ActionResult CreditDetails(int? id) { 
            if (id == null) { 
                return HttpNotFound(); 
            } 
            Credit credit = db.Credits.Find(id); 
            if (credit == null) { 
                return HttpNotFound(); 
            } 
            credit.Orders = db.Orders.Where(m => m.CreditId == credit.Id); 
            return View(credit); 
        }

        //Edit Order
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Order order = db.Orders.Find(id);
            if (order != null)
            {
                SelectList credits = new SelectList(db.Credits, "Id", "Type", order.CreditId); 
                ViewBag.Credits = credits; 
                return View(order);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Create Order
        [HttpGet] 
        public ActionResult Create() {
            SelectList credits = new SelectList(db.Credits, "Id", "Type"); 
            ViewBag.Credits = credits;
            return View(); 
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Delete Order
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Order b = db.Orders.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            Credit credit = db.Credits.Find(b.CreditId);
            ViewBag.Credits = credit;
            return View(b);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Order b = db.Orders.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Orders.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}