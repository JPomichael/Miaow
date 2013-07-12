using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPow.Application.jq.Dto;

namespace iPow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAddSortService
    {
        /// <summary>
        /// Adds the sort base.
        /// </summary>
        /// <param name="sourceInfo">The source info.</param>
        /// <param name="tar">The tar.</param>
        /// <param name="num">The num.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        void AddSortBase(List<DefaultSightInfoDto> sourceInfo,DefaultSightInfoDto tar, int num, int pageIndex, int pageSize);

        /// <summary>
        /// Adds the sort sight info by city.
        /// </summary>
        /// <param name="sourceInfo">The source info.</param>
        /// <param name="city">The city.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        int AddSortSightInfoByCity(List<DefaultSightInfoDto> sourceInfo, string city, int pageIndex, int pageSize);

        /// <summary>
        /// Adds the sort sight info by global.
        /// </summary>
        /// <param name="sourceInfo">The source info.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        int AddSortSightInfoByGlobal(List<DefaultSightInfoDto> sourceInfo, int pageIndex, int pageSize);

        /// <summary>
        /// Adds the sort sight info by province.
        /// </summary>
        /// <param name="sourceInfo">The source info.</param>
        /// <param name="aim">The aim.</param>
        /// <param name="prov">The prov.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        int AddSortSightInfoByProvince(List<DefaultSightInfoDto> sourceInfo, string prov, int pageIndex, int pageSize);

        /// <summary>
        /// Selects the sight info.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <returns></returns>
        IEnumerable<DefaultSightInfoDto> SelectSightInfo(IEnumerable<iPow.Infrastructure.Data.DataSys.Sys_SightInfo> info);
    }
}
