using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public class UserRoleService : IUserRoleService
    {
        iPow.Domain.Repository.IUserRoleRepository userRoleRepository;

        iPow.Domain.Repository.IAdminUserRepository adminUserRepository;

        iPow.Domain.Repository.IRolesRepository rolesRepository;

        public UserRoleService(iPow.Domain.Repository.IUserRoleRepository userRole,
            iPow.Domain.Repository.IAdminUserRepository adminUser,
             iPow.Domain.Repository.IRolesRepository roles)
        {
            if (userRole == null)
            {
                throw new ArgumentNullException("userRoleRepository is null");
            }
            if (adminUser == null)
            {
                throw new ArgumentNullException("adminUserRepository is null");
            }
            if (roles == null)
            {
                throw new ArgumentNullException("rolesRepository is null");

            }
            userRoleRepository = userRole;
            adminUserRepository = adminUser;
            rolesRepository = roles;
        }

        public void Add(iPow.Infrastructure.Data.DataSys.Sys_UserRoles userRole)
        {
            userRoleRepository.Add(userRole);
            userRoleRepository.Uow.Commit();
        }

        public void Delete(iPow.Infrastructure.Data.DataSys.Sys_UserRoles userRole)
        {
            userRoleRepository.Delete(userRole);
            userRoleRepository.Uow.Commit();
        }

        public bool Delete(List<string> userRoleIdList)
        {
            var idList = new List<int>();
            foreach (var item in userRoleIdList)
            {
                var id = -1;
                int.TryParse(item, out id);
                if (id > 0)
                {
                    idList.Add(id);
                }
            }
            return Delete(idList);
        }

        public bool Delete(List<int> userRoleIdList)
        {
            var data = userRoleRepository.GetList(e => userRoleIdList.Contains(e.Id));
            foreach (var item in data)
            {
                userRoleRepository.Delete(item);
            }
            var res = false;
            try
            {
                userRoleRepository.Uow.Commit();
                res = true;
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public void Modify(iPow.Infrastructure.Data.DataSys.Sys_UserRoles userRole)
        {
            userRoleRepository.Modify(userRole);
            userRoleRepository.Uow.Commit();
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> GetUserRoleListByUserId(int userId)
        {
            var userRoleList = userRoleRepository.GetList(d => d.UserID == userId).AsQueryable();
            return userRoleList;
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> GetList()
        {
            var res = userRoleRepository.GetList().AsQueryable();
            return res;
        }


        public IQueryable<iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto> GetUserRoleDtoList()
        {
            var res = userRoleRepository.GetList().Select(e => new iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto()
                {
                    Id = e.Id,
                    RoleID = e.RoleID,
                    UserID = e.UserID,
                    UserName = adminUserRepository.GetList(d => d.id == e.UserID).FirstOrDefault() != null ?
                    adminUserRepository.GetList(d => d.id == e.UserID).FirstOrDefault().username : "暂无昵称",
                    RoleName = rolesRepository.GetList(r => r.RoleID == e.RoleID).FirstOrDefault() != null ?
                     rolesRepository.GetList(r => r.RoleID == e.RoleID).FirstOrDefault().Description : "暂无角色"
                }).AsQueryable();
            return res;
        }

        /// <summary>
        /// 用于Add userrole 前的 存在与否判断
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool UserHasUserRole(int userId, int roleId)
        {
            var res = userRoleRepository.GetList(e => e.RoleID == roleId && e.UserID == userId).Any();
            return res;
        }

        /// <summary>
        /// 用于Edit 是显示数据
        /// </summary>
        /// <param name="userRoleId"></param>
        /// <returns></returns>
        public iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto GetUserRoleSingDto(int userRoleId)
        {
            var res = userRoleRepository.GetList(e => e.Id == userRoleId).Select(e =>
               new iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto()
           {
               Id = e.Id,
               RoleID = e.RoleID,
               UserID = e.UserID,
               UserName = adminUserRepository.GetList(d => d.id == e.UserID).FirstOrDefault() != null ?
               adminUserRepository.GetList(d => d.id == e.UserID).FirstOrDefault().username : "暂无昵称",
               RoleName = rolesRepository.GetList(r => r.RoleID == e.RoleID).FirstOrDefault() != null ?
               rolesRepository.GetList(r => r.RoleID == e.RoleID).FirstOrDefault().Description : "暂无角色"
           }).FirstOrDefault(); //单个
            return res;
        }

        public iPow.Infrastructure.Data.DataSys.Sys_UserRoles GetUserRoleSingleById(int userRoleId)
        {
            var res = userRoleRepository.GetList(e => e.Id == userRoleId).FirstOrDefault();
            return res;
        }
        //要显示用户Name 所以根据UserId 查询
        public iPow.Infrastructure.Data.DataSys.Sys_AdminUser GetUserSingleById(int UserId)
        {
            var res = adminUserRepository.GetList(e => e.id == UserId).FirstOrDefault();
            return res;
        }
        //用于登陆判断用户的类型来显示不同页面
        public iPow.Infrastructure.Data.DataSys.Sys_UserRoles GetUserTypeSingleById(int UserId)
        {
            var res = userRoleRepository.GetList(e => e.UserID == UserId).FirstOrDefault();
            return res;
        }






    }
}
