using System.Web.Mvc;

namespace iPow.jd.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用 ASP.NET MVC!";
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Links()
        {
            return PartialView("BottomLinkPartial");
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult Bottom()
        {
            return PartialView("BottomPartial");
        }
    }
}
