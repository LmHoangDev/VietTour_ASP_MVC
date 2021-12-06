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
    public class danhmucsController : BaseController
    {
        private viettoursDBEntities db = new viettoursDBEntities();

        // GET: Admin/danhmucs
        public ActionResult Index(int? page)
        {
            var dmcha = db.danhmuccha_select().ToList();
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(dmcha.ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/danhmucs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danhmuc danhmuc = db.danhmucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }


        // GET: Admin/danhmucs/Create


        // POST: Admin/danhmucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danhmuc danhmuc = db.danhmucs.Find(id);
            if (danhmuc == null)
            {
                return HttpNotFound();
            }
            return View(danhmuc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,mota")] danhmuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhmuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhmuc);
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
