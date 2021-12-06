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
    public class KhachHangQLTaiKhoanController : Controller
    {
        viettoursDBEntities db = new viettoursDBEntities();
        // GET: KhachHangQLTaiKhoan
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["account"] == null)
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                {
                    controller = "home",
                    action = "trangchu",
                }));
            base.OnActionExecuting(filterContext);

        }
        public ActionResult Index(string tb)
        {
            if(!string.IsNullOrEmpty(tb))
            {
                ViewBag.error = tb;
            }    
            account a = (account)Session["account"];
            account tk = db.accounts.SingleOrDefault(n=>n.id == a.id);
            return View(tk);
        }
        public ActionResult QLTaiKhoan()
        {   
            return View();
        }
        public ActionResult KhachHangQuanLyTaiKhoan(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account account = db.accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }
        public ActionResult DoiMatKhauUser()
        {
            return View();
        }
        public ActionResult DoiMatKhau(FormCollection f)
        {
            try {
                var acc = (account)Session["account"];
                string oldpass = f["passold"];
                string newpass = f["passnew"];
                string repass = f["repass"];
                if (oldpass != acc.pass)
                    throw new Exception("sai mật khẩu cũ");
                if (newpass != repass)
                    throw new Exception("nhập lại mật khẩu sai");
                var accn = db.accounts.SingleOrDefault(x => x.id == acc.id);
                accn.pass=newpass;
                db.Entry(accn).State = EntityState.Modified;
                db.SaveChanges();
                Session["account"] = accn;
                string tb = "đổi mật khẩu thành công";
                return RedirectToAction("index", "KhachHangQLTaiKhoan", new { tb = tb });
            }
            catch(Exception ex)
            {
                ViewBag.error= ex.Message;
                return View("DoiMatKhauUser");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KhachHangQuanLyTaiKhoan([Bind(Include = "id,username,pass,email,diachi,quyenhan")] account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                Session["account"] = account;
                string tb = "cập nhật thành công";
                return RedirectToAction("index", "KhachHangQLTaiKhoan", new { tb=tb});
            }
            return View(account);
        }
    }
}