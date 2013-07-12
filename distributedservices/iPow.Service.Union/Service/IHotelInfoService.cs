using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Service.Union.Service
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
        iPow.Application.Union.Dto.HotelInfoDto GetHotelInfoById(string id);
    }
}
