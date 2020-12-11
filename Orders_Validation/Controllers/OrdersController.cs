using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Credit_Relationship.Models;
using Orders_Validation.Data;
using Orders_Validation.Filters;

namespace Orders_Validation.Controllers
{
    [Culture]
    public class OrdersController : Controller
    {
        private OrderContext db = new OrderContext();

        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath; 
            List<string> cultures = new List<string>() { "uk", "en"}; 
            if (!cultures.Contains(lang)) { lang = "uk"; } 
            HttpCookie cookie = Request.Cookies["lang"]; 
            if (cookie != null) cookie.Value = lang;  
            else { cookie = new HttpCookie("lang"); 
                cookie.HttpOnly = false; 
                cookie.Value = lang; 
                cookie.Expires = DateTime.Now.AddYears(1); 
            } 
            Response.Cookies.Add(cookie); 
            return Redirect(returnUrl); 
        }
            public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        public ActionResult ListCredits()
        {
            return View(db.Credits);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Person,Address,Quantity,Date,Days")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Person,Address,Quantity,Date,Days")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
