using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoinTrust.Models;

namespace CoinTrust.Data_Access_Layer
{
    public class DigitCoinAccountInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DigitCoinAccountContext>
    {
        protected override void Seed(DigitCoinAccountContext context)
        {
            var digitcoinaccount = new List<DigitCoinAccount> { };

        }
    }
}