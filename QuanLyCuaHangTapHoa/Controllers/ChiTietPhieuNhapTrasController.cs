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
    public class ChiTietPhieuNhapTrasController : Controller
    {
        private TapHoaEntities db = new TapHoaEntities();

        // GET: ChiTietPhieuNhapTras
        public ActionResult Index()
        {
            var chiTietPhieuNhapTras = db.ChiTietPhieuNhapTras.Include(c => c.HangHoa).Include(c => c.NhaCungCap).Include(c => c.PhieuNhapTra);
            return View(chiTietPhieuNhapTras.ToList());
        }

        // GET: ChiTietPhieuNhapTras/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhapTra chiTietPhieuNhapTra = db.ChiTietPhieuNhapTras.Find(id);
            if (chiTietPhieuNhapTra == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuNhapTra);
        }

        // GET: ChiTietPhieuNhapTras/Create
        public ActionResult Create()
        {
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa");
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap");
            ViewBag.MaPhieu = new SelectList(db.PhieuNhapTras, "MaPhieu", "MaPhieu");
            return View();
        }

        // POST: ChiTietPhieuNhapTras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHH,MaPhieu,MaNhaCungCap,TenNhaCungCap,DonGia,SoLuong")] ChiTietPhieuNhapTra chiTietPhieuNhapTra)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietPhieuNhapTras.Add(chiTietPhieuNhapTra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa", chiTietPhieuNhapTra.MaHH);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", chiTietPhieuNhapTra.MaNhaCungCap);
            ViewBag.MaPhieu = new SelectList(db.PhieuNhapTras, "MaPhieu", "MaPhieu", chiTietPhieuNhapTra.MaPhieu);
            return View(chiTietPhieuNhapTra);
        }

        // GET: ChiTietPhieuNhapTras/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhapTra chiTietPhieuNhapTra = db.ChiTietPhieuNhapTras.Find(id);
            if (chiTietPhieuNhapTra == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa", chiTietPhieuNhapTra.MaHH);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", chiTietPhieuNhapTra.MaNhaCungCap);
            ViewBag.MaPhieu = new SelectList(db.PhieuNhapTras, "MaPhieu", "MaPhieu", chiTietPhieuNhapTra.MaPhieu);
            return View(chiTietPhieuNhapTra);
        }

        // POST: ChiTietPhieuNhapTras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHH,MaPhieu,MaNhaCungCap,TenNhaCungCap,DonGia,SoLuong")] ChiTietPhieuNhapTra chiTietPhieuNhapTra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietPhieuNhapTra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa", chiTietPhieuNhapTra.MaHH);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", chiTietPhieuNhapTra.MaNhaCungCap);
            ViewBag.MaPhieu = new SelectList(db.PhieuNhapTras, "MaPhieu", "MaPhieu", chiTietPhieuNhapTra.MaPhieu);
            return View(chiTietPhieuNhapTra);
        }

        // GET: ChiTietPhieuNhapTras/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhieuNhapTra chiTietPhieuNhapTra = db.ChiTietPhieuNhapTras.Find(id);
            if (chiTietPhieuNhapTra == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhieuNhapTra);
        }

        // POST: ChiTietPhieuNhapTras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietPhieuNhapTra chiTietPhieuNhapTra = db.ChiTietPhieuNhapTras.Find(id);
            db.ChiTietPhieuNhapTras.Remove(chiTietPhieuNhapTra);
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
