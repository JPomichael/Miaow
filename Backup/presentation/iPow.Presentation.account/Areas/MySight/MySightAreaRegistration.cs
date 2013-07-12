using System.Web.Mvc;

namespace iPow.Presentation.account.Areas.MySight
{
    public class MySightAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MySight";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MySight_default",
                "MySight/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
