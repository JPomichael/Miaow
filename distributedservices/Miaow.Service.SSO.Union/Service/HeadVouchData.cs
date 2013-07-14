using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using iPow.DataSys;

namespace iPow.Union.Bll
{
    public class HeadVouchData
    {

        /// <summary>
        /// 数据库操作类
        /// </summary>
        private static readonly ipowsysEntities db = new ipowsysEntities(ConfigurationManager.ConnectionStrings["ipowsysEntities"].ConnectionString);

        /// <summary>
        /// Gets the name of the vouch sight list by city.
        /// 传入一个城市
        /// 取到城市里面热门景区
        /// 前 take 条
        /// </summary>
        /// <param name="city">The city.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public static IQueryable<iPow.Union.Models.HeadVouchSightInfoModel> GetVouchSightByCityName(string city, int take)
        {
            IQueryable<iPow.Union.Models.HeadVouchSightInfoModel> si = null;
            si = db.Sys_SightInfo.Where(e => city.Contains(e.City))
                .OrderByDescending(e => e.ViCount)
                .Select(e => new iPow.Union.Models.HeadVouchSightInfoModel
                {
                    City = e.City,
                    Id = e.ParkID,
                    Province = e.Province,
                    Py = e.PY,
                    Title = e.Title,
                    Lat = e.Latitude,
                    Lon = e.Longitude
                }).Take(take);

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
        public static IQueryable<iPow.Union.Models.HotelLeftSightInfoModel> GetLeftHotSightInfoByProvince(string prov, int take)
        {
            IQueryable<iPow.Union.Models.HotelLeftSightInfoModel> si = null;
            if (!string.IsNullOrEmpty(prov))
            {
                si = db.Sys_SightInfo.Where(e => e.Province.Contains(prov))
                    .OrderByDescending(e => e.ViCount)
                    .Select(e => new iPow.Union.Models.HotelLeftSightInfoModel
                    {
                        Id = e.ParkID,
                        Name = e.Title,
                        Py = e.PY,
                        City = e.City,
                        Lat = e.Latitude,
                        Lon = e.Longitude
                    }).Take(take);
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
        public static IQueryable<iPow.Union.Models.HotelLeftSightInfoModel> GetLeftHotSightInfoByCity(string city, int take)
        {
            IQueryable<iPow.Union.Models.HotelLeftSightInfoModel> si = null;
            if (!string.IsNullOrEmpty(city))
            {
                si = db.Sys_SightInfo.Where(e => e.City.Contains(city))
                    .OrderByDescending(e => e.ViCount)
                    .Select(e => new iPow.Union.Models.HotelLeftSightInfoModel
                    {
                        Id = e.ParkID,
                        Name = e.Title,
                        Py = e.PY
                    }).Take(take);

            }
            return si;
        }

        /// <summary>
        /// Gets the hotel links.
        /// 得到酒店页面上的友情链接
        /// </summary>
        /// <returns></returns>
        public static IQueryable<iPow.Union.Models.HotelBottomLinkModel> GetHotelBottomLinks()
        {
            IQueryable<iPow.Union.Models.HotelBottomLinkModel> hl = null;
            hl = db.Sys_LinksInfo.Where(e => e.ClassID == 4).Select(
                e => new iPow.Union.Models.HotelBottomLinkModel
                {
                    Title = e.Title,
                    Url = e.WebUrl
                });
            return hl;
        }
    }
}
