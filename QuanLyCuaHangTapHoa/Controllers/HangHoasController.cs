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
    public class HangHoasController : Controller
    {
        private TapHoaEntities db = new TapHoaEntities();

        // GET: HangHoas
        public ActionResult Index()
        {
            var hangHoas = db.HangHoas.Include(h => h.DonViTinh).Include(h => h.NhaCungCap).Include(h => h.Thue);
            return View(hangHoas.ToList());
        }

        // GET: HangHoas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // GET: HangHoas/Create
        public ActionResult Create()
        {
            ViewBag.MaDVT = new SelectList(db.DonViTinhs, "MaDVT", "TenDVT");
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap");
            ViewBag.MaThue = new SelectList(db.Thues, "MaThue", "TenThue");
            return View();
        }

        // POST: HangHoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHangHoa,TenHangHoa,SoLuong,GiaVon,GiaBan,TinhTrang,AnhMoTa,MaDVT,MucThue,MaThue,MaNhaCungCap")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                db.HangHoas.Add(hangHoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDVT = new SelectList(db.DonViTinhs, "MaDVT", "TenDVT", hangHoa.MaDVT);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", hangHoa.MaNhaCungCap);
            ViewBag.MaThue = new SelectList(db.Thues, "MaThue", "TenThue", hangHoa.MaThue);
            return View(hangHoa);
        }

        // GET: HangHoas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDVT = new SelectList(db.DonViTinhs, "MaDVT", "TenDVT", hangHoa.MaDVT);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", hangHoa.MaNhaCungCap);
            ViewBag.MaThue = new SelectList(db.Thues, "MaThue", "TenThue", hangHoa.MaThue);
            return View(hangHoa);
        }

        // POST: HangHoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHangHoa,TenHangHoa,SoLuong,GiaVon,GiaBan,TinhTrang,AnhMoTa,MaDVT,MucThue,MaThue,MaNhaCungCap")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangHoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDVT = new SelectList(db.DonViTinhs, "MaDVT", "TenDVT", hangHoa.MaDVT);
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", hangHoa.MaNhaCungCap);
            ViewBag.MaThue = new SelectList(db.Thues, "MaThue", "TenThue", hangHoa.MaThue);
            return View(hangHoa);
        }

        // GET: HangHoas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangHoa hangHoa = db.HangHoas.Find(id);
            if (hangHoa == null)
            {
                return HttpNotFound();
            }
            return View(hangHoa);
        }

        // POST: HangHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HangHoa hangHoa = db.HangHoas.Find(id);
            db.HangHoas.Remove(hangHoa);
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
        // Searching product
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public PartialViewResult ProductSearching(string SearchString)
        {
            var result = db.HangHoas.Where(x => x.TenHangHoa.Contains(SearchString) && x.SoLuong > 0).ToList();

            return PartialView(result);
        }

    }
}
