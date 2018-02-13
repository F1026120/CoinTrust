using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CoinTrust.Models;

namespace CoinTrust.Data_Access_Layer
{
    public class UserContext : DbContext
    {
        public DbSet<User> User { get; set; }
        
        public DbSet<DigitCoinAccount> DigitCoin { get; set; }

        public DbSet<RealCoinAccount> RealCoinAccount { get; set; }

        public DbSet<RealCoinFunds> RealCoinFins { get; set; }
    }
}