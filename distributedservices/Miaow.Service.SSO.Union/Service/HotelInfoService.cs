using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Miaow.Application.Union.Dto;
using Miaow.Service.Union.Config;

namespace Miaow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelInfoService : IHotelInfoService
    {

        /// <summary>
        /// Gets the hotel info by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Miaow.Application.Union.Dto.HotelInfoDto GetHotelInfoById(string id)
        {
            Miaow.Application.Union.Dto.HotelInfoDto info = null;
            Config.IUnionConfig fig = Config.ConfigManager.GetConfigProvider();
            UnionDataUrlBase dataUrl = new DataUrl.Default.HotelInfoDefaultService(fig);
            dataUrl.UrlParas.Add("hotel_id", id.ToString());
            Miaow.Infrastructure.Crosscutting.Function.WebHttpHelper req = new Infrastructure.Crosscutting.Function.WebHttpHelper();
            try
            {
                var res = req.WebRequest(Miaow.Infrastructure.Crosscutting.Function.HttpMethod.GET, dataUrl.GetUrl().ToString(), "");
                if (!string.IsNullOrEmpty(res))
                {
                    info = Newtonsoft.Json.JsonConvert.DeserializeObject<Miaow.Application.Union.Dto.HotelInfoDto>(res);
                }
            }
            catch (Exception ex)
            {
                Miaow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0,
                       Miaow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl(),
                       Miaow.Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl(),
                       "酒店信息", ex.Message,
                       Miaow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP());
            }
            return info;
        }
    }
}