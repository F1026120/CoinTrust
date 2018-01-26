namespace CoinTrust.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using CoinTrust.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CoinTrust.Data_Access_Layer.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CoinTrust.Data_Access_Layer.UserContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var user = new List<User>
            {
                new User{ email="123@234.com", password="123", phone="0912345678", create_at=DateTime.Now, certification=false, TransactionHistories=null, update_at=DateTime.Now, use_google_authenticator=false, use_phone_authenticator=false }
            };

            user.ForEach(u => context.User.Add(u));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
