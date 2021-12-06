using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using viettours.Models;

namespace viettours.Areas.Admin.Controllers
{
    public class profileController : BaseController
    {
        // GET: Admin/profile
        viettoursDBEntities db = new viettoursDBEntities();
        public ActionResult Index(string tb)
        {
            if (!string.IsNullOrEmpty(tb))
            {
                ViewBag.error = tb;
            }
            return View();
        }
        public ActionResult DoiMatKhauAdmin()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult DoiMatKhau(FormCollection f)
        {
            try
            {
                var acc = (account)Session["admin"];
                string oldpass = f["passold"];
                string newpass = f["passnew"];
                string repass = f["repass"];
                if (oldpass != acc.pass)
                    throw new Exception("sai mật khẩu cũ");
                if (newpass != repass)
                    throw new Exception("nhập lại mật khẩu sai");
                var accn = db.accounts.SingleOrDefault(x => x.id == acc.id);
                accn.pass = newpass;
                db.Entry(accn).State = EntityState.Modified;
                db.SaveChanges();
                if (Request.Cookies["LoginCookies"] != null)
                {
                    Request.Cookies["LoginCookies"].Expires = DateTime.Now.AddSeconds(0);
                    Response.Cookies["LoginCookies"].Expires = DateTime.Now.AddSeconds(0);
                }
                Session["admin"] = accn;
                string tb = "đổi mật khẩu thành công";
                return RedirectToAction("index", "profile", new { tb = tb });
            }
            catch (Exception ex)
            {
                ViewBag.err = ex.Message;
                return View("DoiMatKhauAdmin");
            }
        }
    }
}