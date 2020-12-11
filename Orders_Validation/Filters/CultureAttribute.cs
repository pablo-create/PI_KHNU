using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace Orders_Validation.Filters
{
    public class CultureAttribute : System.Web.Mvc.FilterAttribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string cultureName = null; 
            HttpCookie cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
            if (cultureCookie != null) cultureName = cultureCookie.Value; 
            else cultureName = "uk"; 
            List<string> cultures = new List<string>() { "uk", "en"}; 
            if (!cultures.Contains(cultureName)) { cultureName = "uk"; } 
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName); 
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName); 
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
          //  throw new NotImplementedException();
        }
    }
}