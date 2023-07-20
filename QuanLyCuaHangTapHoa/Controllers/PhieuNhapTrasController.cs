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
    public class PhieuNhapTrasController : Controller
    {
        private TapHoaEntities db = new TapHoaEntities();

        // GET: PhieuNhapTras
        public ActionResult Index()
        {
            return View(db.PhieuNhapTras.ToList());
        }

        // GET: PhieuNhapTras/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapTra phieuNhapTra = db.PhieuNhapTras.Find(id);
            if (phieuNhapTra == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapTra);
        }

        // GET: PhieuNhapTras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhieuNhapTras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieu,TongSoTien,TongSoLuong,LoaiPhieu")] PhieuNhapTra phieuNhapTra)
        {
            if (ModelState.IsValid)
            {
                db.PhieuNhapTras.Add(phieuNhapTra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phieuNhapTra);
        }

        // GET: PhieuNhapTras/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapTra phieuNhapTra = db.PhieuNhapTras.Find(id);
            if (phieuNhapTra == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapTra);
        }

        // POST: PhieuNhapTras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieu,TongSoTien,TongSoLuong,LoaiPhieu")] PhieuNhapTra phieuNhapTra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuNhapTra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phieuNhapTra);
        }

        // GET: PhieuNhapTras/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuNhapTra phieuNhapTra = db.PhieuNhapTras.Find(id);
            if (phieuNhapTra == null)
            {
                return HttpNotFound();
            }
            return View(phieuNhapTra);
        }

        // POST: PhieuNhapTras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PhieuNhapTra phieuNhapTra = db.PhieuNhapTras.Find(id);
            db.PhieuNhapTras.Remove(phieuNhapTra);
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
