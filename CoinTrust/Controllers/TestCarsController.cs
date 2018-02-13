using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoinTrust.DataAccessLayer;
using CoinTrust.Models;

namespace CoinTrust.Controllers
{
    public class TestCarsController : Controller
    {
        private TestCarContext db = new TestCarContext();

        // GET: TestCars
        public ActionResult Index()
        {
            return View(db.TestCar.ToList());
        }

        // GET: TestCars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestCar testCar = db.TestCar.Find(id);
            if (testCar == null)
            {
                return HttpNotFound();
            }
            return View(testCar);
        }

        // GET: TestCars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestCars/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestCarId,new_name,confirm_name")] TestCar testCar)
        {
            if (ModelState.IsValid)
            {
                db.TestCar.Add(testCar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testCar);
        }

        // GET: TestCars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestCar testCar = db.TestCar.Find(id);
            if (testCar == null)
            {
                return HttpNotFound();
            }
            return View(testCar);
        }

        // POST: TestCars/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestCarId,new_name,confirm_name")] TestCar testCar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testCar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testCar);
        }

        // GET: TestCars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestCar testCar = db.TestCar.Find(id);
            if (testCar == null)
            {
                return HttpNotFound();
            }
            return View(testCar);
        }

        // POST: TestCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestCar testCar = db.TestCar.Find(id);
            db.TestCar.Remove(testCar);
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
