using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelCommService : IHotelCommService
    {
        /// <summary>
        /// Gets the hotel comm by id.
        /// </summary>
        /// <param name="hid">The hid.</param>
        /// <param name="cid">The cid.</param>
        /// <param name="pi">The pi.</param>
        /// <param name="type">The type.0是全部，1是好，2是中，3是差，4是带图片的。</param>
        /// <returns></returns>
        public iPow.Application.Union.Dto.HotelCommListDto GetHotelCommById(string hid, string cid, string pi = "1", string type = "0")
        {
            //http://data.128uu.com/data/hotel_dianpinglist/?hotelid=658&cid=21&px=1&type=1&agent_id=112935&agent_md=O81U21UM11.html
            iPow.Application.Union.Dto.HotelCommListDto data = null;
            Config.IUnionConfig fig = Config.ConfigManager.GetConfigProvider();
            UnionDataUrlBase dataUrl = new DataUrl.Default.HotelDianPingListDefaultService(fig);
            dataUrl.UrlParas.Add("hotelid", hid);
            dataUrl.UrlParas.Add("cid", cid.ToString());
            dataUrl.UrlParas.Add("px", pi);
            dataUrl.UrlParas.Add("type", type);
            iPow.Infrastructure.Crosscutting.Function.WebHttpHelper req = new Infrastructure.Crosscutting.Function.WebHttpHelper();
            var url = dataUrl.GetUrl();
            try
            {
                var dataStr = req.WebRequest(iPow.Infrastructure.Crosscutting.Function.HttpMethod.GET, url.AbsoluteUri, "");
                if (dataStr != null && dataStr != "")
                {
                    data = Newtonsoft.Json.JsonConvert.DeserializeObject<iPow.Application.Union.Dto.HotelCommListDto>(dataStr);
                }
            }
            catch (Exception ex)
            {
                iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0,
                       iPow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl(),
                       iPow.Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl(),
                       "酒店评论", ex.Message,
                       iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP());
            }
            return data;
        }

        /// <summary>
        /// Gets the hotel comm count by id.
        /// 这个方法暂时没有用 by 2011.11.28.9.12
        /// </summary>
        /// <param name="hid">The hid.</param>
        /// <param name="cid">The cid.</param>
        /// <returns></returns>
        public int GetHotelCommCountById(string hid, string cid)
        {
            var res = 0;
            var temp = GetHotelCommById(hid, cid, "1", "0");
            res += temp.total;
            temp = GetHotelCommById(hid, cid, "1", "1");
            res += temp.total;
            temp = GetHotelCommById(hid, cid, "1", "2");
            res += temp.total;
            return res;
        }
    }
}