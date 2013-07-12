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

        public bool Add(Data.DataSys.Sys_UserRoles entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    userRoleRepository.Add(entity);
                    userRoleRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Add(IList<Data.DataSys.Sys_UserRoles> entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                foreach (var item in entity)
                {
                    if (item != null)
                    {
                        userRoleRepository.Add(item);
                    }
                }
                userRoleRepository.Uow.Commit();
                res = true;
            }
            return res;
        }

        public bool Delete(Data.DataSys.Sys_UserRoles entity, Data.DataSys.Sys_AdminUser operUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IList<Data.DataSys.Sys_UserRoles> entity, Data.DataSys.Sys_AdminUser operUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IList<int> idList, Data.DataSys.Sys_AdminUser operUser)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTrue(Data.DataSys.Sys_UserRoles entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null)
            {
                try
                {
                    userRoleRepository.Delete(entity);
                    userRoleRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<Data.DataSys.Sys_UserRoles> entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                try
                {
                    foreach (var item in entity)
                    {
                        userRoleRepository.Delete(item);
                    }
                    userRoleRepository.Uow.Commit();
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<int> idList, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            var delete = userRoleRepository.GetList(e => idList.Contains(e.Id)).ToList();
            if (delete != null && delete.Count > 0)
            {
                res = DeleteTrue(delete, operUser);
            }
            return res;
        }

        public bool Modify(Data.DataSys.Sys_UserRoles entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Id > 0)
            {
                try
                {
                    userRoleRepository.Modify(entity);
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public bool Modify(IList<Data.DataSys.Sys_UserRoles> entity, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                try
                {
                    foreach (var item in entity)
                    {
                        userRoleRepository.Modify(item);
                    }
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        public Data.DataSys.Sys_UserRoles Get(int id)
        {
            var data = userRoleRepository.GetList(e => e.Id == id).FirstOrDefault();
            return data;
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> GetList()
        {
            var res = userRoleRepository.GetList().AsQueryable();
            return res;
        }

        public IQueryable<iPow.Infrastructure.Data.DataSys.Sys_UserRoles> GetUserRoleListByUserId(int userId)
        {
            var userRoleList = userRoleRepository.GetList(d => d.UserID == userId).AsQueryable();
            return userRoleList;
        }

        public IQueryable<iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto> GetUserRoleDtoList()
        {
            var res = (from userRole in userRoleRepository.GetList()
                       join user in adminUserRepository.GetList() on userRole.UserID equals user.id
                       join role in rolesRepository.GetList() on userRole.RoleID equals role.RoleID
                       select new iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto
                       {
                           Id = userRole.Id,
                           RoleID = userRole.RoleID,
                           RoleName = role.Description,
                           UserID = userRole.UserID,
                           UserName = user.username
                       });
            //userRoleRepository.GetList().Select(e => new iPow.Infrastructure.Crosscutting.Authorize.Dto.UserRoleDto()
            //{
            //    Id = e.Id,
            //    RoleID = e.RoleID,
            //    UserID = e.UserID,
            //    UserName = adminUserRepository.GetList().Where(d => d.id == e.UserID).FirstOrDefault() != null ?
            //    adminUserRepository.GetList().Where(d => d.id == e.UserID).FirstOrDefault().username : "暂无昵称",
            //    //adminUserRepository.GetList(d => d.id == e.UserID).FirstOrDefault() != null ?
            //    //adminUserRepository.GetList(d => d.id == e.UserID).FirstOrDefault().username : "暂无昵称",
            //    RoleName = rolesRepository.GetList().Where(r => r.RoleID == e.RoleID).FirstOrDefault() != null ?
            //    rolesRepository.GetList().Where(r => r.RoleID == e.RoleID).FirstOrDefault().Description : "暂无角色"
            //}).AsQueryable();
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
            var data = GetUserRoleDtoList().FirstOrDefault();
            return data;
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
