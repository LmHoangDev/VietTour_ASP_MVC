using System.Web.Mvc;

namespace viettours.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index",Controller="Login", id = UrlParameter.Optional },
                new[] { "viettours.Areas.Admin.Controllers" }
            );
        }
    }
}