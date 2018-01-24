using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoinTrust.Models;

namespace CoinTrust.Data_Access_Layer
{
    public class OrderInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OrderContext>
    {
        protected override void Seed(OrderContext context)
        {
            var Order = new List<Order> { };
        }
    }
}