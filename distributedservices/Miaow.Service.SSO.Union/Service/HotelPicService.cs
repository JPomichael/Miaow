using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Webdiyer.WebControls.Mvc;

namespace Miaow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelPicService : IHotelPicService
    {
        /// <summary>
        /// Gets the hotel pic by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pi">The pi.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public PagedList<Miaow.Application.Union.Dto.HotelPicDto> GetHotelPicById(string id, int pi, int take)
        {
            var list = GetHotelPicById(id);
            var temp = list.OrderBy(e => e.title).AsEnumerable();
            temp = temp.Skip(((pi - 1) >= 0 ? (pi - 1) : 0) * take).Take(take);
            PagedList<Miaow.Application.Union.Dto.HotelPicDto> data = new PagedList<Miaow.Application.Union.Dto.HotelPicDto>(temp, pi, take, list.Count);
            return data;
        }

        /// <summary>
        /// Gets the hotel pic by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public List<Miaow.Application.Union.Dto.HotelPicDto> GetHotelPicById(string id)
        {
            List<Miaow.Application.Union.Dto.HotelPicDto> data = null;
            Miaow.Application.Union.Dto.HotelPicDto temp = null;
            Config.IUnionConfig fig = Config.ConfigManager.GetConfigProvider();
            UnionDataUrlBase dataUrl = new DataUrl.Default.HotelPicDefaultService(fig);
            dataUrl.UrlParas.Add("hotel_id", id);
            var url = dataUrl.GetUrl();
            Miaow.Infrastructure.Crosscutting.Function.WebHttpHelper req = new Infrastructure.Crosscutting.Function.WebHttpHelper();
            try
            {
                var dataStr = req.WebRequest(Miaow.Infrastructure.Crosscutting.Function.HttpMethod.GET, url.ToString(), "");
                if (string.IsNullOrEmpty(req.Message) && !string.IsNullOrEmpty(dataStr))
                {
                    data = new List<Miaow.Application.Union.Dto.HotelPicDto>();
                    var jarray = Newtonsoft.Json.Linq.JArray.Parse(dataStr);
                    foreach (var item in jarray)
                    {
                        temp = new Miaow.Application.Union.Dto.HotelPicDto();
                        temp.src = item["src"] == null ? string.Empty : item["src"].ToString();
                        temp.title = item["title"] == null ? string.Empty : item["title"].ToString();
                        data.Add(temp);
                    }
                }
            }
            catch (Exception ex)
            {
                Miaow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0,
                            Miaow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl(),
                            Miaow.Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl(),
                            "酒店图片", ex.Message,
                            Miaow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP());

            }
            return data;
        }
    }
}