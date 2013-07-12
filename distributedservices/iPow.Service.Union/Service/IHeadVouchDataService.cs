using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHeadVouchDataService
    {
        /// <summary>
        /// Gets the name of the vouch sight by city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        IQueryable<iPow.Application.Union.Dto.HeadVouchSightInfoDto> GetVouchSightByCityName(string city, int take);

        /// <summary>
        /// Gets the left hot sight info by province.
        /// </summary>
        /// <param name="prov">The prov.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        IQueryable<iPow.Application.Union.Dto.HotelLeftSightInfoDto> GetLeftHotSightInfoByProvince(string prov, int take);

        /// <summary>
        /// Gets the left hot sight info by city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        IQueryable<iPow.Application.Union.Dto.HotelLeftSightInfoDto> GetLeftHotSightInfoByCity(string city, int take);

        /// <summary>
        /// Gets the hotel bottom links.
        /// </summary>
        /// <returns></returns>
        IQueryable<iPow.Application.Union.Dto.HotelBottomLinkDto> GetHotelBottomLinks();
    }
}
