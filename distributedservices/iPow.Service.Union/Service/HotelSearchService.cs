using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelSearchService : IHotelSearchService
    {
        /// <summary>
        /// 
        /// </summary>
        private iPow.Service.Union.Service.ICityService cityService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelSearchService"/> class.
        /// </summary>
        /// <param name="city">The city.</param>
        public HotelSearchService(iPow.Service.Union.Service.ICityService city)
        {
            if (city == null)
            {
                throw new ArgumentNullException("cityservice is null");
            }
            cityService = city;
        }

        /// <summary>
        /// Gets the hotel search model.
        /// </summary>
        /// <param name="intime">The intime.</param>
        /// <param name="cidName">Name of the cid.</param>
        /// <param name="key">The key.</param>
        /// <param name="pi">The pi.</param>
        /// <param name="price1">The price1.</param>
        /// <param name="price2">The price2.</param>
        /// <param name="type">The type.</param>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        public iPow.Application.Union.Dto.SearchHotelDto GetHotelSearchModel(string intime, string cidName, string key,
            string pi = "1", string price1 = "0", string price2 = "0", string type = "0", string order = "0")
        {
            iPow.Application.Union.Dto.SearchHotelDto data = null;
            if (!string.IsNullOrEmpty(intime) && !string.IsNullOrEmpty(cidName) &&
                !string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(pi) &&
                !string.IsNullOrEmpty(price1) && !string.IsNullOrEmpty(price2) &&
                !string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(order))
            {
                var cid = cityService.GetUnionCityIdByName(cidName.Replace("市", ""));
                if (cid > 0)
                {
                    Config.IUnionConfig fig = Config.ConfigManager.GetConfigProvider();
                    UnionDataUrlBase dataUrl = new DataUrl.Default.HotelSearchDefaultService(fig);
                    dataUrl.UrlParas.Add("t1", intime);
                    dataUrl.UrlParas.Add("cid", cid.ToString());
                    dataUrl.UrlParas.Add("jdlx", type);
                    dataUrl.UrlParas.Add("px", order);
                    dataUrl.UrlParas.Add("key_name", key);
                    dataUrl.UrlParas.Add("pg", pi);
                    dataUrl.UrlParas.Add("p1", price1);
                    dataUrl.UrlParas.Add("p2", price2);
                    iPow.Infrastructure.Crosscutting.Function.WebHttpHelper
                    req = new Infrastructure.Crosscutting.Function.WebHttpHelper();
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
                                    "酒店搜索", ex.Message,
                                    iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP());
                    }
                }
            }
            return data;
        }
    }
}