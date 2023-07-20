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
    public class ThuesController : Controller
    {
        private TapHoaEntities db = new TapHoaEntities();

        // GET: Thues
        public ActionResult Index()
        {
            return View(db.Thues.ToList());
        }

        // GET: Thues/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thue thue = db.Thues.Find(id);
            if (thue == null)
            {
                return HttpNotFound();
            }
            return View(thue);
        }

        // GET: Thues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Thues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaThue,TenThue,MucThue")] Thue thue)
        {
            if (ModelState.IsValid)
            {
                db.Thues.Add(thue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thue);
        }

        // GET: Thues/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thue thue = db.Thues.Find(id);
            if (thue == null)
            {
                return HttpNotFound();
            }
            return View(thue);
        }

        // POST: Thues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaThue,TenThue,MucThue")] Thue thue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thue);
        }

        // GET: Thues/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thue thue = db.Thues.Find(id);
            if (thue == null)
            {
                return HttpNotFound();
            }
            return View(thue);
        }

        // POST: Thues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Thue thue = db.Thues.Find(id);
            db.Thues.Remove(thue);
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
