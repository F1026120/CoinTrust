using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoinTrust.Models;
namespace CoinTrust.Data_Access_Layer
{
    public class LogonHistoryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LogonHistoryContext>
    {
        protected override void Seed(LogonHistoryContext context)
        {
            var LogonHistory = new List<LogonHistory> { };
        }
    }
}