using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Infrastructure.Data.DataSys;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public partial class UserService
    {
        #region add

        /// <summary>
        /// 用于在用户管理面板 添加一个没有Role的User
        /// </summary>
        /// <param name="entity">The user.</param>
        /// <param name="userRole">The user role.</param>
        /// <param name="operUser">The oper user.</param>
        /// <returns></returns>
        public bool Add(Sys_AdminUser entity, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && !ExistUserByName(entity.username) && !ExistUserByEmail(entity.Email))
            {
                try
                {
                    #region admin user
                    InitAddUser(entity, operUser);
                    adminUserRepository.Add(entity);
                    adminUserRepository.Uow.Commit();
                    #endregion

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
                        log.ShortMessage = "用户Id：" + operUser.id + " 添加一个新用户Id：" + entity.id;
                        log.FullMessage = "AddUser 用户名：" + operUser.username + " 用户Id：" + operUser.id.ToString()
                            + " 添加用户Id：" + entity.id + " 添加用户名：" + entity.username;
                    }
                    else
                    {
                        log.UserId = 0;
                        log.ShortMessage = "用户名：" + entity.username + "被添加";
                        log.FullMessage = "AddUser " + "用户名：" + entity.username + "被添加";
                    }
                    iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(log);
                }
                catch (Exception ex)
                {
                    entity.id = 0;
                }
            }
            return res;
        }

        public bool Add(IList<Sys_AdminUser> entity, Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                try
                {
                    foreach (var item in entity)
                    {
                        if (item != null && !ExistUserByName(item.username) && !ExistUserByEmail(item.Email))
                        {
                            InitAddUser(item, operUser);
                            adminUserRepository.Add(item);
                            adminUserRepository.Uow.Commit();

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
                                log.ShortMessage = "用户Id：" + operUser.id + " 添加一个新用户Id：" + item.id;
                                log.FullMessage = "AddUser 用户名：" + operUser.username + " 用户Id：" + operUser.id.ToString()
                                    + " 添加用户Id：" + item.id + " 添加用户名：" + item.username;
                            }
                            else
                            {
                                log.UserId = 0;
                                log.ShortMessage = "用户名：" + item.username + "被添加";
                                log.FullMessage = "AddUser " + "用户名：" + item.username + "被添加";
                            }
                            iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(log);
                        }
                    }
                    res = true;
                }
                catch (Exception ex)
                {
                }
            }
            return res;
        }

        /// <summary>
        /// Regsters the user.
        /// </summary>
        /// <param name="entity">The user.</param>
        /// <param name="userRole">The user role.</param>
        /// <param name="operUser">The oper user.</param>
        /// <returns></returns>
        public bool Add(Sys_AdminUser entity, Sys_UserRoles userRole, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && !ExistUserByName(entity.username) && !ExistUserByEmail(entity.Email))
            {
                try
                {
                    #region admin user
                    InitAddUser(entity, operUser);
                    adminUserRepository.Add(entity);
                    adminUserRepository.Uow.Commit();
                    #endregion

                    #region user role
                    userRole.UserID = entity.id;
                    userRoleRepository.Add(userRole);
                    userRoleRepository.Uow.Commit();
                    #endregion

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
                        log.ShortMessage = "用户Id：" + operUser.id + " 添加一个新用户Id：" + entity.id;
                        log.FullMessage = "AddUser 用户名：" + operUser.username + " 用户Id：" + operUser.id.ToString()
                            + " 添加用户Id：" + entity.id + " 添加用户名：" + entity.username + " 添加用户角色Id：" + userRole.RoleID;
                    }
                    else
                    {
                        log.UserId = 0;
                        log.ShortMessage = "用户名：" + entity.username + "被添加";
                        log.FullMessage = "AddUser " + "用户名：" + entity.username + "被添加";
                    }
                    iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(log);
                }
                catch (Exception ex)
                {
                    entity.id = 0;
                }
            }
            return res;
        }

        public bool Add(IList<Sys_AdminUser> entity, Sys_UserRoles userRole, Sys_AdminUser operUser)
        {
            var res = false;
            if (entity != null && entity.Count > 0)
            {
                foreach (var item in entity)
                {
                    if (item != null && !ExistUserByName(item.username) && !ExistUserByEmail(item.Email))
                    {
                        try
                        {
                            #region admin user
                            InitAddUser(item, operUser);
                            adminUserRepository.Add(item);
                            adminUserRepository.Uow.Commit();
                            #endregion

                            #region user role
                            userRole.UserID = item.id;
                            userRoleRepository.Add(userRole);
                            userRoleRepository.Uow.Commit();
                            #endregion
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
                                log.ShortMessage = "用户Id：" + operUser.id + " 添加一个新用户Id：" + item.id;
                                log.FullMessage = "AddUser 用户名：" + operUser.username + " 用户Id：" + operUser.id.ToString()
                                    + " 添加用户Id：" + item.id + " 添加用户名：" + item.username + " 添加用户角色Id：" + userRole.RoleID;
                            }
                            else
                            {
                                log.UserId = 0;
                                log.ShortMessage = "用户名：" + item.username + "被添加";
                                log.FullMessage = "AddUser " + "用户名：" + item.username + "被添加";
                            }
                            iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(log);
                        }
                        catch (Exception ex)
                        {
                            item.id = 0;
                        }
                    }
                }
            }
            return res;
        }

        #endregion

        protected iPow.Infrastructure.Data.DataSys.Sys_AdminUser InitAddUser(iPow.Infrastructure.Data.DataSys.Sys_AdminUser entity,
             iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            if (entity != null)
            {
                entity.Activity = false;
                entity.DepartmentID = "0";
                //user.Email
                entity.EmployeeID = 0;
                var userid = adminUserRepository.GetList().Max(e => e.id) + 1;
                //user.id = userid;
                entity.lastloginip = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                entity.lastlogintime = System.DateTime.Now;
                entity.logintimes = 1;
                //user.password
                //user.Phone = "";
                //user.sex = "";
                entity.style = 0;
                //user.truename = "";
                entity.UserGuid = iPow.Infrastructure.Crosscutting.Comm.Service.UserGuidService.BuilderUserGuid();
                entity.userid = operUser.id;
                //user.username
            }
            return entity;
        }
    }





}
