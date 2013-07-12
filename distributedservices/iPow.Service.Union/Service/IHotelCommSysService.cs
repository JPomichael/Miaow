using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHotelCommSysService
    {
        /// <summary>
        /// Gets the hotel comm page list by hotel id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
       List<iPow.Domain.Dto.Sys_HotelCommDto> GetHotelCommPageListByHotelId(int id, int pageIndex, int take, ref int total);
    }
}
