using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoinTrust.Models;

namespace CoinTrust.Data_Access_Layer
{
    public class RealCoinFundsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RealCoinFundsContext>
    {
        protected override void Seed(RealCoinFundsContext context)
        {
            var RealCoinFunds = new List<RealCoinFunds> { };
        }
    }
}