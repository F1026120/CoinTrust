using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CoinTrust.Models;

namespace CoinTrust.DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Account> Account{ get; set; }

        public DbSet<LoginHistory> LoginHistory { get; set; }

        public DbSet<DigitCoinAccount> DigitCoinAccount { get; set; }

        public DbSet<DigitCoinType> DigitCoinType { get; set; }

        public DbSet<RealCoinAccount> RealCoinAccount { get; set; }

        public DbSet<RealCoinType> RealCoinType { get; set; }

        public DbSet<RealCoinFund> RealCoinFund { get; set; }

        public DbSet<Trade> Trade { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<TransactionHistory> TransactionHistory { get; set; }

        public System.Data.Entity.DbSet<CoinTrust.ViewModels.ResetPassword> ResetPasswords { get; set; }
    }
}