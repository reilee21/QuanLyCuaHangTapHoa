using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyCuaHangTapHoa.Models;

namespace QuanLyCuaHangTapHoa.Controllers
{
    public class ThongKeDoanhThusController : Controller
    {
        private TapHoaEntities db = new TapHoaEntities();

        // GET: ThongKeDoanhThus
        public ActionResult Index()
        {
            return View(db.ThongKeDoanhThus.ToList());
        }

        // GET: ThongKeDoanhThus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongKeDoanhThu thongKeDoanhThu = db.ThongKeDoanhThus.Find(id);
            if (thongKeDoanhThu == null)
            {
                return HttpNotFound();
            }
            return View(thongKeDoanhThu);
        }

        // GET: ThongKeDoanhThus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThongKeDoanhThus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTKDT,TenThongKe,TuNgay,DenNgay,DoanhThu")] ThongKeDoanhThu thongKeDoanhThu)
        {
            if (ModelState.IsValid)
            {
                db.ThongKeDoanhThus.Add(thongKeDoanhThu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongKeDoanhThu);
        }

        // GET: ThongKeDoanhThus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongKeDoanhThu thongKeDoanhThu = db.ThongKeDoanhThus.Find(id);
            if (thongKeDoanhThu == null)
            {
                return HttpNotFound();
            }
            return View(thongKeDoanhThu);
        }

        // POST: ThongKeDoanhThus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTKDT,TenThongKe,TuNgay,DenNgay,DoanhThu")] ThongKeDoanhThu thongKeDoanhThu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongKeDoanhThu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongKeDoanhThu);
        }

        // GET: ThongKeDoanhThus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongKeDoanhThu thongKeDoanhThu = db.ThongKeDoanhThus.Find(id);
            if (thongKeDoanhThu == null)
            {
                return HttpNotFound();
            }
            return View(thongKeDoanhThu);
        }

        // POST: ThongKeDoanhThus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThongKeDoanhThu thongKeDoanhThu = db.ThongKeDoanhThus.Find(id);
            db.ThongKeDoanhThus.Remove(thongKeDoanhThu);
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
