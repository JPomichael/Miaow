using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHotelInfoService
    {
        /// <summary>
        /// Gets the hotel info by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        Miaow.Application.Union.Dto.HotelInfoDto GetHotelInfoById(string id);
    }
}
