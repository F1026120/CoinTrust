using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CoinTrust.Models;

namespace CoinTrust.DataAccessLayer
{
    public class DatabaseContextInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(CoinTrust.DataAccessLayer.DatabaseContext context)
        {
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //to avoid creating duplicate seed data.

            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //to avoid creating duplicate seed data.

            Account yy = new Account { Certification = false, Password = "123456", Phone = "0912345678", UseGoogleAuthenticator = true, UsePhoneAuthenticator = true, CreateAt = DateTime.Now, UpdateAt = DateTime.Now, ConfirmPassword = "123456", AccountId = "test@cointrust.com" };
            context.Account.Add(yy);
            Account pl = new Account { Certification = false, Password = "654321", Phone = "0987654321", UseGoogleAuthenticator = true, UsePhoneAuthenticator = true, CreateAt = DateTime.Now, UpdateAt = DateTime.Now, ConfirmPassword = "654321", AccountId = "test2@cointrust.com" };
            context.Account.Add(pl);
            context.SaveChanges();

            DigitCoinType eth_type = new DigitCoinType { Name = "eth", AddressRegex = "[0-9]{10}" };
            context.DigitCoinType.Add(eth_type);
            context.SaveChanges();

            DigitCoinAccount eth = new DigitCoinAccount { User = yy, DigitCoinType = eth_type, Address = "1234567890" };
            context.DigitCoinAccount.Add(eth);
            context.SaveChanges();

            LoginHistory first = new LoginHistory { Ip = "123.456.789.147", User = yy, Locale = "Taichung", LoginAt = DateTime.Now };
            context.LoginHistory.Add(first);
            context.SaveChanges();

            Order or1 = new Order { Address = "9876543210", CreateAt = DateTime.Now, DigitCoinType = eth_type, MinQuantity = 1, OrderStatus = OrderStatus.New, Price = 900, Quantity = 5, RemainQuantity = 5, Seller = yy, UpdateAt = DateTime.Now};
            context.Order.Add(or1);
            context.SaveChanges();

            RealCoinType ntd_type = new RealCoinType { Name = "NTD" };
            context.RealCoinType.Add(ntd_type);
            context.SaveChanges();

            RealCoinFund plf = new RealCoinFund { Amount = 1000, User = pl, RealCoinType = ntd_type, CoinStatus = CoinStatus.Free };
            context.RealCoinFund.Add(plf);
            context.SaveChanges();

            RealCoinAccount pla = new RealCoinAccount { User = pl, Address = "1234123412341234", RealCoinType = ntd_type };
            context.RealCoinAccount.Add(pla);
            context.SaveChanges();

            Trade t1 = new Trade { Buyer = pl, Order = or1, CreateAt = DateTime.Now, Quantity = 1, TradeStatus = TradeStatus.Filled };
            or1.RemainQuantity -= 1;
            or1.OrderStatus = OrderStatus.PartialFilled;
            context.Trade.Add(t1);
            context.SaveChanges();

            Trade t2 = new Trade { Buyer = pl, Order = or1, CreateAt = DateTime.Now, Quantity = 1, TradeStatus = TradeStatus.Canceled };
            context.Trade.Add(t2);
            context.SaveChanges();

            TransactionHistory th = new TransactionHistory { Amount = 500, CreateAt = DateTime.Now, RealCoinType = ntd_type, TransactionStatus = TransactionStatus.Pending, User = pl, UpdateAt = DateTime.Now };
            context.TransactionHistory.Add(th);
            context.SaveChanges();
        }
    }
}