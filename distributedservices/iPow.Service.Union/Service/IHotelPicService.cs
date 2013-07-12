using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Webdiyer.WebControls.Mvc;
using iPow.Service.Union;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHotelPicService
    {
        /// <summary>
        /// Gets the hotel pic by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pi">The pi.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        PagedList<iPow.Application.Union.Dto.HotelPicDto> GetHotelPicById(string id, int pi, int take);

        /// <summary>
        /// Gets the hotel pic by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        List<iPow.Application.Union.Dto.HotelPicDto> GetHotelPicById(string id);
    }
}
