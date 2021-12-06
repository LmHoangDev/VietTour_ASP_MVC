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
    public class dattoursmanagerController : BaseController
    {
        private viettoursDBEntities db = new viettoursDBEntities();

        // GET: Admin/dattoursmanager
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var dattours = db.dattours.Include(d => d.account).Include(d => d.tour);
            return View(dattours.OrderBy(x=>x.ten).ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/dattoursmanager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dattour dattour = db.dattours.Find(id);
            if (dattour == null)
            {
                return HttpNotFound();
            }
            return View(dattour);
        }

        // GET: Admin/dattoursmanager/Create
        //public ActionResult Create()
        //{
        //    ViewBag.acc_id = new SelectList(db.accounts, "id", "username");
        //    ViewBag.tour_id = new SelectList(db.tours, "id", "name");
        //    return View();
        //}

        //// POST: Admin/dattoursmanager/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,ten,email,tel,mobile,addr,quocgia,tour_id,start,songuoi,nguoilon,treem_2,treem_12,loaipid,phong1,phong2,phong3,huongdan_id,acc_id")] dattour dattour)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.dattours.Add(dattour);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.acc_id = new SelectList(db.accounts, "id", "username", dattour.acc_id);
        //    ViewBag.tour_id = new SelectList(db.tours, "id", "name", dattour.tour_id);
        //    return View(dattour);
        //}

        //// GET: Admin/dattoursmanager/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    dattour dattour = db.dattours.Find(id);
        //    if (dattour == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.acc_id = new SelectList(db.accounts, "id", "username", dattour.acc_id);
        //    ViewBag.tour_id = new SelectList(db.tours, "id", "name", dattour.tour_id);
        //    return View(dattour);
        //}

        //// POST: Admin/dattoursmanager/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,ten,email,tel,mobile,addr,quocgia,tour_id,start,songuoi,nguoilon,treem_2,treem_12,loaipid,phong1,phong2,phong3,huongdan_id,acc_id")] dattour dattour)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(dattour).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.acc_id = new SelectList(db.accounts, "id", "username", dattour.acc_id);
        //    ViewBag.tour_id = new SelectList(db.tours, "id", "name", dattour.tour_id);
        //    return View(dattour);
        //}

        // GET: Admin/dattoursmanager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dattour dattour = db.dattours.Find(id);
            if (dattour == null)
            {
                return HttpNotFound();
            }
            return View(dattour);
        }

        // POST: Admin/dattoursmanager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dattour dattour = db.dattours.Find(id);
            db.dattours.Remove(dattour);
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
