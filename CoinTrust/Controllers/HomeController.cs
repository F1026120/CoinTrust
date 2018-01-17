using System;
using System.Collections.Generic;
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