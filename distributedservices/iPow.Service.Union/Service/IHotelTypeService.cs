using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Service.Union.Service
{
    public interface IHotelTypeService
    {
        /// <summary>
        /// Gets the type of the hotel.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        string GetHotelType(int id);

        /// <summary>
        /// Gets the hotel type id.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        int GetHotelTypeId(string str);

    }
}
