using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using viettours.Models;
namespace viettours.Controllers
{
    public class toursssController : Controller
    {
        // GET: toursss
        viettoursDBEntities db = new viettoursDBEntities();
        public ActionResult Index(int loai, string iddanhmuc, int? page)
        {
            var a = db.tour_select(loai, iddanhmuc).ToList();
            var b = db.danhmucs.Single(x => x.id == iddanhmuc);
            ViewBag.tendm = b.name;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            ViewBag.loai = loai;
            ViewBag.iddanhmuc = iddanhmuc;
            return View(a.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult search(string Searchday, string Searchmenu, int? page)
        {
            List<tour> list = db.tours.Select(x => x).ToList();
            if (!string.IsNullOrEmpty(Searchmenu))
            {
                var dmc = db.danhmuccons.SingleOrDefault(x => x.id == Searchmenu);
                if (dmc != null)
                {
                    if (dmc.danhmuccha != "A1")
                    {
                        list = db.tour_select(1, Searchmenu).ToList();
                    }
                    else
                        list = db.tour_select(0, Searchmenu).ToList();
                }

            }

            if (!String.IsNullOrEmpty(Searchday))
            {
                int i = int.Parse(Searchday);
                if (i == 11)
                {
                    list = list.Where(x => x.thoigian > 10).ToList();
                }
                else if (i == 1)
                {
                    list = list.Where(x => x.thoigian == 1).ToList();
                }
                else
                {
                    list = list.Where(x => x.thoigian >= (i - 2) && x.thoigian <= i).ToList();
                }

            }
            List<SelectListItem> day = new List<SelectListItem>() {
                new SelectListItem() { Value="1",Text="1 ngày" },
                new SelectListItem() { Value = "4", Text = "2-4 ngày" },
                new SelectListItem() { Value = "7", Text = "5-7 ngày" },
                new SelectListItem() { Value = "10", Text = "8-10 ngày" },
                new SelectListItem() { Value = "11", Text = "trên 10 ngày" },
            };
            ViewBag.Searchday = new SelectList(day, "Value", "Text");
            var a = db.danhmuccon_select_all().Where(x => x.loaidm == 0).ToList();
            ViewBag.Searchmenu = new SelectList(a, "id", "name");
            int pageNumber = (page ?? 1);
            int pageSize = 8;
            return View(list.OrderBy(x => x.id).ToPagedList(pageNumber, pageSize));

        }

        public ActionResult DisplayAllTour(int? page)
        {
            var lstTour = db.tours.Select(n => n);
            lstTour = lstTour.OrderBy(n => n.id);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            if (lstTour.Count() == 0)
            {
                // thay view bag trang trong
            }
            return View(lstTour.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DisplayDetailTour(int? id, string nameTour)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            } // Neu khong thi truy xuat csdl lay ra san pham tuong ung
            tour ts = db.tours.SingleOrDefault(n => n.id == id);
            if (ts == null)
            {
                return HttpNotFound();
            }
            return View(ts);
        }
        [HttpPost]
        public ActionResult dattourabc(dattour dat)
        {
            if (Session["account"] == null)
            {
                if (Session["dattours"] == null)
                    Session["dattours"] = new List<dattour>();
            }
            if (Session["account"] != null)
                dat.acc_id = ((account)Session["account"]).id;
            var a = Session["dattours"] as List<dattour>;
            a.Add(dat);
            Session["dattours"] = a;
            db.dattours.Add(dat);
            db.SaveChanges();
            return Content("<script language='javascript' type='text/javascript'>alert('Đặt tour thành công');</script>");
        }
    }
}