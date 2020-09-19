using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        CreditContext db = new CreditContext();
        DateTime date;
        public ActionResult Index()
        {
            IEnumerable<Credit> credits = db.Credits;
            ViewBag.Credits = credits;
            return View();
        }

        [HttpGet] 
        public ActionResult Order(int id) { ViewBag.CreditId = id; return View(); }

        [HttpPost]
        public string Order(Order order)
        {
            order.Date =  date = DateTime.Now;
            db.Orders.Add(order); 
            db.SaveChanges(); 
            return "Спасибі," + order.Person + ", за замовлення! Термін вашого кредиту закінчується " + date.AddDays(order.Days).ToShortDateString() + " числа!"; }
        }
}