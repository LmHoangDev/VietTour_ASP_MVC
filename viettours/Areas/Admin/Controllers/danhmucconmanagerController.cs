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
    public class danhmucconmanagerController : BaseController
    {
        private viettoursDBEntities db = new viettoursDBEntities();
        public List<danhmuccon_select_Result> a;
        // GET: Admin/danhmucconmanager
        public danhmucconmanagerController()
        {
            a = db.danhmuccon_select().OrderBy(x=>x.name).ToList();


        }
        public ActionResult Index(int? page,string SearchString,string currentfilter)
        {
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentfilter;
            }
            ViewBag.currentFilter = SearchString;
            if (!string.IsNullOrEmpty(SearchString))
            {
                a = a.Where(x => x.name.Contains(SearchString)).ToList();
            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(a.ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/danhmucconmanager/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danhmuccon_select_Result abc = a.Single(x=>x.id==id);
            if (abc == null)
            {
                return HttpNotFound();
            }
            return View(abc);
        }

        // GET: Admin/danhmucconmanager/Create
        public ActionResult Create()
        {
            List<SelectListItem> type = new List<SelectListItem>() {
            new SelectListItem(){Value="0",Text="tour" },
            new SelectListItem(){Value="1",Text="post" },
            new SelectListItem(){Value="2",Text="khác" }
            };
            ViewBag.type = new SelectList(type,"Value","Text");
            return View();
        }

        // POST: Admin/danhmucconmanager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,mota,type,danhmuccha")] danhmuccon_select_Result danhmuccon_select_Result)
        {
            if (ModelState.IsValid)
            {
                var abc = danhmuccon_select_Result;
                db.danhmuc_insert(abc.id,abc.name,abc.mota,abc.type,abc.danhmuccha);
                return RedirectToAction("Index");
            }

            List<SelectListItem> type = new List<SelectListItem>() {
            new SelectListItem(){Value="0",Text="tour" },
            new SelectListItem(){Value="1",Text="post" },
            new SelectListItem(){Value="2",Text="khác" }
            };
            ViewBag.type = new SelectList(type, "Value", "Text");
            return View(danhmuccon_select_Result);
        }

        // GET: Admin/danhmucconmanager/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danhmuccon_select_Result abc =a.Single(x=>x.id==id);
            if (abc == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> type = new List<SelectListItem>() {
            new SelectListItem(){Value="0",Text="tour" },
            new SelectListItem(){Value="1",Text="post" },
            new SelectListItem(){Value="2",Text="khác" }
            };
            ViewBag.type = new SelectList(type, "Value", "Text",abc.type);
            var b = db.danhmuc_select(abc.type).ToList();
            ViewBag.danhmuccha = new SelectList(b, "id", "name", abc.danhmuccha);
            return View(abc);
        }

        // POST: Admin/danhmucconmanager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,mota,type,danhmuccha")] danhmuccon_select_Result danhmuccon_select_Result)
        {
            if (ModelState.IsValid)
            {
                var abc = danhmuccon_select_Result;
                db.danhmuc_update(abc.id, abc.name, abc.mota, abc.type, abc.danhmuccha);
                return RedirectToAction("Index");
            }
            return View(danhmuccon_select_Result);
        }

        // GET: Admin/danhmucconmanager/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danhmuccon_select_Result abc = a.SingleOrDefault(x => x.id == id);
            if (abc == null)
            {
                return HttpNotFound();
            }
            return View(abc);
        }

        // POST: Admin/danhmucconmanager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            danhmuccon_select_Result abc = a.SingleOrDefault(x => x.id == id);
            try
            {
                if (db.danhmuccons.Where(x => x.danhmuccha == abc.id).Count() != 0)
                    throw new Exception("không thể xóa bản ghi này");

                db.danhmuc_delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                db.danhmuc_update(abc.id, abc.name, abc.mota, abc.type, abc.danhmuccha);
                ViewBag.error = "Lỗi! " + "không thể xóa bản ghi này";
                return View("Delete", abc);
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
        [HttpGet]
        public JsonResult updatedmlist(int l)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var b = db.danhmuc_select(l).ToList();
            return Json(b, JsonRequestBehavior.AllowGet);
        }

    }
}
