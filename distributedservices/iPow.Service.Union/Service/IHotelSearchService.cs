using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHotelSearchService
    {
        /// <summary>
        /// Gets the hotel search model.
        /// </summary>
        /// <param name="intime">The intime.</param>
        /// <param name="cidName">Name of the cid.</param>
        /// <param name="key">The key.</param>
        /// <param name="pi">The pi.</param>
        /// <param name="price1">The price1.</param>
        /// <param name="price2">The price2.</param>
        /// <param name="type">The type.</param>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        iPow.Application.Union.Dto.SearchHotelDto GetHotelSearchModel(string intime, string cidName, string key,
              string pi = "1", string price1 = "0", string price2 = "0", string type = "0", string order = "0");
    }
}
