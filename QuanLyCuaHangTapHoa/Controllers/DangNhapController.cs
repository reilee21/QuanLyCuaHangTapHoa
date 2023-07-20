using QuanLyCuaHangTapHoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCuaHangTapHoa.Controllers
{
    public class DangNhapController : Controller
    {
        TapHoaEntities db = new TapHoaEntities();


        // GET: DangNhap
        public ActionResult Index()
        {
            if (Session["Role"] == null)
                return View();
            else if (Session["Role"].Equals("NV"))
                return RedirectToAction("Create", "HoaDons");
            return RedirectToAction("Index", "HangHoas");
        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult DangNhap(TaiKhoan acc)
        {
            var check = db.TaiKhoans.Where(a => a.Username == acc.Username && a.Passwords == acc.Passwords).FirstOrDefault();
            if (check != null)
            {
                if (!check.ChucVu)
                    Session["Role"] = "QL";
                else Session["Role"] = "NV";
                Session["IdAcc"] = check.MaTaiKhoan;
                Session["Usn"] = check.Username;

                if (check.ChucVu)
                    return RedirectToAction("Create", "HoaDons");
                return RedirectToAction("Index", "HangHoas");
            }
            ViewBag.ErrorLogin = "Sai thông tin đăng nhập ! ";
            return View("Index");

        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}