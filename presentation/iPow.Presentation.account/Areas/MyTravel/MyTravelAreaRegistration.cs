using System.Web.Mvc;

namespace iPow.Presentation.account.Areas.MyTravel
{
    public class MyTravelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MyTravel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MyTravel_default",
                "MyTravel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
