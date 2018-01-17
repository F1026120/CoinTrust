using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoinTrust.Models;

namespace CoinTrust.Data_Access_Layer
{
    public class TransactionHistoryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TransactionHistoryContext>
    {
        protected override void Seed(TransactionHistoryContext context)
        {
            var hist = new List<TransactionHistory>
            {
                new TransactionHistory { id=1, create_at=DateTime.Now}
            };

            hist.ForEach(n => context.TransactionHistories.Add(n));
            context.SaveChanges();
        }
    }
}