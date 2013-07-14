using System;
using System.Linq;
using System.Web.Mvc;

namespace Miaow.Presentation.Union.Controllers
{
    [HandleError]
    public class LeftMidHotHotelController :
        Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {
        /// <summary>
        /// 
        /// </summary>
        Miaow.Service.Union.Service.IHotelLeftMidService hoteLeftMidService;

        /// <summary>
        /// 
        /// </summary>
        Miaow.Application.jq.Service.ISightInfoService sightInfoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeftMidHotHotelController"/> class.
        /// </summary>
        /// <param name="work">The work.</param>
        /// <param name="MiaowHoteLeftMid">The Miaow hote left mid.</param>
        /// <param name="MiaowSightInfo">The Miaow sight info.</param>
        public LeftMidHotHotelController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            Miaow.Service.Union.Service.IHotelLeftMidService MiaowHoteLeftMid,
            Miaow.Application.jq.Service.ISightInfoService MiaowSightInfo)
            : base(work)
        {
            if (MiaowHoteLeftMid == null)
            {
                throw new ArgumentNullException("hoteLeftMidService is null");
            }
            if (MiaowSightInfo == null)
            {
                throw new ArgumentNullException("sightInfoService is null");
            }
            hoteLeftMidService = MiaowHoteLeftMid;
            sightInfoService = MiaowSightInfo;
        }

        /// <summary>
        /// Indexes the specified ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult Index(string ids, int? min, int? max)
        {
            Miaow.Application.Union.Dto.SearchHotelDto data = null;
            int id = Int32.Parse(ids);
            var res = sightInfoService.GetSightSingleById(id);
            if (res != null && res.Latitude != null && res.Longitude != null)
            {
                var intime = System.DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "_");
                string cityName = "深圳";
                string latlon = "";
                string strMin = "0";
                string strMax = "0";
                if (min != null)
                {
                    strMin = min.ToString();
                }
                if (max != null)
                {
                    strMax = max.ToString();
                }
                cityName = res.City.Replace("市", "");
                latlon = "(" + res.Latitude.ToString() + "," + res.Longitude.ToString() + ")";
                data = hoteLeftMidService.GetMidHotHotelByLatLong(intime, cityName, Server.UrlEncode(latlon), "1", strMin, strMax);
            }
            return PartialView(data);
        }
    }
}
