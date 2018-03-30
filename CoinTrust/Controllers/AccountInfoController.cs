using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Diagnostics;

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
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;

            var model = new AccountInfo();
            model.User = db.Account.Find(accountId);
            model.LoginHistory = db.LoginHistory.Where(m => m.User.AccountId == accountId).ToList();
            model.DigitCoinAccount = db.DigitCoinAccount.Where(m => m.User.AccountId == accountId).ToList();
            //model.RealCoinAccount = db.RealCoinAccount.Where(model,model.User.AccountId == accountId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult ChangePhoneAuth(bool isUse)
        //public ViewResult ChangePhoneAuth()
        public ActionResult ChangePhoneAuth()
        {
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            var account = db.Account.Find(accountId);
            account.UsePhoneAuthenticator = !account.UsePhoneAuthenticator;
            db.SaveChanges();

            var model = new AccountInfo();
            model.User = account;
            model.LoginHistory = db.LoginHistory.Where(m => m.User.AccountId == accountId).ToList();

            //if (Request.IsAjaxRequest())
            // 如果回傳空的view  他會自己去嘗試載入  "AccountInfo/ChangePhoneAuth"的view  
            //目前就插在怎麼render partial的view了 

            // 因為這個controller只會處理這一項項目所以 我就always回partial
            Debug.WriteLine("1");
            //return View("_PhoneAuthenticator", "Info", model);
            return View("Info", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public bool ChangeGoogleAuth()
        {
            return false;
        }


        //[ValidateAntiForgeryToken]
        public ActionResult BankAccountManger()
        {
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            var account = db.Account.Find(accountId);
            var model = new RealCoinAccount();

            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult BankAccountEdit([Bind(Include = "Address, BankName")]RealCoinAccount POST_realCoinAccount)
        {

            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            var account = db.Account.Find(accountId);

            if (account != null && db.RealCoinAccount.Where(m => m.User.AccountId == account.AccountId) != null)
            {
                var DB_RealCoinAccount = new RealCoinAccount();
                DB_RealCoinAccount.Address = POST_realCoinAccount.Address;
                DB_RealCoinAccount.BankName = POST_realCoinAccount.BankName;

                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    return Content("資料儲存失敗 請聯絡管理員");
                }
            }
            else if (account == null) return Content("找不到此ID 請重新登入");
            else if (db.RealCoinAccount.Where(m => m.User == account) == null) return Content("尚未設定銀行帳號");

            return View("BankAccountManger");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult BankAccountAdd([Bind(Include = "Address, BankName")]RealCoinAccount POST_realCoinAccount)
        {
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            var account = db.Account.Find(accountId);
            if (account == null) return Content("找不到此ID 請重新登入");
            else if (db.RealCoinAccount.Where(m => m.User.AccountId == account.AccountId) != null) return Content("已設定銀行帳號");
            else
            {
                var DB_RealCoinAccount = new RealCoinAccount();
                DB_RealCoinAccount.User = account;
                DB_RealCoinAccount.Address = POST_realCoinAccount.Address;
                DB_RealCoinAccount.BankName = POST_realCoinAccount.BankName;
                try
                {
                    db.RealCoinAccount.Add(DB_RealCoinAccount);
                    db.SaveChanges();
                }
                catch
                {
                    return Content("資料儲存失敗 請聯絡管理員");
                }
            }

            return View("BankAccountManger");
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