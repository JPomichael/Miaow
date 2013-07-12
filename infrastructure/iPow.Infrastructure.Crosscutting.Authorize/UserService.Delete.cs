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

        /// <summary>
        /// Deletes the name of the user by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public bool DeleteByName(string name, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            bool b = false;
            var user = GetUserByName(name);
            b = Delete(user, operUser);
            return b;
        }

        /// <summary>
        /// Deletes the user by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public bool DeleteById(int id, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            bool b = false;
            var user = GetUserById(id);
            b = Delete(user, operUser);
            return b;
        }

        public bool DeleteTrue(iPow.Infrastructure.Data.DataSys.Sys_AdminUser user)
        {
            var res = false;
            try
            {
                adminUserRepository.Delete(user);
                adminUserRepository.Uow.Commit();
                res = true;
                //添加日志操作
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public bool Delete(IList<int> userIdList)
        {
            var data = adminUserRepository.GetList(e => userIdList.Contains(e.id));
            foreach (var item in data)
            {
                adminUserRepository.Delete(item);
            }
            var res = false;
            try
            {
                adminUserRepository.Uow.Commit();
                res = true;
            }
            catch (Exception ex)
            {
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
            var user = GetUserById(id);
            res = DeleteTrue(user, operUser);
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
            var user = GetUserByName(name);
            res = DeleteTrue(user, operUser);
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
            var b = false;
            if (ExistUserByEmail(email))
            {
                var user = GetUserByEmail(email);
                b = Delete(user, operUser);
            }
            return b;
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
            var b = false;
            if (!string.IsNullOrEmpty(email))
            {
                var user = GetUserByEmail(email);
                b = DeleteTrue(user, operUser);
            }
            return b;
        }



        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="operUser">The oper user.</param>
        /// <returns></returns>
        public bool Delete(Sys_AdminUser user, Sys_AdminUser operUser)
        {
            bool b = false;
            if (user != null && user.id > 0)
            {
                user.Activity = false;
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
                    log.ShortMessage = "用户Id：" + operUser.id.ToString() + " 非物理删除用户Id号：" + user.id.ToString();
                    log.FullMessage = "DeleteUser 用户名：" + operUser.username + " 用户Id：" + operUser.id.ToString()
                        + " 非物理删除用户Id号：" + user.id.ToString();
                }
                else
                {
                    log.UserId = 0;
                    log.ShortMessage = "用户Id：" + user.id.ToString() + " 被非物理删除";
                    log.FullMessage = "DeleteUser 用户名：" + user.username + " 用户Id：" + operUser.id.ToString()
                        + " 被非物理删除";
                }
                try
                {
                    adminUserRepository.Uow.Commit();
                    b = true;
                    iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(log);
                }
                catch (Exception ex)
                { }
            }
            return b;
        }

        /// <summary>
        /// Deletes the user true.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="operUser">The oper user.</param>
        /// <returns></returns>
        public bool DeleteTrue(Sys_AdminUser user, Sys_AdminUser operUser)
        {
            bool b = false;
            if (user != null && user.id > 0)
            {
                try
                {
                    //要删除角色
                    var userRoles = userRoleRepository.GetList(d => d.UserID == user.id);
                    foreach (var item in userRoles)
                    {
                        userRoleRepository.Delete(item);
                    }
                    adminUserRepository.Delete(user);
                    //用户扩展信息
                    var userExtension = adminUserExtensionRepository.GetList(d => d.UserId == user.id);
                    foreach (var item in userExtension)
                    {
                        adminUserExtensionRepository.Delete(item);
                    }
                    //个性化设置内容
                    var userIndividu = adminUserIndividuationRepository.GetList(d => d.UserId == user.id);
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
                        log.ShortMessage = "用户Id：" + operUser.id + " 物理删除用户Id号：" + user.id.ToString();
                        log.FullMessage = "DeleteUserTrue 用户：" + operUser.username + " 用户Id：" + operUser.id.ToString()
                            + " 删除用户Id号：" + user.id.ToString();
                    }
                    else
                    {
                        log.UserId = 0;
                        log.ShortMessage = "用户Id号：" + user.id.ToString() + " 被删除";
                        log.FullMessage = "DeleteUserTrue " + "用户Id号：" + user.id.ToString() + " 被删除";
                    }
                    iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(log);
                    b = true;
                }
                catch (Exception ex)
                { }
            }
            return b;
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
            var b = false;
            var user = adminUserRepository.GetList(d => d.UserGuid == guid).FirstOrDefault();
            b = Delete(user, operUser);
            return b;
        }

        /// <summary>
        /// Deletes the name of the user true by.
        /// 物理删除
        /// </summary>
        /// <param name="guid">The GUID.</param>
        /// <param name="operUser">The oper user.</param>
        /// <returns></returns>
        public bool DeleteTrueByGuid(string guid, Sys_AdminUser operUser)
        {
            var b = false;
            var user = adminUserRepository.GetList(d => d.UserGuid == guid).FirstOrDefault();
            b = DeleteTrue(user, operUser);
            return b;
        }
        public bool DeleteTrue(IList<int> userIdList)
        {
            var res = false;
            var delete = adminUserRepository.GetList(e => userIdList.Contains(e.id));
            foreach (var item in delete)
            {
                adminUserRepository.Delete(item);
            }
            try
            {
                adminUserRepository.Uow.Commit();
                res = true;
                //添加日志操作
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        #endregion

    }
}
