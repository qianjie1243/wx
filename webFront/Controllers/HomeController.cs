using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webFront.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/html/admin.html");
        }

        /// <summary>
        /// SQL版
        /// </summary>
        /// <returns></returns>
        public ActionResult SQLIndex()
        {
            return Redirect("/v1.1/admin.html");

           // return View();
        }     
    }
}