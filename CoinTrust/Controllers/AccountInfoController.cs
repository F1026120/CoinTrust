using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using CoinTrust.ViewModels;
using CoinTrust.Models;
using CoinTrust.DataAccessLayer;

namespace CoinTrust.Controllers
{
    [Authorize]
    public class AccountInfoController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Info()
        {
            //var accountId = Response.Cookies[FormsAuthentication.FormsCookieName]["AccountId"];
            //var accountId2 = Request.Cookies[FormsAuthentication.FormsCookieName]["AccountId"];
            //var accountId3 = Response.Cookies["AccountId"];
            //var accountId4 = Request.Cookies["AccountId"];


            var model = new AccountInfo();
            //model.User = db.Account.Find(accountId);
            //model.LoginHistory = db.LoginHistory.Where(lh => lh.User.AccountId == accountId).ToList();

            return View(model);
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