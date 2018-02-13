using CoinTrust.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace CoinTrust.Data_Access_Layer
{
    public class HistoryContext : DbContext
    {
        public DbSet<TransactionHistory> TransactionHistories { get; set; }

        public DbSet<LogonHistory> LogonHistory { get; set; }
    }
}