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
    public class ChiTietThongKesController : Controller
    {
        private TapHoaEntities db = new TapHoaEntities();

        // GET: ChiTietThongKes
        public ActionResult Index()
        {
            var chiTietThongKes = db.ChiTietThongKes.Include(c => c.ThongKeDoanhThu);
            return View(chiTietThongKes.ToList());
        }

        // GET: ChiTietThongKes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietThongKe chiTietThongKe = db.ChiTietThongKes.Find(id);
            if (chiTietThongKe == null)
            {
                return HttpNotFound();
            }
            return View(chiTietThongKe);
        }

        // GET: ChiTietThongKes/Create
        public ActionResult Create()
        {
            ViewBag.MaTKDT = new SelectList(db.ThongKeDoanhThus, "MaTKDT", "TenThongKe");
            return View();
        }

        // POST: ChiTietThongKes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,GiaTri,MaTKDT")] ChiTietThongKe chiTietThongKe)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietThongKes.Add(chiTietThongKe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTKDT = new SelectList(db.ThongKeDoanhThus, "MaTKDT", "TenThongKe", chiTietThongKe.MaTKDT);
            return View(chiTietThongKe);
        }

        // GET: ChiTietThongKes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietThongKe chiTietThongKe = db.ChiTietThongKes.Find(id);
            if (chiTietThongKe == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTKDT = new SelectList(db.ThongKeDoanhThus, "MaTKDT", "TenThongKe", chiTietThongKe.MaTKDT);
            return View(chiTietThongKe);
        }

        // POST: ChiTietThongKes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,GiaTri,MaTKDT")] ChiTietThongKe chiTietThongKe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietThongKe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTKDT = new SelectList(db.ThongKeDoanhThus, "MaTKDT", "TenThongKe", chiTietThongKe.MaTKDT);
            return View(chiTietThongKe);
        }

        // GET: ChiTietThongKes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietThongKe chiTietThongKe = db.ChiTietThongKes.Find(id);
            if (chiTietThongKe == null)
            {
                return HttpNotFound();
            }
            return View(chiTietThongKe);
        }

        // POST: ChiTietThongKes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietThongKe chiTietThongKe = db.ChiTietThongKes.Find(id);
            db.ChiTietThongKes.Remove(chiTietThongKe);
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
