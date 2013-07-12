using System;
using System.Linq;
using System.Web.Mvc;

namespace iPow.jd.Controllers
{
    public class LeftMidHotHotelController : ControllerBase
    {
        //
        // GET: /LeftMidHotHotel/
        [HttpGet]
        public ActionResult Index(string ids, int? min, int? max)
        {
            int id = Int32.Parse(ids);
            IQueryable<Models.MidHotHotelInfo> hi = null;
            hi = Bll.LeftMidHotHotel.GetLeftMidHotHotelListbySightIdAndTickeyt(id, min, max, 3);
            return PartialView(hi);
        }
    }
}
