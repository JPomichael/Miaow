using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Miaow.Infrastructure.Crosscutting.Comm.Dto;

namespace Miaow.Infrastructure.Crosscutting.Comm.Service
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
        List<Miaow.Domain.Dto.Sys_CityInfoDto> GetCityInfoByName(LocationInfoDto li, string province, string city);

        /// <summary>
        /// Gets the city info by pin ying.
        /// </summary>
        /// <param name="ci">The ci.</param>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        List<Miaow.Domain.Dto.Sys_CityInfoDto> GetCityInfoByPinYing(Miaow.Domain.Dto.Sys_CityInfoDto ci, string province, string city);

        /// <summary>
        /// Gets the city info by sina.
        /// </summary>
        /// <param name="li">The li.</param>
        /// <returns></returns>
        Miaow.Domain.Dto.Sys_CityInfoDto GetCityInfoBySina(LocationInfoDto li);

        /// <summary>
        /// Gets the name of the city info single by.
        /// </summary>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        Miaow.Domain.Dto.Sys_CityInfoDto GetCityInfoSingleByName(string province, string city);

        ///// <summary>
        ///// Gets the city info single by pin ying.
        ///// </summary>
        ///// <param name="province">The province.</param>
        ///// <param name="city">The city.</param>
        ///// <returns></returns>
        //Miaow.Domain.Dto.Sys_CityInfoDto GetCityInfoSingleByPinYing(string province, string city);

        /// <summary>
        /// Gets the single city info.
        /// </summary>
        /// <param name="province">The province.</param>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        Miaow.Domain.Dto.Sys_CityInfoDto GetSingleCityInfo(string province, string city);

        //根据城市拼音查取中文
        Miaow.Domain.Dto.Sys_CityInfoDto GetCityByPinYin(string city);

        // select city by pinyin
        Miaow.Domain.Dto.Sys_CityInfoDto GetCityInfoSingleByName(string city);

        // 查询所有城市
        IEnumerable<Miaow.Domain.Dto.Sys_CityInfoDto> GetAllSysCityInfo();

        //GetAll
        IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_CityInfo> GetList();

        // exist 
        bool CityIsExistByName(string city);

        Miaow.Domain.Dto.Sys_CityInfoDto GetCityByName(string province, string city);

    }
}
