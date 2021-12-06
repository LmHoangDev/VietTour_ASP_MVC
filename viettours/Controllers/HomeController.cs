using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using viettours.Models;
namespace viettours.Controllers
{
    public class HomeController : Controller
    {
        viettoursDBEntities db = new viettoursDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TrangChu()
        {
            return View();
        }
        // Xay dung action dang nhap
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            // kiem tra ten dang nhap va mat khau
            
            string sTaiKhoan = f["txtTenDangNhap"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();
            account tk = db.accounts.SingleOrDefault(n => n.username == sTaiKhoan && n.pass == sMatKhau && n.quyenhan == 2);

            if (tk != null)
            {
                Session["account"] = tk;
                /*return RedirectToAction("Index");*/
                Session["dattours"] = null;
                return Content("<script>window.location.reload();</script>");
            }
            return Content("Tài Khoản hoặc Mật khẩu ko đúng!");
            /* return RedirectToAction("Index");*/
        }
        public ActionResult DangXuat()
        {
            Session["account"] = null;
            return Redirect("~/Home/TrangChu");
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(account tv)
        {
            // them khach hang vao co so du lieu
            try
            {
                if (ModelState.IsValid)
                {
                    if (db.accounts.Where(x => x.username == tv.username).Count() != 0)
                        throw new Exception("Tên đăng nhập đã tồn tại");
                    if (db.accounts.SingleOrDefault(x => x.username == tv.username) != null)
                    ViewBag.ThongBao = "Thêm thành công";
                    db.accounts.Add(tv);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Thêm Thất Bại");
                }
            }
            catch(Exception ex)
            {
                ViewBag.error = "Lỗi! " + ex.Message;
                return View(tv);
            }
            return RedirectToAction("TrangChu");
        }

        public ActionResult ThemLienHe()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemLienHe([Bind(Include = "id,ten,quocgia,dienthoai,diachi,email,noidung,gioitinh")] lienhe lienhe)
        {
            if (ModelState.IsValid)
            {
                db.lienhes.Add(lienhe);
                db.SaveChanges();
                return RedirectToAction("TrangChu");
            }
            return View(lienhe);
        }
        public ActionResult chondanhmuc(string id)
        {
            var a = db.danhmucs.SingleOrDefault(x => x.id == id);
            var b = db.danhmuccons.SingleOrDefault(x => x.id == id);
            if (b == null)
            {
                if (a.id == "A0")
                   return Redirect("~/home/trangchu");
                return RedirectToAction("index", "cdm", new { id });

            }    
                //mota 
            else if (b.type == 0)
            {
                int l=1;
                if (b.danhmuccha == "A1")
                {
                    l = 0;
                }
                return RedirectToAction("index", "toursss", new { loai = l, iddanhmuc = b.id });
            }
            else if(b.type==1)
            {
                return RedirectToAction("displaypostbydm", "postss",new { id_danhmuc=id });

            }    
            else
            {
//trả về trang mota
            }
            return RedirectToAction("index","cdm", new { id });

        }
        public ActionResult XeVanChuyen()
        {
            return View();
        }
        public ActionResult ChinhSachBaoMat()
        {
            return View();
        }
        public ActionResult DieuKienChung()
        {
            return View();
        }
        public ActionResult DuLichMoiTruong()
        {
            return View();
        }
        public ActionResult ThuTucVisa()
        {
            return View();
        }
    }
}