using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public interface IMvcControllerClassService
    {
        void Add(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass type);

        void Delete(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass type);

        void Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass type);

        iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass GetClassModelById(int id);

        bool Delete(List<string> userIdList);

        bool Delete(List<int> userIdList);

        /// <summary>
        /// 检查是否已经存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        bool NameAndRemarkHasClass(string name, string remark);

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerClass> GetList();



    }
}
