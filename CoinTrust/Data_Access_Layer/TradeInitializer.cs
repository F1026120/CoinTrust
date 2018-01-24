using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoinTrust.Models;
namespace CoinTrust.Data_Access_Layer
{
    public class TradeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TradeContext>
    {
        protected override void Seed(TradeContext context)
        {
            var Trade = new List<Trade> { };
        }
    }
}