using System.Web.Mvc;

namespace iPow.jd.Controllers
{
    public class HeadVouchDataController : ControllerBase
    {

        [HttpGet]
        [OutputCache(Duration = 3600)]
        public ActionResult GetVouchData(string city)
        {
            ViewBag.city = city;
            return PartialView("HeadVouchDataPartial");
        }
    }
}
