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
    public class lienhesController : BaseController
    {
        private viettoursDBEntities db = new viettoursDBEntities();

        // GET: Admin/lienhes
        public ActionResult Index(int ?page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(db.lienhes.OrderBy(x=>x.id).ToPagedList(pageNumber,pageSize));
        }

        // GET: Admin/lienhes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lienhe lienhe = db.lienhes.Find(id);
            if (lienhe == null)
            {
                return HttpNotFound();
            }
            return View(lienhe);
        }

       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lienhe lienhe = db.lienhes.Find(id);
            if (lienhe == null)
            {
                return HttpNotFound();
            }
            return View(lienhe);
        }

        // POST: Admin/lienhes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lienhe lienhe = db.lienhes.Find(id);
            db.lienhes.Remove(lienhe);
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
