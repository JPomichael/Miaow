using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Infrastructure.Data.DataSys;
using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Service.Union.Service
{
    public class HotelCommSysService : IHotelCommSysService
    {
        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.IHotelCommRepository hotelCommRepository = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelCommSysService"/> class.
        /// </summary>
        /// <param name="hotelComm">The hotel comm.</param>
        public HotelCommSysService(iPow.Domain.Repository.IHotelCommRepository hotelComm)
        {
            hotelCommRepository = hotelComm;
        }

        /// <summary>
        /// Gets the hotel comm list.
        /// 酒店详细页
        /// 酒店评论列表
        /// 分页的哦
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="take">The take.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public List<iPow.Domain.Dto.Sys_HotelCommDto> GetHotelCommPageListByHotelId(int id, int pageIndex, int take, ref int total)
        {
            IQueryable<iPow.Infrastructure.Data.DataSys.Sys_HotelComm> hc = null;
            total = hotelCommRepository.GetList(e => e.HotelID == id).Count();
            hc = hotelCommRepository.GetList(e => e.HotelID == id)
                .OrderByDescending(e => e.AddTime)
                .Skip((pageIndex - 1 < 0 ? pageIndex : pageIndex - 1) * take)
                .Take(take).AsQueryable();
            return hc.ToDto().ToList();
        }
    }
}
