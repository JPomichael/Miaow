using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelRoomService : IHotelRoomService
    {
        /// <summary>
        /// Gets the hotel room by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public iPow.Application.Union.Dto.HotelRoomDto GetHotelRoomById(string id)
        {
            iPow.Application.Union.Dto.HotelRoomDto data = null;
            var url = "http://price.128uu.com/data/unionroomlist.asp?hid=" + id;
            iPow.Infrastructure.Crosscutting.Function.WebHttpHelper req = new Infrastructure.Crosscutting.Function.WebHttpHelper();
            try
            {
                var dataStr = req.WebRequest(iPow.Infrastructure.Crosscutting.Function.HttpMethod.GET, url, "");
                if (dataStr != null && dataStr != "")
                {
                    dataStr = dataStr.Replace("formartdata({Hotels:{Hotel:[", "");
                    dataStr = dataStr.Replace("]}})", "");
                    dataStr = dataStr.Replace("]},ElongId:\"0\"})", "");
                    data = Newtonsoft.Json.JsonConvert.DeserializeObject<iPow.Application.Union.Dto.HotelRoomDto>(dataStr);
                }
            }
            catch (Exception ex)
            {
                iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0,
                                iPow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl(),
                                iPow.Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl(),
                                "酒店房间", ex.Message,
                                iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP());
            }
            return data;
        }

        /// <summary>
        /// Gets the hotel room fang tai.
        /// </summary>
        /// <param name="inTime">The in time.</param>
        /// <param name="leaveTime">The leave time.</param>
        /// <param name="days">The day list.</param>
        /// <param name="fts">The ft list.</param>
        /// <returns></returns>
        public int GetHotelRoomFangTai(DateTime inTime, DateTime leaveTime, string days, string fts)
        {
            var res = -1;
            var span = leaveTime - inTime;
            if (span.TotalSeconds < 0)
            {
                res = -2;
                //退房时间小于入住时间
            }
            var dayList = days.Split('|').ToList();
            var ftList = fts.Split('|').ToList();
            if (dayList.Count != ftList.Count)
            {
                res = -3;
                //房态列表长度，和时间列表长度不一样
            }
            else
            {
                var position = -1;
                var timeTemp = inTime.Year.ToString() + "-" + inTime.Month.ToString() + "-" + inTime.Day.ToString();
                for (int i = 0; i < dayList.Count; i++)
                {
                    if (dayList[i].CompareTo(timeTemp) == 0)
                    {
                        position = i;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (position >= 0)
                {
                    var temp = 0;
                    for (int i = position; i < position + span.Days; i++)
                    {
                        temp += int.Parse(ftList[i]);
                    }
                    res = temp;
                }
                else
                {
                    res = -4;
                    //在时间列表里面没有找到入住时间
                }
            }
            return res;
        }

        /// <summary>
        /// Gets the hotel room price.
        /// </summary>
        /// <param name="inTime">The in time.</param>
        /// <param name="days">The days.</param>
        /// <param name="prices">The prices.</param>
        /// <returns></returns>
        public double GetHotelRoomPrice(DateTime inTime, string days, string prices)
        {
            var res = -1.0;
            var dayList = days.Split('|').ToList();
            var priceList = prices.Split('|').ToList();
            if (dayList.Count != priceList.Count)
            {
                res = -3.0;
                //价格列表长度，和时间列表长度不一样
            }
            else
            {
                var position = -1;
                var timeTemp = inTime.Year.ToString() + "-" + inTime.Month.ToString() + "-" + inTime.Day.ToString();
                for (int i = 0; i < dayList.Count; i++)
                {
                    if (dayList[i].CompareTo(timeTemp) == 0)
                    {
                        position = i;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (position >= 0)
                {
                    res = double.Parse(priceList[position]);
                }
                else
                {
                    res = -4.0;
                    //在时间列表里面没有找到入住时间
                }
            }
            return res;
        }

        /// <summary>
        /// Gets the room time has room.
        /// </summary>
        /// <param name="fts">The FTS.</param>
        /// <param name="days">The day list.</param>
        /// <returns></returns>
        public DateTime GetRoomTimeHasRoom(string fts, string days)
        {
            DateTime res = DateTime.Now;
            if (!string.IsNullOrEmpty(fts) && !string.IsNullOrEmpty(days))
            {
                var ftList = fts.Split('|').ToList();
                var dayList = days.Split('|').ToList();
                if (ftList.Count == dayList.Count)
                {
                    var target = -1;
                    #region 找到可入住的房态 找到1
                    for (int i = 0; i < ftList.Count; i++)
                    {
                        if (ftList[i].CompareTo("0") != 0)
                        {
                            target = i;
                            break;
                        }
                    }
                    if (target == 0)
                    {
                        for (int i = 0; i < ftList.Count; i++)
                        {
                            if (ftList[i].CompareTo("0") == 0)
                            {
                                target = i;
                                break;
                            }
                        }
                    }
                    else if (target <= ftList.Count - 1)
                    {
                        target = 0;
                    }
                    #endregion
                    try
                    {
                        res = DateTime.Parse(dayList[target]);
                    }
                    catch (Exception ex)
                    {
                        iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(1, 0,
                                iPow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl(),
                                iPow.Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl(),
                                "酒店房间时间转换", ex.Message,
                                iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP());
                    }
                }
            }
            return res;
        }

    }
}