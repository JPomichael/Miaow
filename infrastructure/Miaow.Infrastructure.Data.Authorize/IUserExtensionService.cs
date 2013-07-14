using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public interface IUserExtensionService
    {
        iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension Add(
            iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension userExtension,
            iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension userExtension,
            iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension userExtension,
            iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension userExtension,
            iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension Get(int id);

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_AdminUserExtension> GetList();

        bool ExistUserByQQId(string qqId);

        bool ExistUserBySinaId(string sinaId);
    }
}
