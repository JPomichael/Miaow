using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPow.Application.jq.Dto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
   public interface IHomeService
    {
        /// <summary>
        /// Gets the home model by city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="pi">The pi.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        HomeDto GetHomeModelByCity(string city, int pi, int pageSize);

        /// <summary>
        /// Gets the type of the home model by city and.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="type">The type.</param>
        /// <param name="b">if set to <c>true</c> [b].</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        HomeDto GetHomeModelByCityAndType(string city, int? type, bool b, int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets the home model by prov and city and ticket.
        /// </summary>
        /// <param name="prov">The prov.</param>
        /// <param name="type">The type.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        HomeDto GetHomeModelByProvAndCityAndTicket(string prov, int? type, int? start, int? end, int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets the type of the home model by prov and city and.
        /// </summary>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <param name="type">The type.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        HomeDto GetHomeModelByProvAndCityAndType(string province, string city, int? type, int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets the home model no city.
        /// </summary>
        /// <param name="pi">The pi.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        HomeDto GetHomeModelNoCity(int pi, int pageSize);

    }
}
