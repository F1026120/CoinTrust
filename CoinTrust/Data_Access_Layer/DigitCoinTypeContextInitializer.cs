using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoinTrust.Models;

namespace CoinTrust.Data_Access_Layer
{
    public class DigitCoinTypeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DigitCoinTypeContext>
    {
        protected override void Seed(DigitCoinTypeContext context)
        {
            var DigitCoinType = new List<DigitCoinType> { };
        }
    }
}