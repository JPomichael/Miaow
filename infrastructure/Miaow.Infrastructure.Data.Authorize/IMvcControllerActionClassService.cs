using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public interface IMvcControllerActionClassService
    {
        void Add(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass mvcControllerActionClassk, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        void Delete(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass mvcControllerActionClass);

        bool Delete(List<int> actionIdList);

        bool Delete(List<string> actionIdList);

        bool NameHasClass(string name);

        void Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass mvcControllerActionClass);

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerActionClass> GetList();
    }
}
