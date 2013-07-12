using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Comm.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISightInfoSearchService
    {
        /// <summary>
        /// Gets the search model.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_SightInfo> GetSearchModel(string str);
    }
}
