using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Miaow.Infrastructure.Crosscutting.EntityToDto;

namespace Miaow.Application.account.Service
{
    public class HotelPropertyInfoService : IHotelPropertyInfoService
    {
        Miaow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfoRepository;

        public HotelPropertyInfoService(Miaow.Domain.Repository.IHotelPropertyInfoRepository hotelProperty)
        {
            if (hotelProperty == null)
            {
                throw new ArgumentNullException("hotelPropertyInfoRepository is null");
            }
            hotelPropertyInfoRepository = hotelProperty;
        }

        public Miaow.Domain.Dto.Sys_HotelPropertyInfoDto GetHotelInfoByID(int Id)
        {
            var res = hotelPropertyInfoRepository.GetList(e => e.HotelID == Id).First();
            return res.ToDto();
        }
    }
}
