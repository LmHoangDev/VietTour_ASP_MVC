using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using viettours.Models;
using PagedList;
namespace viettours.Areas.Admin.Controllers
{
    public class accountsController : BaseController
    {
        private viettoursDBEntities db = new viettoursDBEntities();

        
        // GET: Admin/accounts
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["admin"] != null)
            {
                var acc = (account)Session["admin"];
                if (acc.quyenhan != 0)
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                    {
                        controller = "Home",
                        action = "index",
                        Area = "Admin"
                    }));
            }
            base.OnActionExecuting(filterContext);
        }
        public ActionResult Index(int? page,string loaiacc)
        {
            var list = db.accounts.Select(x => x).ToList();
            ViewBag.currentloaiacc = loaiacc;
            if (!string.IsNullOrEmpty(loaiacc))
            {
                if (loaiacc == "0")
                {
                    list = list.Where(x => x.quyenhan == 0).ToList();
                }
                else if(loaiacc == "1")
                {
                    list = list.Where(x => x.quyenhan == 1).ToList();
                }
                else {
                    list = list.Where(x => x.quyenhan == 2).ToList();
                }
            }
            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="0",Text="admin"},
                new SelectListItem(){ Value="1",Text="mod"},
                new SelectListItem(){ Value="2",Text="Khách hàng"}
             };
            ViewBag.loaiacc = new SelectList(ls, "Value", "Text", loaiacc);
            int pageSize = 8;
            int pageNumber= (page ?? 1);
            return View(list.OrderBy(x=>x.id).ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/accounts/Details/5
        public ActionResult Details(int? id)
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

        // GET: Admin/accounts/Create
        public ActionResult Create()
        {
            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="0",Text="admin"},
                new SelectListItem(){ Value="1",Text="mod"}
            };
            ViewBag.quyenhan = new SelectList(ls, "Value", "Text");
            return View();
        }

        // POST: Admin/accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,pass,email,diachi,quyenhan")] account account)
        {
            try {
                if (ModelState.IsValid)
                {
                    if (db.accounts.Where(x => x.username == account.username).Count()!=0)
                        throw new Exception("Tên tài khoản đã tồn tại");
                    db.accounts.Add(account);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else { throw new Exception(""); }
            }
            catch(Exception ex)
            {
                ViewBag.error = "Lỗi! " + ex.Message;
                List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="0",Text="admin"},
                new SelectListItem(){ Value="1",Text="mod"}
                };
                ViewBag.quyenhan = new SelectList(ls, "Value", "Text", account.quyenhan);
                return View(account);
            }
        }

        // GET: Admin/accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account account = db.accounts.Find(id);
            if (account.quyenhan==2)
            { return View("Index"); }    
                if (account == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="0",Text="admin"},
                new SelectListItem(){ Value="1",Text="mod"}
            };
            ViewBag.quyenhan = new SelectList(ls, "Value", "Text",account.quyenhan);
            return View(account);
        }

        // POST: Admin/accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,pass,email,diachi,quyenhan")] account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="0",Text="admin"},
                new SelectListItem(){ Value="1",Text="mod"}
            };
            ViewBag.quyenhan = new SelectList(ls, "Value", "Text", account.quyenhan);
            return View(account);
        }

        // GET: Admin/accounts/Delete/5
        public ActionResult Delete(int? id)
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
            else if(account.quyenhan==2)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }    
            return View(account);
        }

        // POST: Admin/accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            account account = db.accounts.Find(id);
            try
            {
                
                var acc = (account)Session["admin"];
                if (acc.id == id)
                    throw new Exception("Tài khoản đang hoạt động");
                else
                {
                   
                    db.accounts.Remove(account);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Lỗi: Không thể xóa bản ghi này" + ex.Message;
                return View("delete",account);
            }
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
