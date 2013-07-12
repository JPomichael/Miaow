using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Comm.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class SightInfoSearchService : ISightInfoSearchService
    {
        /// <summary>
        /// Gets the search model.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_SightInfo> GetSearchModel(string str)
        {
            return ProcedureService.GetSearchModel(str);
        }
    }
}
