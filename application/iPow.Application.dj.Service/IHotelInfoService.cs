using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.dj.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHotelInfoService
    {
        /// <summary>
        /// Gets the hot hotel.
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        IQueryable<Dto.HotelInfoDto> GetHotHotel(int take);
    }
}
