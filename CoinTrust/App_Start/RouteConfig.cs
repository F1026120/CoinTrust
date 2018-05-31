using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CoinTrust
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
                name: "TransactionHistories",
                url: "user/info/CamelCaseTransactionHistories/{action}/{id}",
                defaults: new { controller = "TransactionHistories", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "CertifyEmail",
                url: "Account/{action}/{id}/{code}",
                defaults: new { controller = "Account", action = "CertifyEmail", id = UrlParameter.Optional, code = UrlParameter.Optional }//帳號認證
            );

            routes.MapRoute(
                name: "Account",
                url: "Account/{action}",
                defaults: new { controller = "Account", action = "SignIn" }
            );

            routes.MapRoute(
                name: "Buy",
                url: "Trades/Buy/{OrderId}",
                defaults: new { controller = "Trades", action = "Buy" }
            );

            routes.MapRoute(
                name: "Trading",
                url: "Trades/Trading/{TradeId}",
                defaults: new { controller = "Trades", action = "trading" }
            );
            routes.MapRoute(
               name: "Cancel",
                url: "Trades/Cancel/{TradeId}",
              defaults: new { controller = "Trades", action = "Cancel" }
            );
            routes.MapRoute(
                name: "ShowTxHash",
                 url: "Trades/ShowTxHash/{TradeId}",
               defaults: new { controller = "Trades", action = "ShowTxHash" }
             );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
