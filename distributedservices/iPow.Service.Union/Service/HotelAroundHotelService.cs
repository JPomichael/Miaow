using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 酒店的周边酒店
    /// </summary>
    public class HotelAroundHotelService : IHotelAroundHotelService
    {

        /// <summary>
        /// 
        /// </summary>
        private IHotelInfoService hotelInfoService = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelAroundHotelService"/> class.
        /// </summary>
        public HotelAroundHotelService(IHotelInfoService hiService)
        {
            if (hiService == null)
            {
                throw new ArgumentNullException("hotelinfoservice is null");
            }
            hotelInfoService = hiService;
        }

        /// <summary>
        /// Gets the hotel around hotel by id.
        /// </summary>
        /// <returns></returns>
        public List<iPow.Application.Union.Dto.HotelInfoDto> GetHotelAroundHotelById(string id)
        {
            List<iPow.Application.Union.Dto.HotelInfoDto> hi = new List<iPow.Application.Union.Dto.HotelInfoDto>();
            iPow.Application.Union.Dto.HotelInfoDto sin = null;
            var temp = GetHotelAroundHotelListById(id);
            foreach (var item in temp)
            {
                sin = hotelInfoService.GetHotelInfoById(item.id.ToString());
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
        public List<iPow.Application.Union.Dto.HotelAroundHotelDto> GetHotelAroundHotelListById(string id)
        {
            List<iPow.Application.Union.Dto.HotelAroundHotelDto> data = null;
            iPow.Application.Union.Dto.HotelAroundHotelDto temp = null;
            Config.IUnionConfig fig = Config.ConfigManager.GetConfigProvider();
            UnionDataUrlBase dataUrl = new DataUrl.Default.HotelAroundDefaultService(fig);
            dataUrl.UrlParas.Add("hid", id);
            var url = dataUrl.GetUrl();
            iPow.Infrastructure.Crosscutting.Function.WebHttpHelper req = new Infrastructure.Crosscutting.Function.WebHttpHelper();
            try
            {
                var dataStr = req.WebRequest(iPow.Infrastructure.Crosscutting.Function.HttpMethod.GET, url.ToString(), "");
                if (string.IsNullOrEmpty(req.Message) && !string.IsNullOrEmpty(dataStr))
                {
                    data = new List<iPow.Application.Union.Dto.HotelAroundHotelDto>();
                    var jarray = Newtonsoft.Json.Linq.JArray.Parse(dataStr);
                    foreach (var item in jarray)
                    {
                        temp = new iPow.Application.Union.Dto.HotelAroundHotelDto();
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
            {
                iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0,
                    iPow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl(),
                    iPow.Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl(),
                    "酒店周边酒店", ex.Message,
                    iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP());
            }
            return data;
        }
    }
}