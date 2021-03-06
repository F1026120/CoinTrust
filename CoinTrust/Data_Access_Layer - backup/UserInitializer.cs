﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoinTrust.Models;

namespace CoinTrust.Data_Access_Layer
{
    //public class UserInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UserContext>

    public class UserInitializer : System.Data.Entity.DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var user = new List<User>
            {
                new User{ email="123@234.com", password="123", phone="0912345678", create_at=DateTime.Now, certification=false, update_at=DateTime.Now, use_google_authenticator=false, use_phone_authenticator=false }
            };

            user.ForEach(u => context.User.Add(u));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}