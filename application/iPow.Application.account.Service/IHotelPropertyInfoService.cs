using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Application.account.Service
{
    public interface IHotelPropertyInfoService
    {
        iPow.Domain.Dto.Sys_HotelPropertyInfoDto GetHotelInfoByID(int Id);
    }
}
