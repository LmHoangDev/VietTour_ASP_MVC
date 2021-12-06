using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace viettours.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
       /* public ActionResult Index()
        {
            return View();
        }*/
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            /*var session = (UserLogin)Session{ user session };
            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Login", action = "index", Area
                = Admin });
                

            }*/
            if (Session["admin"]==null)
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
            {
                controller = "Login",
                action = "index",
                Area = "Admin"
            }));
            base.OnActionExecuting(filterContext);

        }
    }
}