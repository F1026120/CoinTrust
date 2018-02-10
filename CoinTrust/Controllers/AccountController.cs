using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoinTrust.Models;
using CoinTrust.Data_Access_Layer;

/*
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([Bind(Include = "email,password,phone,certification,use_phone_authenticator,use_google_authenticator,create_at,update_at")] User user)
{
    if (ModelState.IsValid)
    {
        db.User.Add(user);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    return View(user);
}

    */


namespace CoinTrust.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserContext db = new UserContext();
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "email,password,phone")] User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            //return RedirectToAction("Index");
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