﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoinTrust.Models;
using CoinTrust.DataAccessLayer;

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
        private DatabaseContext db = new DatabaseContext();
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "email,password,phone")] Account user)
        {
            if (ModelState.IsValid)
            {
                if (db.Account.Find(user.AccountId) != null)
                    return View("Error");
                db.Account.Add(user);
                user.CreateAt = DateTime.Now;
                user.UpdateAt = DateTime.Now;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }
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
        public ActionResult ResetPassword(Account user)
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult ForgotPassword(Account user)
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
        public ActionResult SignIn(Account user)
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