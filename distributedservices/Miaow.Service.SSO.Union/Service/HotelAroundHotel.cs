using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iPow.Union.Helpers;

using iPow.Union.Models;

namespace iPow.Union.Bll
{
    public class HotelAroundHotel
    {
        /// <summary>
        /// Gets the hotel around hotel by id.
        /// </summary>
        /// <returns></returns>
        public static List<Models.HotelInfoModel> GetHotelAroundHotelById(string id)
        {
            List<Models.HotelInfoModel> hi = new List<Models.HotelInfoModel>();
            Models.HotelInfoModel sin = null;
            var temp = GetHotelAroundHotelListById(id);
            foreach (var item in temp)
            {
                sin = HotelInfo.GetHotelInfoById(item.id.ToString());
                if (sin != null && sin.id > 0)
                {
                    hi.Add(sin);
                }
            }
            return hi;
        }

        /// <summary>
        /// Gets the hotel around hotel list by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        private static List<Models.HotelAroundHotel> GetHotelAroundHotelListById(string id)
        {
            List<Models.HotelAroundHotel> data = null;
            Models.HotelAroundHotel temp = null;
            Provider.Configs.IUnionConfig fig = Provider.Configs.ConfigManager.GetConfigProvider();
            Provider.DataUrl.UnionDataUrlProvider dataUrl = null;
            dataUrl = new Provider.DataUrl.Default.HotelAroundDefaultProvider(fig);
            dataUrl.UrlParas.Add("hid", id);
            var url = dataUrl.GetUrl();
            WebHttp req = new WebHttp();
            try
            {
                var dataStr = req.WebRequest(HttpMethod.GET, url.ToString(), "");
                if (string.IsNullOrEmpty(req.Message) && !string.IsNullOrEmpty(dataStr))
                {

                    data = new List<Models.HotelAroundHotel>();
                    var jarray = Newtonsoft.Json.Linq.JArray.Parse(dataStr);
                    foreach (var item in jarray)
                    {
                        temp = new Models.HotelAroundHotel();
                        temp.chaping = item["chaping"] == null ? -1 : int.Parse(item["chaping"].ToString());
                        temp.haoping = item["haoping"] == null ? -1 : int.Parse(item["haoping"].ToString());
                        temp.hotelname = item["hotelname"] == null ? string.Empty : item["hotelname"].ToString();
                        temp.id = item["id"] == null ? -1 : long.Parse(item["id"].ToString());
                        temp.juli = item["juli"] == null ? string.Empty : item["juli"].ToString();
                        temp.lowprice = item["lowprice"] == null ? 0.0 : double.Parse(item["lowprice"].ToString());
                        temp.xingji = item["xingji"] == null ? 0 : int.Parse(item["xingji"].ToString());
                        temp.zhongping = item["xingji"] == null ? 0 : int.Parse(item["xingji"].ToString());
                        data.Add(temp);
                    }
                }
            }
            catch (Exception ex)
            { }
            return data;
        }
    }
}