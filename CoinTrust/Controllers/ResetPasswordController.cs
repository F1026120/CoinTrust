using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoinTrust.Models;
using CoinTrust.ViewModels;
using CoinTrust.DataAccessLayer;

namespace CoinTrust.Controllers
{
    [Authorize]
    public class ResetPasswordController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: ResetPassword/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: ResetPassword/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "email,old_password,password,confirm_password")] ResetPassword user)
        {
            try
            {
                // TODO: Add update logic here
                var the_user = db.Account.Find(user.email);
                if (the_user != null && the_user.Password == user.old_password)
                    if (user.password == user.confirm_password)
                    {
                        the_user.Password = user.password;
                        db.SaveChanges();
                    }
                return RedirectToRoute("default");
            }
            catch
            {
                return View();
            }
        }
    }
}
