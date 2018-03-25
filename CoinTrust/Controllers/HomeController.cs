using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoinTrust.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string id = "0")
        {
            ViewBag.id = id;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            Debug.WriteLine("2131231231233212319");

            Debug.WriteLine(HttpContext.Request.Cookies.Count);
            foreach (var k in HttpContext.Request.Cookies.Keys)
            {
                Debug.WriteLine(k);
            }
            HttpContext.Request.Cookies.Clear();
            Debug.WriteLine(HttpContext.Request.Cookies.Count);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Market()
        {
            return View();
        }
    }
}