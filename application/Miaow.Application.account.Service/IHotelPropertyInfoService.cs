using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Application.account.Service
{
    public interface IHotelPropertyInfoService
    {
        Miaow.Domain.Dto.Sys_HotelPropertyInfoDto GetHotelInfoByID(int Id);
    }
}
