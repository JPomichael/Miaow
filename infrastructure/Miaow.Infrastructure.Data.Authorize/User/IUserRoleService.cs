using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miaow.Infrastructure.Crosscutting.Authorize
{
    public interface IUserRoleService
    {
        bool Add(Miaow.Infrastructure.Data.DataSys.Sys_UserRoles entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Add(IList<Miaow.Infrastructure.Data.DataSys.Sys_UserRoles> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(Miaow.Infrastructure.Data.DataSys.Sys_UserRoles entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<Miaow.Infrastructure.Data.DataSys.Sys_UserRoles> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Delete(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(Miaow.Infrastructure.Data.DataSys.Sys_UserRoles entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<Miaow.Infrastructure.Data.DataSys.Sys_UserRoles> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool DeleteTrue(IList<int> idList, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(Miaow.Infrastructure.Data.DataSys.Sys_UserRoles entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        bool Modify(IList<Miaow.Infrastructure.Data.DataSys.Sys_UserRoles> entity, Miaow.Infrastructure.Data.DataSys.Sys_AdminUser operUser);

        Miaow.Infrastructure.Data.DataSys.Sys_UserRoles Get(int id);

        IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_UserRoles> GetList();

        IQueryable<Miaow.Infrastructure.Data.DataSys.Sys_UserRoles> GetUserRoleListByUserId(int userId);

        Miaow.Infrastructure.Data.DataSys.Sys_UserRoles GetUserRoleSingleById(int userRoleId);

        Miaow.Infrastructure.Data.DataSys.Sys_AdminUser GetUserSingleById(int UserId);

        Miaow.Infrastructure.Data.DataSys.Sys_UserRoles GetUserTypeSingleById(int UserId);

        bool UserHasUserRole(int userId, int roleId);

        Miaow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto GetUserRoleSingDto(int userRoleId);

        IQueryable<Miaow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto> GetUserRoleDtoList();
    }
}
