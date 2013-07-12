using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using iPow.Application.Union.Dto;
using iPow.Service.Union.Config;

namespace iPow.Service.Union.Service
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
        public iPow.Application.Union.Dto.HotelInfoDto GetHotelInfoById(string id)
        {
            iPow.Application.Union.Dto.HotelInfoDto info = null;
            Config.IUnionConfig fig = Config.ConfigManager.GetConfigProvider();
            UnionDataUrlBase dataUrl = new DataUrl.Default.HotelInfoDefaultService(fig);
            dataUrl.UrlParas.Add("hotel_id", id.ToString());
            iPow.Infrastructure.Crosscutting.Function.WebHttpHelper req = new Infrastructure.Crosscutting.Function.WebHttpHelper();
            try
            {
                var res = req.WebRequest(iPow.Infrastructure.Crosscutting.Function.HttpMethod.GET, dataUrl.GetUrl().ToString(), "");
                if (!string.IsNullOrEmpty(res))
                {
                    info = Newtonsoft.Json.JsonConvert.DeserializeObject<iPow.Application.Union.Dto.HotelInfoDto>(res);
                }
            }
            catch (Exception ex)
            {
                iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0,
                       iPow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl(),
                       iPow.Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl(),
                       "酒店信息", ex.Message,
                       iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP());
            }
            return info;
        }
    }
}