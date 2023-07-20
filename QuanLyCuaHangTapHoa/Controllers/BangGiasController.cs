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
    public class BangGiasController : Controller
    {
        private TapHoaEntities db = new TapHoaEntities();

        // GET: BangGias
        public ActionResult Index()
        {
            return View(db.BangGias.ToList());
        }

        // GET: BangGias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangGia bangGia = db.BangGias.Find(id);
            if (bangGia == null)
            {
                return HttpNotFound();
            }
            return View(bangGia);
        }

        // GET: BangGias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BangGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBangGia,NgayTao,NgayApDung")] BangGia bangGia)
        {
            if (ModelState.IsValid)
            {
                db.BangGias.Add(bangGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bangGia);
        }

        // GET: BangGias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangGia bangGia = db.BangGias.Find(id);
            if (bangGia == null)
            {
                return HttpNotFound();
            }
            return View(bangGia);
        }

        // POST: BangGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBangGia,NgayTao,NgayApDung")] BangGia bangGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bangGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bangGia);
        }

        // GET: BangGias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BangGia bangGia = db.BangGias.Find(id);
            if (bangGia == null)
            {
                return HttpNotFound();
            }
            return View(bangGia);
        }

        // POST: BangGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BangGia bangGia = db.BangGias.Find(id);
            db.BangGias.Remove(bangGia);
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
