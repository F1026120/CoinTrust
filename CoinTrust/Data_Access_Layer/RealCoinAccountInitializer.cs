using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoinTrust.Models;

namespace CoinTrust.Data_Access_Layer
{
    public class RealCoinAccountInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RealCoinAccountContext>
    {
        protected override void Seed(RealCoinAccountContext context)
        {
            var RealCoinAccount = new List<RealCoinAccount> { };
        }
    }
}