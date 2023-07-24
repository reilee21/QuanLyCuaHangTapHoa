﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyCuaHangTapHoa.Models;

namespace QuanLyCuaHangTapHoa.Controllers
{
    public class HoaDonsController : Controller
    {
        private TapHoaEntities db = new TapHoaEntities();

        // GET: HoaDons
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.TaiKhoan);
            return View(hoaDons.ToList());
        }

        // GET: HoaDons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: HoaDons/Create
        public ActionResult Create()
        {
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }

        // POST: HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaTaiKhoan,Username,TongSoLuong,TongTien,TongTienThue,TienKhachDua,TienThoi")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTaiKhoan = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Username", hoaDon.MaTaiKhoan);
            return View(hoaDon);
        }

        // GET: HoaDons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTaiKhoan = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Username", hoaDon.MaTaiKhoan);
            return View(hoaDon);
        }

        // POST: HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaTaiKhoan,Username,TongSoLuong,TongTien,TongTienThue,TienKhachDua,TienThoi")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTaiKhoan = new SelectList(db.TaiKhoans, "MaTaiKhoan", "Username", hoaDon.MaTaiKhoan);
            return View(hoaDon);
        }

        // GET: HoaDons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
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

        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public PartialViewResult ShowCart()
        {
            if (Session["Cart"] == null)
                return PartialView("ShowCart");
            Cart _cart = Session["Cart"] as Cart;
            return PartialView(_cart);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public void AddToCart(string id)
        {
            var _pro = db.HangHoas.SingleOrDefault(s => s.MaHangHoa == id);
            if (_pro != null)
                GetCart().Add_Product_Cart(_pro);

        }
        // Xóa dòng sản phẩm trong giỏ hàng
        public void RemoveCart(string id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);

        }

        // Cập nhật số lượng và tính lại tổng tiền
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]

        public void Update_Cart_Quantity(string id, int qtity)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Update_quantity(id, qtity);

        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public void newCart()
        {
            Cart cart = Session["Cart"] as Cart;
            cart.ClearCart();
        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public void ChangePrice(string id, decimal price)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.updatePrice(id, price);
        }
        public void CheckOut(double kd, double change)
        {
            try
            {
                TimeZoneInfo vietnamTimeZone = TimeZoneInfo.CreateCustomTimeZone("Asia/Bangkok", TimeSpan.FromHours(7), "Bangkok", "Bangkok");
                DateTime vntime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, vietnamTimeZone);
                string moment = vntime.ToString("ddMMyyHHmmss");

                Cart cart = Session["Cart"] as Cart;
                HoaDon hd = new HoaDon();
                hd.MaHD = moment;
                hd.MaTaiKhoan = Session["IdAcc"].ToString();
                hd.Username = Session["Usn"].ToString();
                hd.TongSoLuong = (short)cart.Total_quantity();
                hd.TongTien = (double)cart.Total_all();
                hd.TongTienThue = (double)cart.Total_tax();
                hd.TienKhachDua = kd;
                hd.TienThoi = change;

                db.HoaDons.Add(hd);

                foreach (var item in cart.Items)
                {
                    ChiTietHoaDon ct = new ChiTietHoaDon();
                    ct.MaHD = hd.MaHD;
                    ct.MaHH = item._product.MaHangHoa;
                    ct.SoLuong = (short)item._quantity;
                    ct.GiaBan = (double)item._price;
                    ct.MucThue = item._product.MucThue;
                    ct.ThanhTien = (double)(item._quantity * (decimal)item._price * (1 + item._product.MucThue));
                    db.ChiTietHoaDons.Add(ct);
                    foreach (var hh in db.HangHoas.Where(s => s.MaHangHoa == ct.MaHH))
                    {
                        var updateQty = hh.SoLuong - ct.SoLuong;
                        hh.SoLuong = (short)updateQty;
                    }                    
                }
                db.SaveChanges();
                cart.ClearCart();
                
            }
            catch
            {
                return;
            }          

        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult DanhSachHoaDon(DateTime? dateStart, DateTime? dateEnd)
        {
            if (dateStart == null || dateEnd == null)
            {
                var hd = db.HoaDons.Include(h => h.TaiKhoan);
                return View(hd.ToList());
            }
            else
            {
                string st = dateStart.Value.ToString("ddMMyy");
                string en = dateEnd.Value.ToString("ddMMyy");
                var hoaDons = db.HoaDons.Where(hd => hd.MaHD.Substring(0, 6).CompareTo(st) >= 0 &&
                                                     hd.MaHD.Substring(0, 6).CompareTo(en) <= 0);
                return View("Index", hoaDons.ToList());
            }
        }

    }
}
