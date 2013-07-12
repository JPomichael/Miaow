using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace iPow.Application.dj.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class HotelInfoService : IHotelInfoService
    {
        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.IHotelPropertyInfo2Repository hotelPropertyInfoRepository = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelInfoService"/> class.
        /// </summary>
        /// <param name="hotelPropertyInfo">The hotel property info.</param>
        public HotelInfoService(iPow.Domain.Repository.IHotelPropertyInfo2Repository hotelPropertyInfo)
        {
            if (hotelPropertyInfo == null)
            {
                throw new ArgumentNullException("hotelPropertyInfoRepository is null");
            }
            hotelPropertyInfoRepository = hotelPropertyInfo;
        }

        /// <summary>
        /// Gets the hot hotel.
        /// 得到热门的酒店信息
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public IQueryable<Dto.HotelInfoDto> GetHotHotel(int take)
        {
            IQueryable<Dto.HotelInfoDto> temp = null;
            temp = (from e in hotelPropertyInfoRepository.GetList()
                    orderby e.VisitCount descending
                    select new Dto.HotelInfoDto
                    {
                        Id = e.ID,
                        HotelId = e.HotelID,
                        Address = e.Address,
                        MinPrice = e.MinPrice,
                        Name = e.HotelName
                    }).Take(take).AsQueryable();
            return temp;
        }
    }
}