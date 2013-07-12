using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPow.Infrastructure.Crosscutting.Authorize;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public class PermissionAuthorizeService
    {
        IUserRoleService userRoleService;

        IMvcRolePermissionService rolePermissionService;

        IMvcActionService actionService;

        public PermissionAuthorizeService(IUserRoleService userRole,
            IMvcRolePermissionService rolePermission,
            IMvcActionService action)
        {
            if (userRole == null)
            {
                throw new ArgumentNullException("userRoleService is null");
            }
            if (rolePermission == null)
            {
                throw new ArgumentNullException("rolePermissionService is null");
            }
            if (action == null)
            {
                throw new ArgumentNullException("actionService is null");
            }
            userRoleService = userRole;
            rolePermissionService = rolePermission;
            actionService = action;
        }

        public bool UserHasPremission(iPow.Domain.Dto.Sys_AdminUserDto user, Type controller, string action)
        {
            var res = false;
            //找到用户的所有角色Id
            var userRoleList = userRoleService.GetUserRoleListByUserId(user.id);
            foreach (var userRole in userRoleList)
            {
                var userRoleId = userRole.RoleID;
                //找到每个角色Id的所有能访问的action id list
                var rolePermissionActionIdList = rolePermissionService.GetRolePermissionByRoleId(userRole.RoleID).Select(d => d.ActionId);
                //根据action id list 找到 action 表的权限列表
                var actionList = actionService.GetList(rolePermissionActionIdList);
                foreach (var item in actionList)
                {
                    //对比
                    if (string.Compare(item.Name, action, false) == 0)
                    {
                        res = true;
                    }
                }
            }
            return res;
        }
    }
}