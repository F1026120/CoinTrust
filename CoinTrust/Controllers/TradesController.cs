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
        public ActionResult Buy(int? id)
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
                return Content("訂單已完售請重新選擇");
            }
            else if (order.Seller.AccountId == accountId)
            {
                return RedirectToAction("List","Orders");
            }
            
                
            return View(order);
        }

        [HttpPost]
        public ActionResult BuyConfirm([Bind(Include = "Quantity,BuyerAddress")] Trade POST_trade,int Orderid)
        {
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            POST_trade.TradeStatus = TradeStatus.Trading;
            POST_trade.Order = db.Order.Find(Orderid);
            POST_trade.CreateAt = DateTime.Now;
            POST_trade.Buyer = db.Account.Find(accountId);
            db.SaveChanges();
            Helper.EmailHelper emailHelper = new Helper.EmailHelper();
            string msg = "";
            emailHelper.SendToEmailWithSubjectAndMsg(POST_trade.Order.Seller.AccountId, "訂單被下訂", msg);

            return View();
        }



        // GET: Trades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TradeId,Quantity,TradeStatus,CreateAt")] Trade trade)
        {
            if (ModelState.IsValid)
            {
                db.Trade.Add(trade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trade);
        }

        // GET: Trades/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Trades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TradeId,Quantity,TradeStatus,CreateAt")] Trade trade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trade);
        }

        // GET: Trades/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Trades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trade trade = db.Trade.Find(id);
            db.Trade.Remove(trade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
