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
    public class tourmanagerController : BaseController
    {
        private viettoursDBEntities db = new viettoursDBEntities();
        List<tour_manage_Result> list;
        public tourmanagerController()
        {
            list = db.tour_manage().ToList();
        }
        // GET: Admin/tourmanager
        public ActionResult Index(int? page, string SearchString,string droptk,string sortorder,string loaitour,string currentfilter)
        {
            ViewBag.currentsort = sortorder;
            ViewBag.saptheoten = string.IsNullOrEmpty(sortorder) ? "ten_desc" : "";
            ViewBag.currentdroptk = droptk;
            ViewBag.currentloaitour = loaitour;
            if (SearchString!=null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentfilter;
            }
            ViewBag.currentfilter = SearchString;
            if (!string.IsNullOrEmpty(loaitour))
            {
                if(loaitour=="0")
                {
                    list = list.Where(x => x.loai == 0).ToList();
                }
                else
                {
                    list = list.Where(x => x.loai == 1).ToList();
                }
            }    
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            if (!string.IsNullOrEmpty(SearchString)&&!string.IsNullOrEmpty(droptk))
            {
                if(droptk=="0")
                list = list.Where(x => x.name.Contains(SearchString)).ToList();
                else if(droptk=="1")
                    list = list.Where(x => x.tendm.Contains(SearchString)).ToList();
            }
            switch(sortorder)
            {
                case "ten_desc":
                    list = list.OrderByDescending(x => x.name).ToList();
                    break;
                 default:
                    list = list.OrderBy(x => x.name).ToList();
                    break;
            }    
            List<SelectListItem> drop = new List<SelectListItem>() {
            new SelectListItem(){Value="0",Text="Tên"},
            new SelectListItem(){Value="1",Text="Danh mục" }
            };

            ViewBag.droptk = new SelectList(drop, "Value", "Text",droptk);
            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="0",Text="tour trong nước"},
                new SelectListItem(){ Value="1",Text="tour nước ngoài"}
            };
            ViewBag.loaitour = new SelectList(ls, "Value", "Text", loaitour);
            return View(list.ToPagedList(pageNumber, pageSize));

        }

        // GET: Admin/tourmanager/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tour_manage_Result tour_manage_Result = list.Single(x => x.id == id);
                if (tour_manage_Result == null)
                {
                    return HttpNotFound();
                }
                return View(tour_manage_Result);
            }
            catch (Exception ex)
            {
                return HttpNotFound();
            }
        }

        // GET: Admin/tourmanager/Create
        public ActionResult Create()
        {
            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="0",Text="tour trong nước"},
                new SelectListItem(){ Value="1",Text="tour nước ngoài"}
            };
            ViewBag.loai = new SelectList(ls, "value", "text");
            List<post> a = db.posts.Where(x => x.loai == 0).ToList();
            ViewBag.chitiet = new SelectList(a, "id", "title");
            ViewBag.dacdiem = new SelectList(a, "id", "title");
            ViewBag.gia = new SelectList(a, "id", "title");
            return View();
        }

        // POST: Admin/tourmanager/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,anh,thoigian,khoihanh,phuongtien,gia,dacdiem,chitiet,loai,danhmuc")] tour_manage_Result tour_manage_Result)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tour_manage_Result a = tour_manage_Result;
                    danhmuccon x = db.danhmuccons.SingleOrDefault(e => e.id == a.danhmuc);
                    a.anh = "";
                    db.tour_insert(a.name, a.anh, a.thoigian, a.khoihanh, a.phuongtien, a.gia, a.dacdiem, a.chitiet, a.loai, x.danhmuccha, x.id);
                    var abc = db.tours.Single(z => z.id == db.tours.Max(y => y.id));
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        String endfile = System.IO.Path.GetFileName(f.FileName.Split('.').Last());
                        String FileName = abc.id + "." + endfile;
                        String UploadPath = Server.MapPath(Common.tourfolder + FileName);
                        f.SaveAs(UploadPath);
                        abc.anh = FileName;
                    }
                    db.Entry(abc).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!" + ex.Message;
            }

            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="0",Text="tour trong nước"},
                new SelectListItem(){ Value="1",Text="tour nước ngoài"}
            };
            ViewBag.loai = new SelectList(ls, "value", "text", tour_manage_Result.loai);
            List<post> post = db.posts.Where(x => x.loai == 0).ToList();
            ViewBag.chitiet = new SelectList(post, "id", "title", tour_manage_Result.chitiet);
            ViewBag.dacdiem = new SelectList(post, "id", "title", tour_manage_Result.dacdiem);
            ViewBag.gia = new SelectList(post, "id", "title", tour_manage_Result.gia);
            return View(tour_manage_Result);
        }

        // GET: Admin/tourmanager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tour_manage_Result a = list.Single(x => x.id == id);
            if (a == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="0",Text="tour trong nước"},
                new SelectListItem(){ Value="1",Text="tour nước ngoài"}
            };

            ViewBag.loai = new SelectList(ls, "value", "text", a.loai);
            var b = db.danhmuc_loai(a.loai).ToList();
            ViewBag.danhmuc = new SelectList(b, "id", "name", a.danhmuc);
            List<post> post = db.posts.Where(x => x.loai == 0).ToList();
            ViewBag.chitiet = new SelectList(post, "id", "title", a.chitiet);
            ViewBag.dacdiem = new SelectList(post, "id", "title", a.dacdiem);
            ViewBag.gia = new SelectList(post, "id", "title", a.gia);
            return View(a);
        }

        // POST: Admin/tourmanager/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,anh,thoigian,khoihanh,phuongtien,gia,dacdiem,chitiet,loai,danhmuc")] tour_manage_Result tour_manage_Result)
        {
            tour_manage_Result a = tour_manage_Result;
                if (ModelState.IsValid)
                {
                    danhmuccon x = db.danhmuccons.Single(e => e.id == a.danhmuc);
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        String endfile = System.IO.Path.GetFileName(f.FileName.Split('.').Last());
                        String FileName = a.id + "." + endfile;
                        String UploadPath = Server.MapPath(Common.tourfolder + FileName);
                        f.SaveAs(UploadPath);
                        a.anh = FileName;
                       
                    }
                    db.tour_update(a.id, a.name, a.anh, a.thoigian, a.khoihanh, a.phuongtien, a.gia, a.dacdiem, a.chitiet, a.loai, x.danhmuccha, a.danhmuc);
                    return RedirectToAction("Index");
                }
                
            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="0",Text="tour trong nước"},
                new SelectListItem(){ Value="1",Text="tour nước ngoài"}
            };
            ViewBag.loai = new SelectList(ls, "value", "text", a.loai);
            var b = db.danhmuc_loai(a.loai).ToList();
            ViewBag.danhmuc = new SelectList(b, "id", "name", a.danhmuc);
            List<post> post = db.posts.Where(x => x.loai == 0).ToList();
            ViewBag.chitiet = new SelectList(post, "id", "title", a.chitiet);
            ViewBag.dacdiem = new SelectList(post, "id", "title", a.dacdiem);
            ViewBag.gia = new SelectList(post, "id", "title", a.gia);
            return View(a);
        }

        // GET: Admin/tourmanager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tour_manage_Result a = list.Single(x => x.id == id);
            if (a == null)
            {
                return HttpNotFound();
            }
            return View(a);
        }

        // POST: Admin/tourmanager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tour_manage_Result a = list.Single(x => x.id == id);
            try
            {
                if (db.dattours.Where(x => x.tour_id == id).Count() != 0)
                    throw new Exception("không thể xóa bản ghi này");
                
                db.tour_delete(id, a.loai);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.error = "lỗi: " + e.Message;
                return View("Delete", a);
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
            var b = db.danhmuc_loai(l).ToList();
            return Json(b, JsonRequestBehavior.AllowGet);
        }
    }
}
