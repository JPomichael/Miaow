using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Webdiyer.WebControls.Mvc;
using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Application.account.Service
{
    public class HotelInfoService : IHotelInfoService
    {
        /// <summary>
        /// 
        /// </summary>
        iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfoRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotelPropertyInfo"></param>
        public HotelInfoService(iPow.Domain.Repository.IHotelPropertyInfoRepository hotelPropertyInfo)
        {

            if (hotelPropertyInfo == null)
            {
                throw new ArgumentNullException("hotelPropertyInfoRepository is null");
            }
            hotelPropertyInfoRepository = hotelPropertyInfo;
        }

        /// <summary>
        /// 获得所有的Hotal By City + 分页
        /// </summary>
        /// <param name="city"></param>
        /// <param name="pi"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public PagedList<iPow.Domain.Dto.Sys_HotelPropertyInfoDto> GetAllHotelByCity(string city, int pi, int take)
        {
            var res = hotelPropertyInfoRepository.GetList(d => d.City == city)
                .OrderByDescending(e => e.VisitCount).AsEnumerable();
            int total = res.Count();
            //if (res.Count() < 15)
            //    pi = pi - 1;
            //pi = (pi - 1) > 0 ? (pi - 1) : 0;
            res = res.Skip(((pi - 1) > 0 ? (pi - 1) : 0) * take).Take(take);
            var temp = new Webdiyer.WebControls.Mvc.PagedList<iPow.Domain.Dto.Sys_HotelPropertyInfoDto>(res.ToDto(), pi, take, total);
            return temp;
        }

        /// <summary>
        /// 根绝ID获得酒店信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_HotelPropertyInfoDto GetHotelByID(int ID)
        {
            var res = hotelPropertyInfoRepository.GetList(e => e.HotelID == ID).FirstOrDefault();
            return res.ToDto();
        }

        /// <summary>
        /// 获得酒店信息  By Name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_HotelPropertyInfoDto GetHotelLonAndLatByName(string Name)
        {
            var res = hotelPropertyInfoRepository.GetList(e => e.HotelName == Name).FirstOrDefault();
            return res.ToDto();
        }
    }
}
