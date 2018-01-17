using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoinTrust.Controllers
{
    [Authorize]
    public class AccountInfoController : Controller
    {
        public ActionResult Info()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePhoneAuth()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeGoogleAuth()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BankAccountAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BankAccountDelete(int id)
        {
            return View();
        }

        public ActionResult TradeHistory()
        {
            return View();
        }

        public ActionResult OrderHistory()
        {
            return View();
        }
    }
}