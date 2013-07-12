using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public interface IUserRoleService
    {
        void Add(iPow.Infrastructure.Data.DataSys.Sys_UserRoles userRole);

        void Delete(iPow.Infrastructure.Data.DataSys.Sys_UserRoles userRole);

        /// <summary>
        /// 下两Delete 方法用于 在用户角色面板删除List<UserRoleID> 
        /// </summary>
        /// <param name="userRoleIdList"></param>
        /// <returns></returns>
        bool Delete(List<int> userRoleIdList);

        bool Delete(List<string> userRoleIdList);

        void Modify(iPow.Infrastructure.Data.DataSys.Sys_UserRoles userRole);

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> GetList();

        /// <summary>
        /// Gets the user role list by user id.
        /// permission service used
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns></returns>
        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> GetUserRoleListByUserId(int userId);

        iPow.Infrastructure.Data.DataSys.Sys_UserRoles GetUserRoleSingleById(int userRoleId);

        iPow.Infrastructure.Data.DataSys.Sys_AdminUser GetUserSingleById(int UserId);

        iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto GetUserRoleSingDto(int userRoleId);

        iPow.Infrastructure.Data.DataSys.Sys_UserRoles GetUserTypeSingleById(int UserId);

        bool UserHasUserRole(int userId, int roleId);

        IQueryable<iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto> GetUserRoleDtoList();
    }
}
