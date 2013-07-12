using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Infrastructure.Data.DataSys;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public partial class UserService
    {
        #region delete

        public bool Delete(Sys_AdminUser entity, Sys_AdminUser operUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IList<Sys_AdminUser> entity, Sys_AdminUser operUser)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IList<int> idList, Sys_AdminUser operUser)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTrue(Sys_AdminUser entity, Sys_AdminUser operUser)
        {
            bool res = false;
            if (entity != null && entity.id > 0)
            {
                try
                {
                    //要删除角色
                    var userRoles = userRoleRepository.GetList(d => d.UserID == entity.id);
                    foreach (var item in userRoles)
                    {
                        userRoleRepository.Delete(item);
                    }
                    adminUserRepository.Delete(entity);
                    //用户扩展信息
                    var userExtension = adminUserExtensionRepository.GetList(d => d.UserId == entity.id);
                    foreach (var item in userExtension)
                    {
                        adminUserExtensionRepository.Delete(item);
                    }
                    //个性化设置内容
                    var userIndividu = adminUserIndividuationRepository.GetList(d => d.UserId == entity.id);
                    foreach (var item in userIndividu)
                    {
                        adminUserIndividuationRepository.Delete(item);
                    }
                    adminUserRepository.Uow.Commit();
                    userRoleRepository.Uow.Commit();
                    adminUserExtensionRepository.Uow.Commit();
                    adminUserIndividuationRepository.Uow.Commit();
                    //rolePermissionRepository.这是角色权限

                    var log = new Sys_AdminUserLog();
                    log.AddTime = System.DateTime.Now;
                    log.IpAddress = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                    log.PageUrl = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl();
                    log.ReferrerUrl = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl();
                    log.State = true;
                    log.TypeId = 1;
                    if (operUser != null)
                    {
                        log.UserId = operUser.id;
                        log.ShortMessage = "用户Id：" + operUser.id + " 物理删除用户Id号：" + entity.id.ToString();
                        log.FullMessage = "DeleteUserTrue 用户：" + operUser.username + " 用户Id：" + operUser.id.ToString()
                            + " 删除用户Id号：" + entity.id.ToString();
                    }
                    else
                    {
                        log.UserId = 0;
                        log.ShortMessage = "用户Id号：" + entity.id.ToString() + " 被删除";
                        log.FullMessage = "DeleteUserTrue " + "用户Id号：" + entity.id.ToString() + " 被删除";
                    }
                    iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(log);
                    res = true;
                }
                catch (Exception ex)
                { }
            }
            return res;
        }

        public bool DeleteTrue(IList<Sys_AdminUser> entity, Sys_AdminUser operUser)
        {
            bool res = false;
            if (entity != null && entity.Count > 0)
            {
                foreach (var item in entity)
                {
                    try
                    {
                        //删除自己
                        adminUserRepository.Delete(item);
                        //用户扩展信息
                        var userExtension = adminUserExtensionRepository.GetList(d => d.UserId == item.id);
                        foreach (var temp in userExtension)
                        {
                            adminUserExtensionRepository.Delete(temp);
                        }
                        //个性化设置内容
                        var userIndividu = adminUserIndividuationRepository.GetList(d => d.UserId == item.id);
                        foreach (var temp in userIndividu)
                        {
                            adminUserIndividuationRepository.Delete(temp);
                        }
                        //要删除角色
                        var userRoles = userRoleRepository.GetList(d => d.UserID == item.id);
                        foreach (var temp in userRoles)
                        {
                            userRoleRepository.Delete(temp);
                        }
                        adminUserRepository.Uow.Commit();
                        adminUserExtensionRepository.Uow.Commit();
                        adminUserIndividuationRepository.Uow.Commit();
                        userRoleRepository.Uow.Commit();
                        //rolePermissionRepository.这是角色权限
                        var log = new Sys_AdminUserLog();
                        log.AddTime = System.DateTime.Now;
                        log.IpAddress = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                        log.PageUrl = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl();
                        log.ReferrerUrl = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl();
                        log.State = true;
                        log.TypeId = 1;
                        if (operUser != null)
                        {
                            log.UserId = operUser.id;
                            log.ShortMessage = "用户Id：" + operUser.id + " 物理删除用户Id号：" + item.id.ToString();
                            log.FullMessage = "DeleteUserTrue 用户：" + operUser.username + " 用户Id：" + operUser.id.ToString()
                                + " 删除用户Id号：" + item.id.ToString();
                        }
                        else
                        {
                            log.UserId = 0;
                            log.ShortMessage = "用户Id号：" + item.id.ToString() + " 被删除";
                            log.FullMessage = "DeleteUserTrue " + "用户Id号：" + item.id.ToString() + " 被删除";
                        }
                        iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(log);
                        res = true;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return res;
        }

        public bool DeleteTrue(IList<int> idList, Sys_AdminUser operUser)
        {
            var res = false;
            if (idList != null && idList.Count > 0)
            {
                var delete = adminUserRepository.GetList(e => idList.Contains(e.id)).ToList();
                if (delete.Count > 0)
                {
                    res = DeleteTrue(delete, operUser);
                }
            }
            return res;
        }

        /// <summary>
        /// Deletes the user by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool DeleteById(int id, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            bool res = false;
            if (id > 0)
            {
                var user = GetUserById(id);
                if (user != null)
                {
                    res = Delete(user, operUser);
                }
            }
            return res;
        }

        /// <summary>
        /// Deletes the user true by id.
        /// 物理删除
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="operUser"></param>
        /// <returns></returns>
        public bool DeleteTrueById(int id, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (id > 0)
            {
                var user = GetUserById(id);
                if (user != null)
                {
                    res = DeleteTrue(user, operUser);
                }
            }
            return res;
        }

        /// <summary>
        /// Deletes the name of the user by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public bool DeleteByName(string name, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            bool res = false;
            if (!string.IsNullOrEmpty(name))
            {
                var user = GetUserByName(name);
                if (user != null)
                {
                    res = Delete(user, operUser);
                }
            }
            return res;
        }

        /// <summary>
        /// Deletes the name of the user true by.
        /// 物理删除
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="operUser">The oper user.</param>
        /// <returns></returns>
        public bool DeleteTrueByName(string name, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (!string.IsNullOrEmpty(name))
            {
                var user = GetUserByName(name);
                if (user != null)
                {
                    res = DeleteTrue(user, operUser);
                }
            }
            return res;
        }

        /// <summary>
        /// Deletes the name of the user by.
        /// 只设置为不可用
        /// </summary>
        /// <param name="email"></param>
        /// <param name="operUser">The oper user.</param>
        /// <returns></returns>
        public bool DeleteByEmail(string email, Sys_AdminUser operUser)
        {
            var res = false;
            if (!string.IsNullOrEmpty(email))
            {
                var user = GetUserByEmail(email);
                if (user != null)
                {
                    res = Delete(user, operUser);
                }
            }
            return res;
        }

        /// <summary>
        /// Deletes the name of the user true by.
        /// 物理删除
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="operUser">The oper user.</param>
        /// <returns></returns>
        public bool DeleteTrueByEmail(string email, Sys_AdminUser operUser)
        {
            var res = false;
            if (!string.IsNullOrEmpty(email))
            {
                if (!string.IsNullOrEmpty(email))
                {
                    var user = GetUserByEmail(email);
                    res = DeleteTrue(user, operUser);
                }
            }
            return res;
        }

        /// <summary>
        /// Deletes the name of the user by.
        /// 只设置为不可用
        /// </summary>
        /// <param name="guid">The GUID.</param>
        /// <param name="operUser">The oper user.</param>
        /// <returns></returns>
        public bool DeleteByUserGuid(string guid, Sys_AdminUser operUser)
        {
            var res = false;
            if (!string.IsNullOrEmpty(guid))
            {
                var user = GetUserByUserGuid(guid);
                if (user != null)
                {
                    res = Delete(user, operUser);
                }
            }
            return res;
        }

        /// <summary>
        /// Deletes the name of the user true by.
        /// 物理删除
        /// </summary>
        /// <param name="guid">The GUID.</param>
        /// <param name="operUser">The oper user.</param>
        /// <returns></returns>
        public bool DeleteTrueByUserGuid(string guid, Sys_AdminUser operUser)
        {
            var res = false;
            if (!string.IsNullOrEmpty(guid))
            {
                var user = GetUserByUserGuid(guid);
                if (user != null)
                {
                    res = DeleteTrue(user, operUser);
                }
            }
            return res;
        }

        #endregion
    }
}
