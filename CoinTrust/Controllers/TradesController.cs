using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CoinTrust.DataAccessLayer;
using CoinTrust.Models;

namespace CoinTrust.Controllers
{
    [Authorize]
    public class TradesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Trades
        public ActionResult Index()
        {
            return View(db.Trade.ToList());
        }

        // GET: Trades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trade trade = db.Trade.Find(id);
            if (trade == null)
            {
                return HttpNotFound();
            }
            return View(trade);
        }

        [HttpGet]
        public ActionResult Buy(int? OrderId)
        {
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            var order = db.Order.Find(OrderId);
            if (order.Seller.AccountId == accountId)
            {
                ViewBag.Message = "無法對自己下單";
                return View("Error");
            }
            return View(order);
        }

        [HttpGet]
        public ActionResult BuyConfirm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            if (order == null)
            {
                return HttpNotFound();
            }
            else if (order.OrderStatus != OrderStatus.New &&
                    order.OrderStatus != OrderStatus.PartialFilled)
            {
                ViewBag.Message = "訂單已完售請重新選擇";
                return View("Error");
            }
            else if (order.Seller.AccountId == accountId)
            {
                ViewBag.Message = "無法對自己的訂單下單，轉至訂單管理頁面";
                return RedirectToAction("List", "Orders");
            }

            return View(order);
        }

        [HttpPost]
        public ActionResult UpdateTxhash(string TxHash, int TradeId)
        {
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            var Trade = db.Trade.Find(TradeId);
            if (Trade.Order.Seller.AccountId != accountId) return View("Error");
            Trade.TxHash = TxHash;
            Trade.TradeStatus = TradeStatus.Sended;
            db.SaveChanges();



            return RedirectToAction("ListTrade", "Trades");

        }


        [HttpPost]
        public ActionResult CreateTrade([Bind(Include = "Quantity,BuyerAddress")] Trade POST_trade, int OrderId)//建立交易訂單
        {
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            var order = db.Order.Find(OrderId);
            if (order.Seller.AccountId == accountId)
            {
                ViewBag.Message = "無法對自己下單";
                return View("Error");
            }
            POST_trade.TradeStatus = TradeStatus.Trading;
            POST_trade.Order = db.Order.Find(OrderId);
            POST_trade.CreateAt = DateTime.Now;
            POST_trade.Buyer = db.Account.Find(accountId);
            db.Trade.Add(POST_trade);
            POST_trade.Order.Quantity -= POST_trade.Quantity;
            if (POST_trade.Order.Quantity == 0)
                POST_trade.Order.OrderStatus = OrderStatus.Filled;
            else
                POST_trade.Order.OrderStatus = OrderStatus.PartialFilled;
            db.SaveChanges();
            Helper.EmailHelper emailHelper = new Helper.EmailHelper();//填入通知信內容
            string msg = "";
            msg += "訂單已被下訂，買家ID:" + POST_trade.Buyer.AccountId;
            msg += "\r\n購買數量:" + POST_trade.Quantity;
            msg += "\r\n購買單價:" + POST_trade.Order.Price;
            msg += "\r\n購買總價:" + POST_trade.Quantity * POST_trade.Order.Price;
            msg += "\r\n點選連結查看訂單內容: http://CoinTrust.myddns.me:50655/Trades/Trading/" + POST_trade.TradeId;
            emailHelper.SendToEmailWithSubjectAndMsg(POST_trade.Order.Seller.AccountId, "訂單被下訂", msg);
            return RedirectToAction("ListTrade", "Trades");
        }

        public ActionResult ListTrade()//列出Trade
        {

            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            ViewBag.Account = accountId;
            var trade = db.Trade.Where(m => (m.Buyer.AccountId == accountId || m.Order.Seller.AccountId == accountId) && (m.TradeStatus == TradeStatus.Trading || m.TradeStatus == TradeStatus.Sended)).ToList();

            return View(trade);

        }



        [HttpGet]
        public ActionResult Trading(int? TradeId)//交易中的訂單
        {
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            var trade = db.Trade.Find(TradeId);
            if (trade.Buyer.AccountId == accountId)
                return View(trade);
            else if (trade.Order.Seller.AccountId == accountId)
                return View(trade);
            else
            {
                ViewBag.Message = "您不是訂單所有人";

                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Cancel(int? TradeId)
        {
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            var Trade = db.Trade.Find(TradeId);
            if (accountId == Trade.Order.Seller.AccountId || accountId == Trade.Buyer.AccountId)
            {
                Trade.TradeStatus = TradeStatus.Canceled;

                db.SaveChanges();
                return RedirectToAction("ListTrade", "Trades");

            }
            else
            {
                ViewBag.Message = "你不是訂單的所有人";
                return View("Error");
            }

        }

        [HttpPost]
        public ActionResult TradeFinish(int? TradeId)
        {
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            var Trade = db.Trade.Find(TradeId);
            if (accountId == Trade.Buyer.AccountId)
            {
                Trade.TradeStatus = TradeStatus.finished;
                db.SaveChanges();
                return RedirectToAction("ListTrade", "Trades");
            }
            ViewBag.Message = "你不是訂單的所有人";
            return View("Error");
        }

        [HttpGet]
        public ActionResult ShowTxHash(int? TradeId)
        {

            var Trade = db.Trade.Find(TradeId);

            Helper.TransactionByTxhash transactionByTxhash = new Helper.TransactionByTxhash(Trade.TxHash);
            ViewBag.value = transactionByTxhash.Quantity;


            return View();
        }


    }
}
