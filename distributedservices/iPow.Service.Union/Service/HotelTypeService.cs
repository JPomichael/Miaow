using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iPow.Service.Union.Service
{
    public class HotelTypeService : IHotelTypeService
    {
        /// <summary>
        /// 
        /// </summary>
        private string[] hotelTypeList = new string[] { "经济型酒店", "连锁酒店", "三星级酒店", "四星级酒店", "五星级酒店", "酒店式公寓" };

        /// <summary>
        /// Gets the type of the hotel.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public string GetHotelType(int id)
        {
            if (id > hotelTypeList.Length)
            {
                return "暂时没有分类";
            }
            else
            {
                return hotelTypeList[(id - 1) > 0 ? (id - 1) : 0];
            }
        }

        /// <summary>
        /// Gets the hotel type id.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        public int GetHotelTypeId(string str)
        {
            var res = -1;
            for (int i = 0; i < hotelTypeList.Length; i++)
            {
                if (str.CompareTo(hotelTypeList[i]) == 0)
                {
                    res = i + 1;
                    break;
                }
                else if (hotelTypeList[i].Replace("酒店", "").IndexOf(str) == 0)
                {
                    res = i + 1;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return res;
        }
    }
}