using System;
using System.Web.Mvc;
using System.Collections.Generic;

using Miaow.Application.Union.Dto;
using Miaow.Infrastructure.Crosscutting.Comm.Dto;

namespace Miaow.Presentation.Union.Controllers
{
    [HandleError]
    public class RightTodayLowPriceHotHotelController : 
        Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {
        /// <summary>
        /// 
        /// </summary>
        Miaow.Infrastructure.Crosscutting.Comm.Service.ILocationService localtionService;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Service.Union.Service.ITodayLowPriceService todayLowPriceService;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Service.Union.Service.ICityService cityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RightTodayLowPriceHotHotelController"/> class.
        /// </summary>
        public RightTodayLowPriceHotHotelController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            Miaow.Infrastructure.Crosscutting.Comm.Service.ILocationService MiaowLocaltion,
            Miaow.Service.Union.Service.ITodayLowPriceService MiaowTodayLowPrice,
            Miaow.Service.Union.Service.ICityService MiaowCity)
            : base(work)
        {
            if (MiaowLocaltion == null)
            {
                throw new ArgumentNullException("localtionService is null");
            }
            if (MiaowTodayLowPrice == null)
            {
                throw new ArgumentNullException("todayLowPriceService is null");
            }
            if (MiaowCity == null)
            {
                throw new ArgumentNullException("cityService is null");
            }
            localtionService = MiaowLocaltion;
            todayLowPriceService = MiaowTodayLowPrice;
            cityService = MiaowCity;
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
