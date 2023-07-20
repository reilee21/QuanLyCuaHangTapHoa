﻿using System;
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
    public class DonViTinhsController : Controller
    {
        private TapHoaEntities db = new TapHoaEntities();

        // GET: DonViTinhs
        public ActionResult Index()
        {
            return View(db.DonViTinhs.ToList());
        }

        // GET: DonViTinhs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonViTinh donViTinh = db.DonViTinhs.Find(id);
            if (donViTinh == null)
            {
                return HttpNotFound();
            }
            return View(donViTinh);
        }

        // GET: DonViTinhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonViTinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDVT,TenDVT")] DonViTinh donViTinh)
        {
            if (ModelState.IsValid)
            {
                db.DonViTinhs.Add(donViTinh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donViTinh);
        }

        // GET: DonViTinhs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonViTinh donViTinh = db.DonViTinhs.Find(id);
            if (donViTinh == null)
            {
                return HttpNotFound();
            }
            return View(donViTinh);
        }

        // POST: DonViTinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDVT,TenDVT")] DonViTinh donViTinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donViTinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donViTinh);
        }

        // GET: DonViTinhs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonViTinh donViTinh = db.DonViTinhs.Find(id);
            if (donViTinh == null)
            {
                return HttpNotFound();
            }
            return View(donViTinh);
        }

        // POST: DonViTinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonViTinh donViTinh = db.DonViTinhs.Find(id);
            db.DonViTinhs.Remove(donViTinh);
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
