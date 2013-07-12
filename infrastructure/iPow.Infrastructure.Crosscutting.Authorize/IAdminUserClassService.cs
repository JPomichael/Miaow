using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
   public interface IAdminUserClassService
    {
       void Add(iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass adminUserClass, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

       void Delete(iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass adminUserClass);

       bool Delete(List<int> userIdList);

       bool Delete(List<string> userIdList);

       bool NameHasClass(string name);

       void Modify(iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass adminUserClass, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

       IQueryable<iPow.Infrastructure.Data.DataSys.Sys_AdminUserClass> GetList();

      
    }
}
