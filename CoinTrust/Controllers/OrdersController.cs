using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CoinTrust.DataAccessLayer;
using CoinTrust.Models;
using System.Diagnostics;

namespace CoinTrust.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Order.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/CreateOrder
        //[ValidateAntiForgeryToken]
        public ActionResult CreateOrder()
        {
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;


            return View();
        }

        // POST: Orders/CreateOrder
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrder([Bind(Include = "Price,Quantity,MinQuantity,Address")] Order order)
        {


            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            try { order.Seller = db.Account.Find(accountId); } catch { return Content("DB accountid not found"); }
            if (order.MinQuantity < 0 || order.MinQuantity > order.Quantity) return Content("最低數量設定錯誤");
            order.RemainQuantity = order.Quantity;
            order.CreateAt = DateTime.Now;
            order.UpdateAt = DateTime.Now;
            Account seller = db.Account.Find(accountId);
            order.Seller = seller;
            DigitCoinType digitCoinType = db.DigitCoinType.Find("ETH");
            order.DigitCoinType = digitCoinType;
            order.OrderStatus = OrderStatus.New;
            Helper.ETHAddressHelper EAH = new Helper.ETHAddressHelper();
            if (!(EAH.IsValid(order.Address)))
            {
                @ViewBag.Title = "訂單建立錯誤";
                ViewBag.Message = "Address 格式錯誤 訂單建立失敗 請再確認" + order.Address;
                return View("Error");
            }
            if (EAH.GetBalance(order.Address) < order.Quantity)
            {
                @ViewBag.Title = "訂單建立錯誤";
                ViewBag.Message = "Address ETH餘額不足 訂單建立失敗 餘額為" + EAH.GetBalance(order.Address);
                return View("Error");
            }
            db.Order.Add(order);
            try { db.SaveChanges(); }
            catch
            {
                return Content("DB faid");
            }
            return RedirectToAction("List");
            //return Content("訂單建立成功");


            //return View(order);
        }
        public ActionResult List()
        {
            var accountId = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).UserData;
            var order = db.Order.Where(m => m.Seller.AccountId == accountId &&
                                            (m.OrderStatus == OrderStatus.New ||
                                            m.OrderStatus == OrderStatus.PartialFilled
                                            )).ToList();


            return View(order);

        }


        // GET: Orders/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
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
            else if (order.Seller.AccountId == accountId)
            {
                order.OrderStatus = OrderStatus.Canceled;
                db.SaveChanges();
            }

            else { return Content("刪除失敗 :使用者ID錯誤"); }
            return RedirectToAction("List");
        }

    }
}
