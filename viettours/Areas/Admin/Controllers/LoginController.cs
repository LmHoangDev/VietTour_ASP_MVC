using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using viettours.Models;
namespace viettours.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        viettoursDBEntities db = new viettoursDBEntities();
        // GET: Admin/Login
        public ActionResult Index()
        {

            if (Session["admin"] != null)
                return Redirect("~/admin/Home/index");
            if (Request.Cookies["LoginCookies"] != null)
            {

                HttpCookie cookie = HttpContext.Request.Cookies["LoginCookies"];
                var a = cookie["username"].ToString();
                var b = cookie["pass"].ToString();
                account admin = db.accounts.SingleOrDefault(n => n.username == a && n.pass == b && n.quyenhan != 2);
                if (admin == null)
                {
                    Request.Cookies["LoginCookies"].Expires = DateTime.Now.AddSeconds(0);
                    Response.Cookies["LoginCookies"].Expires = DateTime.Now.AddSeconds(0);
                }    
                Session["admin"] = admin;
                return Redirect("~/admin/Home/index");
            }
            return View();
        }

        /* [HttpPost]
         public ActionResult Login(FormCollection f)
         {

                 // kiem tra ten dang nhap va mat khau
                 string sTaiKhoan = f["txtTenDangNhap"].ToString();
                 string sMatKhau = f["txtMatKhau"].ToString();
                 account admin = db.accounts.SingleOrDefault(n => n.username == sTaiKhoan && n.pass == sMatKhau && n.quyenhan != 2);

             if (admin != null)
             {
                 Session["admin"] = admin;
                 return Redirect("../Home/Index");

             }
             else
             {
                 ViewBag.error = "Tài Khoản hoặc Mật khẩu ko đúng!";
                 return View("Index");
             }

          }*/
        public ActionResult DangXuat()
        {
            Session["admin"] = null;
            if (Request.Cookies["LoginCookies"] != null)
            {
                Request.Cookies["LoginCookies"].Expires = DateTime.Now.AddSeconds(0);
                Response.Cookies["LoginCookies"].Expires = DateTime.Now.AddSeconds(0);
            }
            return RedirectToAction("Index");
        }
        // doi matkhau
       


        [HttpPost]
        public ActionResult Login2(FormCollection f, [Bind(Include = "username,pass")] account model)
        {
            var user = f["username"].ToString();
            var password = f["pass"].ToString();

            var data = db.accounts.SingleOrDefault(n => n.username.Equals(user) && n.pass.Equals(password) && n.quyenhan != 2);
            if (ModelState.IsValid)
            {
                if (data != null)
                {
                    var loginCookie = new HttpCookie("LoginCookies");
                    if (f["Tudonglogin"] == "true,false")
                    {

                        loginCookie.Values.Add("username", user);
                        loginCookie.Values.Add("pass", password);
                        loginCookie.Expires = DateTime.Now.AddHours(48);
                        Response.Cookies.Add(loginCookie);
                    }
                    else
                    {
                        loginCookie.Expires = DateTime.Now.AddHours(-1);

                    }
                    Session["admin"] = data;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Login failed";
                }
            }
            return View("Index");
        }



    }


}