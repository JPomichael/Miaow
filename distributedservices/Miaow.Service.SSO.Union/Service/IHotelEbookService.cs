using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
   public interface IHotelEbookService
    {
        /// <summary>
        /// Gets the hotel oder list by phone.
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <returns></returns>
       List<Miaow.Application.Union.Dto.HotelEbookDto> GetHotelOderListByPhone(string phone);
    }
}
