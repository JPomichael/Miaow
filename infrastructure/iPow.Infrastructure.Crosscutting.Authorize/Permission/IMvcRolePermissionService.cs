using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public interface IMvcRolePermissionService
    {
        bool Add(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Add(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> entity,iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission Get(int Id);

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> GetList();

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> GetRolePermissionByRoleId(int roleId);

        List<iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcActionDto> GetAllPermissionFromDb();

    }
}
