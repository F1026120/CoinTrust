using CoinTrust.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoinTrust.Models;

namespace CoinTrust.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
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
            var OrderList = db.Order.Where(o => o.OrderStatus == OrderStatus.New ||
                                            o.OrderStatus == OrderStatus.PartialFilled
                                            ).ToList();



            return View(OrderList);
        }
    }
}