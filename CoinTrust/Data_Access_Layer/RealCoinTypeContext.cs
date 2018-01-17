﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CoinTrust.Models;

namespace CoinTrust.Data_Access_Layer
{
    public class RealCoinTypeContext : DbContext
    {
        public DbSet<RealCoinType> RealCoinType { get; set; }
    }
}