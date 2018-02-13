using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CoinTrust.Models;

namespace CoinTrust.DataAccessLayer
{
    public class TestCarContext : DbContext
    {
        //public TestCarContext()
        //{
        //    Database.SetInitializer(new DataAccessLayer.TestCarContextInitializer());
        //}

        public DbSet<TestCar> TestCar { get; set; }

        public DbSet<TestCarKey> TestCarKey { get; set; }

        public DbSet<TestCarWheel> TestCarWheel { get; set; }
        
        public DbSet<TestCarOwner> TestCarOwner { get; set; }
    }
}