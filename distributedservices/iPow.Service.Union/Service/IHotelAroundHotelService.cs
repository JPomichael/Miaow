using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHotelAroundHotelService
    {
        /// <summary>
        /// Gets the hotel around hotel by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        List<iPow.Application.Union.Dto.HotelInfoDto> GetHotelAroundHotelById(string id);

        /// <summary>
        /// Gets the hotel around hotel list by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        List<iPow.Application.Union.Dto.HotelAroundHotelDto> GetHotelAroundHotelListById(string id);
    }
}
