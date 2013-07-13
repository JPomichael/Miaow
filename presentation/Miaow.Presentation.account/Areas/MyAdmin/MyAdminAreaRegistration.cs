using System.Web.Mvc;

namespace iPow.Presentation.account.Areas.MyAdmin
{
    public class MyAdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MyAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MyAdmin_default",
                "MyAdmin/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, null,
                new string[] { "iPow.Presentation.account.Areas.MyAdmin" }
            );
        }
    }
}
