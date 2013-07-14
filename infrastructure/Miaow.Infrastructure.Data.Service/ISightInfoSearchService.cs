using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Crosscutting.Comm.Service
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
        IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_SightInfo> GetSearchModel(string str);
    }
}
