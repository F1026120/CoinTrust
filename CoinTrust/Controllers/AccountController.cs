using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoinTrust.Models;

namespace CoinTrust.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Certify()
        {
            return View();
        }
        
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(User user)
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult ForgotPassword(User user)
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(User user)
        {
            //check user information and 

            return View(user);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignOut()
        {
            return View();
        }
    }
}