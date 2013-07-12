using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelLeftMidService : IHotelLeftMidService
    {
        /// <summary>
        /// 
        /// </summary>
        private iPow.Service.Union.Service.ICityService cityService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelLeftMidService"/> class.
        /// </summary>
        /// <param name="city">The city.</param>
        public HotelLeftMidService(iPow.Service.Union.Service.ICityService city)
        {
            cityService = city;
        }

        /// <summary>
        /// Gets the mid hot hotel by lat long.
        /// </summary>
        /// <param name="intime">The intime.</param>
        /// <param name="cidName">Name of the cid.</param>
        /// <param name="latlong">The latlong.</param>
        /// <param name="pi">The pi.</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        public iPow.Application.Union.Dto.SearchHotelDto GetMidHotHotelByLatLong(string intime, string cidName, string latlong, string pi = "1", string min = "0", string max = "0", string order = "4")
        {
            iPow.Application.Union.Dto.SearchHotelDto data = null;
            if (!string.IsNullOrEmpty(intime) && !string.IsNullOrEmpty(cidName) &&
                !string.IsNullOrEmpty(pi) && !string.IsNullOrEmpty(order))
            {
                var cid = cityService.GetUnionCityIdByName(cidName.Replace("市", ""));
                if (cid > 0)
                {
                    Config.IUnionConfig fig = Config.ConfigManager.GetConfigProvider();
                    UnionDataUrlBase dataUrl = new DataUrl.Default.HotelSearchDefaultService(fig);
                    dataUrl.UrlParas.Add("t1", intime);
                    dataUrl.UrlParas.Add("cid", cid.ToString());
                    dataUrl.UrlParas.Add("pg", pi);
                    dataUrl.UrlParas.Add("px", order);
                    dataUrl.UrlParas.Add("p1", min);
                    dataUrl.UrlParas.Add("p2", max);
                    dataUrl.UrlParas.Add("pos", latlong);
                    iPow.Infrastructure.Crosscutting.Function.WebHttpHelper req = new Infrastructure.Crosscutting.Function.WebHttpHelper();
                    var url = dataUrl.GetUrl();
                    try
                    {
                        var dataStr = req.WebRequest(iPow.Infrastructure.Crosscutting.Function.HttpMethod.GET, url.AbsoluteUri, "");
                        if (dataStr != null && dataStr != "")
                        {
                            data = Newtonsoft.Json.JsonConvert.DeserializeObject<iPow.Application.Union.Dto.SearchHotelDto>(dataStr);
                        }
                    }
                    catch (Exception ex)
                    {
                        iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0,
                            iPow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl(),
                            iPow.Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl(),
                            "酒店首页中间部分", ex.Message,
                            iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP());
                    }
                }
            }
            return data;
        }
    }
}