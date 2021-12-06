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
    public class postmanageController : BaseController
    {
        private viettoursDBEntities db = new viettoursDBEntities();

        // GET: Admin/postmanage
        public ActionResult Index(string SearchString,int ?page,string currentfilter,string sortorder,string loaipost)
        {
            var list = db.posts.Select(x=>x).OrderBy(x => x.title).ToList();
         
            ViewBag.currentloaipost = loaipost;
            if (!string.IsNullOrEmpty(loaipost))
            {
                if (loaipost == "1")
                {
                    list = list.Where(x => x.loai == 1).ToList();
                }
                else
                {
                    list = list.Where(x => x.loai != 1).ToList();
                }
            }
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentfilter;
            }
            ViewBag.currentFilter = SearchString;
            ViewBag.saptheoten = string.IsNullOrEmpty(sortorder) ? "ten_desc" : "";

            if (!string.IsNullOrEmpty(SearchString))
            {
                list = list.Where(x => x.title.Contains(SearchString)).ToList();
            }
            switch (sortorder)
            {
                case "ten_desc":
                    list = list.OrderByDescending(x => x.title).ToList();
                    break;
                default:
                    list = list.OrderBy(x => x.title).ToList();
                    break;
            }
            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="1",Text="tin tức sự kiện"},
                new SelectListItem(){ Value="0",Text="khác"}
             };
            ViewBag.loaipost = new SelectList(ls, "Value", "Text", loaipost);

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
          
        }

        // GET: Admin/postmanage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/postmanage/Create
        public ActionResult Create()
        {
            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="1",Text="tin tức sự kiện"},
                new SelectListItem(){ Value="0",Text="khác"}
            };
            ViewBag.loai = new SelectList(ls, "Value", "Text");
            List<danhmuccon_select_all_Result> dmc = db.danhmuccon_select_all().Where(x => x.loaidm == 1).ToList();
            ViewBag.id_danhmuc = new SelectList(dmc, "id", "name");
            return View();
        }

        // POST: Admin/postmanage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,title,anh,loai,motangan,id_danhmuc,mota")] post post)
        {

                post.anh = "";
                if (ModelState.IsValid)
                {
                    db.posts.Add(post);
                    db.SaveChanges();
                    var a = db.posts.Single(x => x.id == db.posts.Max(y => y.id));
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        String endfile = System.IO.Path.GetFileName(f.FileName.Split('.').Last());
                        String FileName = a.id + "." + endfile;
                        String UploadPath = Server.MapPath(Common.postfolder + FileName);
                        f.SaveAs(UploadPath);
                        a.anh = FileName;
                    }
                    db.Entry(a).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="1",Text="tin tức sự kiện"},
                new SelectListItem(){ Value="0",Text="khác"}
                };
            ViewBag.loai = new SelectList(ls, "Value", "Text",post.loai);
            List<danhmuccon_select_all_Result> dmc = db.danhmuccon_select_all().Where(x => x.loaidm == 1).ToList();
            ViewBag.id_danhmuc = new SelectList(dmc, "id", "name",post.id_danhmuc);
            return View(post);
        }

        // GET: Admin/postmanage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="1",Text="tin tức sự kiện"},
                new SelectListItem(){ Value="0",Text="khác"}
            };
            ViewBag.loai = new SelectList(ls, "Value", "Text", post.loai);
            List<danhmuccon_select_all_Result> dmc = db.danhmuccon_select_all().Where(x => x.loaidm == 1).ToList();
            ViewBag.id_danhmuc = new SelectList(dmc, "id", "name", post.id_danhmuc);
            return View(post);
        }

        // POST: Admin/postmanage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,title,anh,loai,motangan,id_danhmuc,mota")] post post)
        {
            try {
                if (ModelState.IsValid)
                {
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        String endfile = System.IO.Path.GetFileName(f.FileName.Split('.').Last());
                        String FileName = post.id + "." + endfile;
                        String UploadPath = Server.MapPath(Common.postfolder + FileName);
                        f.SaveAs(UploadPath);
                        post.anh = FileName;
                    }
                    db.Entry(post).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ViewBag.error="Lỗi: "+ ex.Message;
            }


            List<SelectListItem> ls = new List<SelectListItem>() {
                new SelectListItem(){ Value="1",Text="tin tức sự kiện"},
                new SelectListItem(){ Value="0",Text="khác"}
            };
            ViewBag.loai = new SelectList(ls, "Value", "Text", post.loai);
            List<danhmuccon_select_all_Result> dmc = db.danhmuccon_select_all().Where(x => x.loaidm == 1).ToList();
            ViewBag.id_danhmuc = new SelectList(dmc, "id", "name", post.id_danhmuc);
            return View(post);
        }

        // GET: Admin/postmanage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            post post = db.posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/postmanage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            post post = db.posts.Find(id);
            db.posts.Remove(post);
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
