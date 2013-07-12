using System;
using System.Collections.Generic;
using System.Linq;

using iPow.Domain.Dto;
using iPow.Infrastructure.Crosscutting.Comm.Dto;
using iPow.Infrastructure.Crosscutting.EntityToDto;

namespace iPow.Infrastructure.Crosscutting.Comm.Service
{
    public class CityInfoService : ICityInfoService
    {
        /// <summary>
        /// 
        /// </summary>
        private iPow.Domain.Repository.ICityInfoRepository cityInfoRepository = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="CityInfoService"/> class.
        /// </summary>
        public CityInfoService(iPow.Domain.Repository.ICityInfoRepository cityInfo)
        {
            if (cityInfo == null)
            {
                throw new ArgumentNullException("cityinforepository is null");
            }
            cityInfoRepository = cityInfo;
        }

        //Get All
        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_CityInfo> GetList()
        {
            var res = cityInfoRepository.GetList().AsQueryable();
            return res;
        }

        //查询所有城市名
        public IEnumerable<iPow.Domain.Dto.Sys_CityInfoDto> GetAllSysCityInfo()
        {
            var allcity = cityInfoRepository.GetList();
            return allcity.ToDto();
        }

        /// <summary>
        /// Gets the city info.
        /// 从数据库中选一个省或城市
        /// </summary>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_CityInfoDto GetCityInfoSingleByName(string province, string city)
        {
            var ci = (from e in cityInfoRepository.GetList()
                      where e.city == city && e.province == province
                      select e).FirstOrDefault();
            return ci.ToDto();
        }


        public iPow.Domain.Dto.Sys_CityInfoDto GetCityInfoSingleByName(string city)
        {
            var ci = (from e in cityInfoRepository.GetList()
                      where e.city == city
                      select e).FirstOrDefault();
            return ci.ToDto();
        }

        /// <summary>
        /// Gets the city info.
        /// 从数据库中选一个省或城市
        /// </summary>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_CityInfoDto GetCityByName(string province, string city)
        {
            iPow.Infrastructure.Data.DataSys.Sys_CityInfo ci = null;
            List<iPow.Infrastructure.Data.DataSys.Sys_CityInfo> tempCityInfo = null;
            if (!string.IsNullOrEmpty(province) && string.IsNullOrEmpty(city))
            {
                tempCityInfo = (from e in cityInfoRepository.GetList()
                                where e.ProvincePy == province
                                orderby e.id
                                select e).Distinct().ToList();
            }
            else if (string.IsNullOrEmpty(province) && !string.IsNullOrEmpty(city))
            {
                tempCityInfo = (from e in cityInfoRepository.GetList()
                                where e.pinyin == city
                                orderby e.id
                                select e).Distinct().ToList();
            }
            else
            {
                tempCityInfo = (from e in cityInfoRepository.GetList()
                                where e.ProvincePy == province && e.pinyin == city
                                orderby e.id
                                select e).Distinct().ToList();
            }

            if (tempCityInfo != null && tempCityInfo.Count > 0)
            {
                ci = tempCityInfo[0];
            }
            return ci.ToDto();
        }

        /// <summary>
        /// Gets the city info by sina.
        /// 从新浪IP得到，我们数据库里面的一个城市信息
        /// </summary>
        /// <param name="li">The li.</param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_CityInfoDto GetCityInfoBySina(LocationInfoDto li)
        {
            //edit by yjihrp 2011.8.16.13.2
            //modify:li.city == null ?"shenzhen":li.city
            var ci = cityInfoRepository.GetList().
                Where(e => e.city == (string.IsNullOrEmpty(li.City) ? "shenzhen" : li.City) && e.province == li.Province)
                .FirstOrDefault();
            return ci.ToDto();
        }

        /// <summary>
        /// Inits the city info.
        /// 根据名字中文名字找到当前传入省的所有城市
        /// 如果省为空则按市选
        /// 如果市为空则按省选 
        /// 两个为空则按当前IP地址选
        /// edit by yjihrp 2011.8.2.17.18
        /// </summary>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        public List<iPow.Domain.Dto.Sys_CityInfoDto> GetCityInfoByName(LocationInfoDto li, string province, string city)
        {
            IQueryable<iPow.Infrastructure.Data.DataSys.Sys_CityInfo> ci = null;
            //根据IP中的城市选出这个省的 其他城市哈在数据库中选哦
            if (string.IsNullOrEmpty(province) && string.IsNullOrEmpty(city))
            {
                ci = (from d in cityInfoRepository.GetList()
                      where d.province == li.Province && d.city != li.City
                      select d).AsQueryable();
            }
            //根据市选
            else if (string.IsNullOrEmpty(province) && !string.IsNullOrEmpty(city))
            {
                List<iPow.Infrastructure.Data.DataSys.Sys_CityInfo> c = (from e in cityInfoRepository.GetList()
                                                                         where e.city == city
                                                                         select e).Distinct().ToList();
                if (c != null)
                {
                    if (c.Count > 0)
                    {
                        ci = (from d in cityInfoRepository.GetList()
                              where d.city == c[0].city && c[0].province == d.province
                              select d).AsQueryable();
                    }
                }
                else
                {
                    ci = (from d in cityInfoRepository.GetList()
                          where d.city == city
                          select d).AsQueryable();
                }
            }
            //根据省选
            else if (!string.IsNullOrEmpty(province) && string.IsNullOrEmpty(city))
            {
                ci = (from d in cityInfoRepository.GetList()
                      where d.province == province
                      select d).AsQueryable();
            }
            //根据省市选
            else
            {
                ci = (from d in cityInfoRepository.GetList()
                      where d.province == province && d.city != city
                      select d).AsQueryable();
            }
            return ci.ToDto().ToList();
        }

        /// <summary>
        /// Inits the city info.
        /// 根据名字拼音找到当前省的所有城市
        /// 如果省为空则按市选
        /// 如果市为空则按省选 
        /// 两个为空则按当前IP地址选
        /// </summary>
        public List<iPow.Domain.Dto.Sys_CityInfoDto> GetCityInfoByPinYing(iPow.Domain.Dto.Sys_CityInfoDto ci, string province, string city)
        {
            IQueryable<iPow.Infrastructure.Data.DataSys.Sys_CityInfo> ciList = null;
            //根据IP中的城市选出这个省的 其他城市哈在数据库中选哦
            if (string.IsNullOrEmpty(province) && string.IsNullOrEmpty(city))
            {
                ciList = (from d in cityInfoRepository.GetList()
                          where d.ProvincePy == ci.ProvincePy && d.pinyin != ci.pinyin
                          select d).AsQueryable();
            }
            //根据市选
            else if (string.IsNullOrEmpty(province) && !string.IsNullOrEmpty(city))
            {
                ciList = (from d in cityInfoRepository.GetList()
                          where d.pinyin == city
                          select d).AsQueryable();
            }
            //根据省选
            else if (!string.IsNullOrEmpty(province) && string.IsNullOrEmpty(city))
            {
                ciList = (from d in cityInfoRepository.GetList()
                          where d.ProvincePy == province
                          select d).AsQueryable();
            }
            //根据省市选
            else
            {
                ciList = (from d in cityInfoRepository.GetList()
                          where d.ProvincePy == province && d.pinyin != city
                          select d).AsQueryable();
            }
            return ciList.ToDto().ToList();
        }

        /// <summary>
        /// Gets the city info.
        /// 从数据库中选一个省或城市
        /// </summary>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        public iPow.Domain.Dto.Sys_CityInfoDto GetSingleCityInfo(string province, string city)
        {
            iPow.Infrastructure.Data.DataSys.Sys_CityInfo ci = null;
            List<iPow.Infrastructure.Data.DataSys.Sys_CityInfo> tempCityInfo = null;
            if (!string.IsNullOrEmpty(province) && string.IsNullOrEmpty(city))
            {
                tempCityInfo = (from e in cityInfoRepository.GetList()
                                where e.ProvincePy == province
                                orderby e.id
                                select e).Distinct().ToList();
            }
            else if (string.IsNullOrEmpty(province) && !string.IsNullOrEmpty(city))
            {
                tempCityInfo = (from e in cityInfoRepository.GetList()
                                where e.pinyin == city
                                orderby e.id
                                select e).Distinct().ToList();
            }
            else
            {
                tempCityInfo = (from e in cityInfoRepository.GetList()
                                where e.ProvincePy == province && e.pinyin == city
                                orderby e.id
                                select e).Distinct().ToList();
            }
            if (tempCityInfo != null && tempCityInfo.Count > 0)
            {
                ci = tempCityInfo[0];
            }
            return ci.ToDto();
        }

        /// <summary>
        /// 检验输入的目的地是否合法或存在
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public bool CityIsExistByName(string city)
        {
            var res = cityInfoRepository.GetList(e => e.city == city).Where(e => e.city == city).Any();
            return res;
        }

        //根据城市拼音查取中文
        public iPow.Domain.Dto.Sys_CityInfoDto GetCityByPinYin(string city)
        {
            iPow.Infrastructure.Data.DataSys.Sys_CityInfo ci = null;
            List<iPow.Infrastructure.Data.DataSys.Sys_CityInfo> tempCityInfo = null;
            tempCityInfo = (from e in cityInfoRepository.GetList()
                            where e.pinyin == city
                            orderby e.id
                            select e).Distinct().ToList();
            if (tempCityInfo != null && tempCityInfo.Count > 0)
            {
                ci = tempCityInfo[0];
            }
            return ci.ToDto();
        }
    }
}