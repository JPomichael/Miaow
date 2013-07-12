using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class TodayLowPriceService : ITodayLowPriceService
    {
        /// <summary>
        /// Gets the type of the union today low price by city id and.
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <param name="type">The type.</param>
        /// <param name="orderbyprice">if set to <c>true</c> [orderbyprice].</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public List<iPow.Application.Union.Dto.TodayLowPriceDto> GetUnionTodayLowPriceByCityIdAndType(string cid, string type, bool orderbyprice, int take)
        {
            List<iPow.Application.Union.Dto.TodayLowPriceDto> data = null;
            iPow.Application.Union.Dto.TodayLowPriceDto temp = null;
            Config.IUnionConfig fig = Config.ConfigManager.GetConfigProvider();
            UnionDataUrlBase provider = new DataUrl.Default.IndexHotelDefaultService(fig);
            provider.UrlParas.Add("cid", cid);
            provider.UrlParas.Add("type_id", type);
            var url = provider.GetUrl();
            iPow.Infrastructure.Crosscutting.Function.WebHttpHelper req = new Infrastructure.Crosscutting.Function.WebHttpHelper();
            try
            {
                var dataStr = req.WebRequest(iPow.Infrastructure.Crosscutting.Function.HttpMethod.GET, url.ToString(), "");
                if (string.IsNullOrEmpty(req.Message) && !string.IsNullOrEmpty(dataStr))
                {
                    data = new List<iPow.Application.Union.Dto.TodayLowPriceDto>();
                    var jarray = Newtonsoft.Json.Linq.JArray.Parse(dataStr);
                    foreach (var item in jarray)
                    {
                        temp = new iPow.Application.Union.Dto.TodayLowPriceDto();
                        temp.address = item["address"] == null ? string.Empty : item["address"].ToString();
                        temp.cid = item["cid"] == null ? -1 : int.Parse(item["cid"].ToString());
                        temp.id = item["id"] == null ? -1 : int.Parse(item["id"].ToString());
                        temp.name = item["name"] == null ? string.Empty : item["name"].ToString();
                        temp.pic = item["pic"] == null ? string.Empty : item["pic"].ToString();
                        temp.price = item["price"] == null ? 0.0 : double.Parse(item["price"].ToString());
                        temp.xingji = item["xingji"] == null ? string.Empty : item["xingji"].ToString();
                        data.Add(temp);
                    }
                }
            }
            catch (Exception ex)
            { }
            if (orderbyprice && data != null)
            {
                data = data.OrderBy(e => e.price)
                    .Take(take)
                    .ToList();
            }
            return data;
        }
    }
}