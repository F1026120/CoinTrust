using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CoinTrust.Models;

namespace CoinTrust.Data_Access_Layer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<DigitCoinAccount> DigitCoin { get; set; }

        public DbSet<RealCoinAccount> RealCoinAccount { get; set; }

        public DbSet<RealCoinFunds> RealCoinFins { get; set; }

        public DbSet<Trade> Trade { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<TransactionHistory> TransactionHistories { get; set; }

        public DbSet<LogonHistory> LogonHistory { get; set; }

        public DbSet<RealCoinType> RealCoinType { get; set; }

        public DbSet<DigitCoinType> DigitCoinType { get; set; }

    }
}