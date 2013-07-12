using System;
using System.Linq;
using System.Web.Mvc;

namespace iPow.Presentation.Union.Controllers
{
    [HandleError]
    public class LeftMidHotHotelController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        /// <summary>
        /// 
        /// </summary>
        iPow.Service.Union.Service.IHotelLeftMidService hoteLeftMidService;

        /// <summary>
        /// 
        /// </summary>
        iPow.Application.jq.Service.ISightInfoService sightInfoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LeftMidHotHotelController"/> class.
        /// </summary>
        /// <param name="work">The work.</param>
        /// <param name="ipowHoteLeftMid">The ipow hote left mid.</param>
        /// <param name="ipowSightInfo">The ipow sight info.</param>
        public LeftMidHotHotelController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
            iPow.Service.Union.Service.IHotelLeftMidService ipowHoteLeftMid,
            iPow.Application.jq.Service.ISightInfoService ipowSightInfo)
            : base(work)
        {
            if (ipowHoteLeftMid == null)
            {
                throw new ArgumentNullException("hoteLeftMidService is null");
            }
            if (ipowSightInfo == null)
            {
                throw new ArgumentNullException("sightInfoService is null");
            }
            hoteLeftMidService = ipowHoteLeftMid;
            sightInfoService = ipowSightInfo;
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
            iPow.Application.Union.Dto.SearchHotelDto data = null;
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
