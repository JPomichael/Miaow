using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Miaow.Application.jq.Dto;

namespace Miaow.Application.jq.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISearchService
    {
        /// <summary>
        /// Adds the sort sight info by global.
        /// </summary>
        /// <param name="sourceInfo">The source info.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">Size of the page.</param>
        /// <returns></returns>
        List<DefaultSightInfoDto> AddSortSightInfoByGlobal(List<Miaow.Infrastructure.Data.DataSys.Sys_SightInfo> sourceInfo, int pi, int take);

        /// <summary>
        /// Gets the search model.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <param name="pi">Index of the page.</param>
        /// <param name="take">Size of the page.</param>
        /// <returns></returns>
        SearchInfoDto GetSearchModel(string str, int? pi, int? take);
    }
}
