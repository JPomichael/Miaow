using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Application.account.Service
{
    public class HotelPropertyInfoService : IHotelPropertyInfoService
    {
        iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfoRepository;

        public HotelPropertyInfoService(iPow.Domain.Repository.IHotelPropertyInfoRepository hotelProperty)
        {
            if (hotelProperty == null)
            {
                throw new ArgumentNullException("hotelPropertyInfoRepository is null");
            }
            hotelPropertyInfoRepository = hotelProperty;
        }

        public iPow.Domain.Dto.Sys_HotelPropertyInfoDto GetHotelInfoByID(int Id)
        {
            var res = hotelPropertyInfoRepository.GetList(e => e.HotelID == Id).First();
            return res.ToDto();
        }
    }
}
