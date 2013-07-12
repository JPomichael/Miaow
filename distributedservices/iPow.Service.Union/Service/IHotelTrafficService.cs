using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Service.Union.Service
{
    public interface IHotelTrafficService
    {
        /// <summary>
        /// Gets the hotel traffic by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        iPow.Application.Union.Dto.HotelTrafficDto GetHotelTrafficById(string id);

        /// <summary>
        /// Cirs the point.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="xt">The xt.</param>
        /// <param name="yr">The yr.</param>
        /// <param name="cir">The cir.</param>
        /// <returns></returns>
        bool CirPoint(double x, double y, double xt, double yr, double cir);

        /// <summary>
        /// Gets the hotel around sight by lat.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <param name="lat">The lat.</param>
        /// <param name="lon">The lon.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        List<iPow.Domain.Dto.Sys_SightInfoDto> GetHotelAroundSightByLat(string cityName, double lat, double lon, int take);


    }
}
