using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using iPow.Infrastructure.Crosscutting.Comm.Dto;

namespace iPow.Infrastructure.Crosscutting.Comm.Service
{
    public interface ICityInfoService
    {
        /// <summary>
        /// Gets the name of the city info by.
        /// </summary>
        /// <param name="li">The li.</param>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        List<iPow.Domain.Dto.Sys_CityInfoDto> GetCityInfoByName(LocationInfoDto li, string province, string city);

        /// <summary>
        /// Gets the city info by pin ying.
        /// </summary>
        /// <param name="ci">The ci.</param>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        List<iPow.Domain.Dto.Sys_CityInfoDto> GetCityInfoByPinYing(iPow.Domain.Dto.Sys_CityInfoDto ci, string province, string city);

        /// <summary>
        /// Gets the city info by sina.
        /// </summary>
        /// <param name="li">The li.</param>
        /// <returns></returns>
        iPow.Domain.Dto.Sys_CityInfoDto GetCityInfoBySina(LocationInfoDto li);

        /// <summary>
        /// Gets the name of the city info single by.
        /// </summary>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        iPow.Domain.Dto.Sys_CityInfoDto GetCityInfoSingleByName(string province, string city);

        ///// <summary>
        ///// Gets the city info single by pin ying.
        ///// </summary>
        ///// <param name="province">The province.</param>
        ///// <param name="city">The city.</param>
        ///// <returns></returns>
        //iPow.Domain.Dto.Sys_CityInfoDto GetCityInfoSingleByPinYing(string province, string city);

        /// <summary>
        /// Gets the single city info.
        /// </summary>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        iPow.Domain.Dto.Sys_CityInfoDto GetSingleCityInfo(string province, string city);

        //根据城市拼音查取中文
        iPow.Domain.Dto.Sys_CityInfoDto GetCityByPinYin(string city);

        // select city by pinyin
        iPow.Domain.Dto.Sys_CityInfoDto GetCityInfoSingleByName(string city);

        // 查询所有城市
        IEnumerable<iPow.Domain.Dto.Sys_CityInfoDto> GetAllSysCityInfo();

        //GetAll
        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_CityInfo> GetList();

        // exist 
        bool CityIsExistByName(string city);

        iPow.Domain.Dto.Sys_CityInfoDto GetCityByName(string province, string city);

    }
}
