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

            /*
            home page
            account 
            deposit/withdraw
            trade history
            logon history
            


            About us
            Login/Logout
            Order Creat/Delete
            Show order of market
            

            
            */

            routes.MapRoute(
                name: "TransactionHistories",
                url: "user/info/CamelCaseTransactionHistories/{action}/{id}",
                defaults: new { controller = "TransactionHistories", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Account",
                url: "Account/{action}",
                defaults: new { controller = "Account", action = "Info" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
