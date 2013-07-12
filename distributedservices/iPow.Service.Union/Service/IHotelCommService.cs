using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHotelCommService
    {
        /// <summary>
        /// Gets the hotel comm by id.
        /// </summary>
        /// <param name="hid">The hid.</param>
        /// <param name="cid">The cid.</param>
        /// <param name="pi">The pi.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        iPow.Application.Union.Dto.HotelCommListDto GetHotelCommById(string hid, string cid, string pi = "1", string type = "0");

        /// <summary>
        /// Gets the hotel comm count by id.
        /// </summary>
        /// <param name="hid">The hid.</param>
        /// <param name="cid">The cid.</param>
        /// <returns></returns>
        int GetHotelCommCountById(string hid, string cid);
    }
}
