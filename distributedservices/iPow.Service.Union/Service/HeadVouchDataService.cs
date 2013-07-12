using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace iPow.Service.Union.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class HeadVouchDataService : IHeadVouchDataService
    {
        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.ISightInfoRepository sightInfoRepository = null;

        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.ILinkInfoRepository linkInfoRepository = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeadVouchDataService"/> class.
        /// </summary>
        public HeadVouchDataService(iPow.Domain.Repository.ISightInfoRepository sight, iPow.Domain.Repository.ILinkInfoRepository link)
        {
            if (sight == null)
            {
                throw new ArgumentNullException("sightinforepository is null");
            }
            if (link == null)
            {
                throw new ArgumentNullException("linkinforepository is null");
            }
            sightInfoRepository = sight;
            linkInfoRepository = link;
        }

        /// <summary>
        /// Gets the name of the vouch sight list by city.
        /// 传入一个城市
        /// 取到城市里面热门景区
        /// 前 take 条
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public IQueryable<iPow.Application.Union.Dto.HeadVouchSightInfoDto> GetVouchSightByCityName(string city, int take)
        {
            IQueryable<iPow.Application.Union.Dto.HeadVouchSightInfoDto> si = null;
            si =  sightInfoRepository.GetList(e => city.Contains(e.City))
                .OrderByDescending(e => e.ViCount)
                .Select(e => new iPow.Application.Union.Dto.HeadVouchSightInfoDto
                {
                    City = e.City,
                    Id = e.ParkID,
                    Province = e.Province,
                    Py = e.PY,
                    Title = e.Title,
                    Lat = e.Latitude,
                    Lon = e.Longitude
                }).Take(take).AsQueryable();
            return si;
        }

        /// <summary>
        /// Gets the hot sight info by province.
        /// 从一个省里面选取前take条数据
        /// 热门景区
        /// 主要用于首页左边的
        /// </summary>
        /// <param name="prov">The prov.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public IQueryable<iPow.Application.Union.Dto.HotelLeftSightInfoDto> GetLeftHotSightInfoByProvince(string prov, int take)
        {
            IQueryable<iPow.Application.Union.Dto.HotelLeftSightInfoDto> si = null;
            if (!string.IsNullOrEmpty(prov))
            {
                si =  sightInfoRepository.GetList(e => e.Province.Contains(prov))
                    .OrderByDescending(e => e.ViCount)
                    .Select(e => new iPow.Application.Union.Dto.HotelLeftSightInfoDto
                    {
                        Id = e.ParkID,
                        Name = e.Title,
                        Py = e.PY,
                        City = e.City,
                        Lat = e.Latitude,
                        Lon = e.Longitude
                    }).Take(take).AsQueryable();
            }
            return si;
        }

        /// <summary>
        /// Gets the hot sight info by city.
        /// 从一个市里面选取前take条数据
        /// 热门景区
        /// 主要用于首页左边的
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public IQueryable<iPow.Application.Union.Dto.HotelLeftSightInfoDto> GetLeftHotSightInfoByCity(string city, int take)
        {
            IQueryable<iPow.Application.Union.Dto.HotelLeftSightInfoDto> si = null;
            if (!string.IsNullOrEmpty(city))
            {
                si = sightInfoRepository.GetList(e => e.City.Contains(city))
                    .OrderByDescending(e => e.ViCount)
                    .Select(e => new iPow.Application.Union.Dto.HotelLeftSightInfoDto
                    {
                        Id = e.ParkID,
                        Name = e.Title,
                        Py = e.PY
                    }).Take(take).AsQueryable();

            }
            return si;
        }

        /// <summary>
        /// Gets the hotel links.
        /// 得到酒店页面上的友情链接
        /// </summary>
        /// <returns></returns>
        public IQueryable<iPow.Application.Union.Dto.HotelBottomLinkDto> GetHotelBottomLinks()
        {
            IQueryable<iPow.Application.Union.Dto.HotelBottomLinkDto> hl = null;
            hl = linkInfoRepository.GetList(e => e.ClassID == 4).Select(
                e => new iPow.Application.Union.Dto.HotelBottomLinkDto
                {
                    Title = e.Title,
                    Url = e.WebUrl
                }).AsQueryable();
            return hl;
        }
    }
}
