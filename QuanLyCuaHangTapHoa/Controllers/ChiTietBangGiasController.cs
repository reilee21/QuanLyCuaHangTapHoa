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
    public class ChiTietBangGiasController : Controller
    {
        private TapHoaEntities db = new TapHoaEntities();

        // GET: ChiTietBangGias
        public ActionResult Index()
        {
            var chiTietBangGias = db.ChiTietBangGias.Include(c => c.BangGia).Include(c => c.HangHoa);
            return View(chiTietBangGias.ToList());
        }

        // GET: ChiTietBangGias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBangGia chiTietBangGia = db.ChiTietBangGias.Find(id);
            if (chiTietBangGia == null)
            {
                return HttpNotFound();
            }
            return View(chiTietBangGia);
        }

        // GET: ChiTietBangGias/Create
        public ActionResult Create()
        {
            ViewBag.MaBG = new SelectList(db.BangGias, "MaBangGia", "MaBangGia");
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa");
            return View();
        }

        // POST: ChiTietBangGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHH,MaBG,GiaBan")] ChiTietBangGia chiTietBangGia)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietBangGias.Add(chiTietBangGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBG = new SelectList(db.BangGias, "MaBangGia", "MaBangGia", chiTietBangGia.MaBG);
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa", chiTietBangGia.MaHH);
            return View(chiTietBangGia);
        }

        // GET: ChiTietBangGias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBangGia chiTietBangGia = db.ChiTietBangGias.Find(id);
            if (chiTietBangGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBG = new SelectList(db.BangGias, "MaBangGia", "MaBangGia", chiTietBangGia.MaBG);
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa", chiTietBangGia.MaHH);
            return View(chiTietBangGia);
        }

        // POST: ChiTietBangGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHH,MaBG,GiaBan")] ChiTietBangGia chiTietBangGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietBangGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBG = new SelectList(db.BangGias, "MaBangGia", "MaBangGia", chiTietBangGia.MaBG);
            ViewBag.MaHH = new SelectList(db.HangHoas, "MaHangHoa", "TenHangHoa", chiTietBangGia.MaHH);
            return View(chiTietBangGia);
        }

        // GET: ChiTietBangGias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietBangGia chiTietBangGia = db.ChiTietBangGias.Find(id);
            if (chiTietBangGia == null)
            {
                return HttpNotFound();
            }
            return View(chiTietBangGia);
        }

        // POST: ChiTietBangGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietBangGia chiTietBangGia = db.ChiTietBangGias.Find(id);
            db.ChiTietBangGias.Remove(chiTietBangGia);
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
