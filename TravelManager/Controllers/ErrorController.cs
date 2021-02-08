using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TravelManager.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error(string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<h1 style='color:red;'>Error</h1>");
            sb.Append("<br/>");
            sb.Append("<b>" + "</b>");
            sb.Append("<br/>");
            sb.Append("<br/>");
            sb.Append("<a style='font-size:20'  href='/Home/Index'>Back to Home page</a>");
            return Content(sb.ToString());
        }
    }
}