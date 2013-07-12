using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHotelLeftMidService
    {
        /// <summary>
        /// Gets the mid hot hotel by lat long.
        /// </summary>
        /// <param name="intime">The intime.</param>
        /// <param name="cidName">Name of the cid.</param>
        /// <param name="latlong">The latlong.</param>
        /// <param name="pi">The pi.</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        iPow.Application.Union.Dto.SearchHotelDto GetMidHotHotelByLatLong(string intime, string cidName, string latlong, string pi = "1", string min = "0", string max = "0", string order = "4");
    }
}
