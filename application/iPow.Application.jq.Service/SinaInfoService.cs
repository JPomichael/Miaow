using System;
using System.Web;

using iPow.Application.jq.Dto;
using iPow.Infrastructure.Crosscutting.Comm.Dto;

namespace iPow.Application.jq.Service
{
    public class SinaInfoService : ISinaInfoService
    {
        /// <summary>
        /// 
        /// </summary>
        iPow.Infrastructure.Crosscutting.Comm.Service.ILocationService locationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SinaInfoService"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        public SinaInfoService(iPow.Infrastructure.Crosscutting.Comm.Service.ILocationService location)
        {
            if (location == null)
            {
                throw new ArgumentNullException("locationservice is null");
            }
            locationService = location;
        }

        /// <summary>
        /// Gets the sina info.
        /// Inits the localtion.得到当前访问人的地址 
        /// </summary>
        /// <returns></returns>
        public LocationInfoDto GetSinaInfo()
        {
            //edit by yjihrp 2011.8.16.9.6
            string ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            LocationInfoDto li = null;
            li = locationService.GetLocationInfo(ipAddress);
            //end edit by yjihrp 2011.8.16.9.6
            //LocationInfo li = LocationFucntion.LocationInfo();
            if (li == null || string.IsNullOrEmpty(li.City) || string.IsNullOrEmpty(li.Province))
            {
                li = locationService.GetLocationInfo("58.61.36.80");
            }
            return li;
        }
    }
}