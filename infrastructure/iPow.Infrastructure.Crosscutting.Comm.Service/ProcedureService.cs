using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Comm.Service
{
    public class ProcedureService
    {
        /// <summary>
        /// Gets the search model.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        public static IQueryable<iPow.Infrastructure.Data.DataSys.Sys_SightInfo> GetSearchModel(string str)
        {
            return UtilityService.db.Sys_SightInfoSearch(str).AsQueryable();
        }

        /// <summary>
        /// Users the change PWD by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="pwd">The PWD.</param>
        /// <returns></returns>
        public static int UserChangePwdById(int id, string pwd)
        {
            return UtilityService.db.Sys_UpdatePassword(id, pwd);
        }
    }
}
