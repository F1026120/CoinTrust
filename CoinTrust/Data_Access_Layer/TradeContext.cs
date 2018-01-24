using CoinTrust.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoinTrust.Data_Access_Layer
{
    public class TradeContext : DbContext
    {
        public DbSet<Trade> Trade { get; set; }
    }
}