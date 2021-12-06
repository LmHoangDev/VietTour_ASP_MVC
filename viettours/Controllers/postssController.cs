using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using viettours.Models;
using PagedList;
using PagedList.Mvc;
namespace viettours.Controllers
{
    public class postssController : Controller
    {
        viettoursDBEntities db = new viettoursDBEntities();
        // GET: postsss
        public ActionResult Index(int? page,string iddanhmuc)
        {   

            return Redirect("DisplayAllPost");
        }
        public ActionResult DisplayAllPost(int? page)
        {
            var lstPost = db.posts.Where(n => n.loai==1);
            lstPost = lstPost.OrderBy(n => n.id);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(lstPost.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult displaypostbydm(int?page,string id_danhmuc)
        {
            var lstPost = db.posts.Where(n => n.loai == 1&&n.id_danhmuc==id_danhmuc);
            lstPost = lstPost.OrderBy(n => n.id);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            var b = db.danhmucs.Single(x => x.id == id_danhmuc);
            ViewBag.id_danhmuc = id_danhmuc;
            ViewBag.tendm = b.name;
            return View(lstPost.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult DisplayDetailPost(int? id ,string title)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            } // Neu khong thi truy xuat csdl lay ra san pham tuong ung
            post ps = db.posts.SingleOrDefault(n => n.id == id);
            if (ps == null)
            {
            }
            return View(ps);
        }
    }
}