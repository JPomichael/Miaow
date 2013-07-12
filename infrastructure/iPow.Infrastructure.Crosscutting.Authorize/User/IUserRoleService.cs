using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public interface IUserRoleService
    {
        bool Add(iPow.Infrastructure.Data.DataSys.Sys_UserRoles entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Add(IList<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(iPow.Infrastructure.Data.DataSys.Sys_UserRoles entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_UserRoles entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<int> idList, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(iPow.Infrastructure.Data.DataSys.Sys_UserRoles entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(IList<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        iPow.Infrastructure.Data.DataSys.Sys_UserRoles Get(int id);

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> GetList();

        IQueryable<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> GetUserRoleListByUserId(int userId);

        iPow.Infrastructure.Data.DataSys.Sys_UserRoles GetUserRoleSingleById(int userRoleId);

        iPow.Infrastructure.Data.DataSys.Sys_AdminUser GetUserSingleById(int UserId);

        iPow.Infrastructure.Data.DataSys.Sys_UserRoles GetUserTypeSingleById(int UserId);

        bool UserHasUserRole(int userId, int roleId);

        iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto GetUserRoleSingDto(int userRoleId);

        IQueryable<iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto> GetUserRoleDtoList();
    }
}
