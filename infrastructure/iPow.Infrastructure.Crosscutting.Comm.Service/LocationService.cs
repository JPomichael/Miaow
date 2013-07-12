using System;
using System.Net;
using System.Collections;

using iPow.Infrastructure.Crosscutting.Comm.Dto;

namespace iPow.Infrastructure.Crosscutting.Comm.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class LocationService : ILocationService
    {
        /// <summary>
        /// Locations the info.
        /// </summary>
        /// <returns></returns>
        public LocationInfoDto GetLocationInfo()
        {
            string sinaResult;
            using (var w = new WebClient())
            {
                sinaResult = w.DownloadString("http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=xml");
            }
            ArrayList sinaInfo = new ArrayList(sinaResult.Split('\t'));
            if (sinaInfo != null && sinaInfo.Count > 7)
            {
                LocationInfoDto location = new LocationInfoDto();
                location.startIP = sinaInfo[1].ToString();
                location.endIP = sinaInfo[2].ToString();
                location.Country = sinaInfo[3].ToString();
                location.Province = sinaInfo[4].ToString();
                location.City = sinaInfo[5].ToString();
                location.ISP = sinaInfo[7].ToString();
                return location;
            }
            else
            {
                return GetLocationInfo();
            }
        }

        /// <summary>
        /// Locations the info.
        /// </summary>
        /// <param name="ipAddress">The ip.</param>
        /// <returns></returns>
        public LocationInfoDto GetLocationInfo(string ipAddress)
        {
            if (ipAddress.CompareTo("::1") == 0 || ipAddress.CompareTo("127.0.0.1") == 0)
            {
                return GetLocationInfo();
            }
            else
            {
                string sinaResult;
                using (var w = new WebClient())
                {
                    sinaResult = w.DownloadString("http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=xml&ip=" + ipAddress);
                }
                ArrayList sinaInfo = new ArrayList(sinaResult.Split('\t'));
                if (sinaInfo.Count > 1)
                {
                    if (Convert.ToInt16(sinaInfo[0]) < 1)
                    {
                        return GetLocationInfo();
                    }
                    else
                    {
                        if (sinaInfo.Count > 7)
                        {
                            LocationInfoDto location = new LocationInfoDto();
                            location.startIP = sinaInfo[1].ToString();
                            location.endIP = sinaInfo[2].ToString();
                            location.Country = sinaInfo[3].ToString();
                            location.Province = sinaInfo[4].ToString();
                            location.City = sinaInfo[5].ToString();
                            location.ISP = sinaInfo[7].ToString();
                            return location;
                        }
                        else
                        {
                            return GetLocationInfo();
                        }
                    }
                }
                else
                {
                    return GetLocationInfo();
                    //return LocationInfo(ip);
                }
            }
        }
    }
}
