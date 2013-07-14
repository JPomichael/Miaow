using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webdiyer.WebControls.Mvc;

namespace Miaow.Application.account.Service
{
    public interface IHotelInfoService
    {
        /// <summary>
        /// 获得所有的HOtal  By City
        /// </summary>
        /// <param name="city"></param>
        /// <param name="pi"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        PagedList<Miaow.Domain.Dto.Sys_HotelPropertyInfoDto> GetAllHotelByCity(string city, int pi, int take);

        Miaow.Domain.Dto.Sys_HotelPropertyInfoDto GetHotelByID(int ID);

        Miaow.Domain.Dto.Sys_HotelPropertyInfoDto GetHotelLonAndLatByName(string Name);

    }
}
