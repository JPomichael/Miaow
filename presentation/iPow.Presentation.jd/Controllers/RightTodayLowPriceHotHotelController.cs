using System.Web.Mvc;

namespace iPow.jd.Controllers
{
    public class RightTodayLowPriceHotHotelController : ControllerBase
    {
        //
        // GET: /TodayLowPrice/
        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult GetTodayLowPrice()
        {
            return PartialView("RightTodayLowPrice");
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult GetHotHotel()
        {
            return PartialView("RightHotHotelPartial");
        }
    }
}
