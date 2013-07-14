using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public interface IMvcRolePermissionService
    {
        void Add(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission per);

        void Delete(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission per);

        void Modify(iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission per);

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> GetList();

        /// <summary>
        /// Gets the role permission by role id.
        /// permission service used
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <returns></returns>
        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_MvcControllerRolePermission> GetRolePermissionByRoleId(int roleId);

        List<iPow.Infrastructure.Crosscutting.Authorize.Dto.MvcActionDto> GetAllPermissionFromDb();

    }
}
