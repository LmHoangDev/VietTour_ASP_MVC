using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using viettours.Models;

namespace viettours.Controllers
{
    public class cdmController : Controller
    {
        // GET: cdm
        viettoursDBEntities db = new viettoursDBEntities();
        public ActionResult Index(string id)
        {
            var a = db.danhmucs.Single(x => x.id == id);
            return View(a);
        }
    }
}