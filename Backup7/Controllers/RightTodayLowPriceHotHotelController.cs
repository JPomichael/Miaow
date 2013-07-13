using System;
using System.Web.Mvc;
using System.Collections.Generic;

using iPow.Application.Union.Dto;
using iPow.Infrastructure.Crosscutting.Comm.Dto;

namespace iPow.Presentation.Union.Controllers
{
    [HandleError]
    public class RightTodayLowPriceHotHotelController : 
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        /// <summary>
        /// 
        /// </summary>
        iPow.Infrastructure.Crosscutting.Comm.Service.ILocationService localtionService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Service.Union.Service.ITodayLowPriceService todayLowPriceService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Service.Union.Service.ICityService cityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RightTodayLowPriceHotHotelController"/> class.
        /// </summary>
        public RightTodayLowPriceHotHotelController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Infrastructure.Crosscutting.Comm.Service.ILocationService ipowLocaltion,
            iPow.Service.Union.Service.ITodayLowPriceService ipowTodayLowPrice,
            iPow.Service.Union.Service.ICityService ipowCity)
            : base(work)
        {
            if (ipowLocaltion == null)
            {
                throw new ArgumentNullException("localtionService is null");
            }
            if (ipowTodayLowPrice == null)
            {
                throw new ArgumentNullException("todayLowPriceService is null");
            }
            if (ipowCity == null)
            {
                throw new ArgumentNullException("cityService is null");
            }
            localtionService = ipowLocaltion;
            todayLowPriceService = ipowTodayLowPrice;
            cityService = ipowCity;
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult GetTodayLowPrice()
        {

            List<TodayLowPriceDto> data = null;
            var li = localtionService.GetLocationInfo();
            if (li != null)
            {
                var cityId = cityService.GetUnionCityIdByName(string.IsNullOrEmpty(li.City) ? "深圳" : li.City);
                if (cityId > 0)
                {
                    data = todayLowPriceService.GetUnionTodayLowPriceByCityIdAndType(cityId.ToString(), "0", true, 5);
                }
            }
            return View("RightTodayLowPrice", data);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public ActionResult GetHotHotel()
        {
            List<TodayLowPriceDto> data = null;
            var li = localtionService.GetLocationInfo();
            if (li != null)
            {
                var cityId = cityService.GetUnionCityIdByName(string.IsNullOrEmpty(li.City) ? "广州" : li.City);
                if (cityId > 0)
                {
                    data = todayLowPriceService.GetUnionTodayLowPriceByCityIdAndType(cityId.ToString(), "1", false, 10);
                }
            }
            return View("RightHotHotelPartial", data);
        }
    }
}
