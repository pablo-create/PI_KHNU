using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razor.Models;
using Razor.Controllers;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Restaurant myRestaurant = new Restaurant
        {
            RestaurantID = 1,
            Name = "Obao",
            Description = "We are the best restaurant in the world!",
            WorkingTime = " Sun-Thu 11:30am-10:00pm and Fri-Sat 11:30am-11:00pm ",
            Rate = 9
        };
        public ActionResult Index()
        {
            return View(myRestaurant);
        }
        public ActionResult NameAndTime() { 
            return View(myRestaurant); 
        }
        public ActionResult DemoExpression()
        {
            ViewBag.RestaurantCount = 4; 
            ViewBag.Delivery = true;
            ViewBag.ApplyDiscount = false; 
            ViewBag.Supplier = null; 
            return View(myRestaurant);
        }
        public ActionResult DemoArray() { 
            Restaurant[] array = {
                new Restaurant { Name = "Obao-1", Rate = 7 }, 
                new Restaurant { Name = "Obao-2", Rate = 10 }, 
                new Restaurant { Name = "Obao-3", Rate = 4 },
                new Restaurant { Name = "Obao-4", Rate = 8 } }; 
            return View(array); 
        }
    }
}