using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CoinTrust.Models;

namespace CoinTrust.DataAccessLayer
{
    public class DatabaseContextInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(CoinTrust.DataAccessLayer.DatabaseContext context)
        {
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //to avoid creating duplicate seed data.

            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //to avoid creating duplicate seed data.

        }
    }
}