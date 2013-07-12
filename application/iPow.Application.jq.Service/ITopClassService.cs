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
    public interface ITopClassService
    {
        /// <summary>
        /// Adds the global to top class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        List<TopClassDto> AddGlobalToTopClass(List<TopClassDto> source);

        /// <summary>
        /// Gets the top class by sight.
        /// </summary>
        /// <param name="si">The si.</param>
        /// <returns></returns>
        List<TopClassDto> GetTopClassBySight(IEnumerable< iPow.Infrastructure.Data.DataSys.Sys_SightInfo> si);

        /// <summary>
        /// Updates the top class two.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="tar">The tar.</param>
        /// <returns></returns>
        List<TopClassDto> UpdateTopClassTwo(List<TopClassDto> source, IEnumerable<TopClassDto> tar);
    }
}
