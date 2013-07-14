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
        /// Regsters the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="userRole">The user role.</param>
        /// <param name="operUser">The oper user.</param>
        /// <returns></returns>
        public Sys_AdminUser Add(Sys_AdminUser user, Sys_UserRoles userRole, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            if (user != null)
            {
                if (!ExistUserByName(user.username) && !ExistUserByEmail(user.Email))
                {
                    try
                    {
                        #region admin user

                        user.Activity = false;
                        user.DepartmentID = "0";
                        //user.Email
                        user.EmployeeID = 0;
                        var userid = adminUserRepository.GetList().Max(e => e.id) + 1;
                        user.id = userid;
                        user.lastloginip = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                        user.lastlogintime = System.DateTime.Now;
                        user.logintimes = 1;
                        //user.password
                       // user.Phone = "";
                        user.roleid = userRole.RoleID;
                       // user.sex = "";
                        user.style = 0;
                       // user.truename = "";
                        user.UserGuid = iPow.Infrastructure.Crosscutting.Comm.Service.UserGuidService.BuilderUserGuid();
                        user.userid = operUser.id;
                        //user.username
                        adminUserRepository.Add(user);
                        #endregion

                        #region user role

                        userRole.UserID = userid;

                        userRoleRepository.Add(userRole);
                        #endregion

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
                            log.ShortMessage = "用户Id：" + operUser.id + " 添加一个新用户Id：" + user.id;
                            log.FullMessage = "AddUser 用户名：" + operUser.username + " 用户Id：" + operUser.id.ToString()
                                + " 添加用户Id：" + user.id + " 添加用户名：" + user.username + " 添加用户角色Id：" + userRole.RoleID;
                        }
                        else
                        {
                            log.UserId = 0;
                            log.ShortMessage = "用户名：" + user.username + "被添加";
                            log.FullMessage = "AddUser " + "用户名：" + user.username + "被添加";
                        }
                        iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(log);
                    }
                    catch (Exception ex)
                    {
                        user.id = 0;
                    }
                }
            }
            return user;
        }

        /// <summary>
        /// 用于在用户管理面板 添加一个没有Role的User
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="userRole">The user role.</param>
        /// <param name="operUser">The oper user.</param>
        /// <returns></returns>
        public Sys_AdminUser Add(Sys_AdminUser user, iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            if (user != null)
            {
                if (!ExistUserByName(user.username) && !ExistUserByEmail(user.Email))
                {
                    try
                    {
                        #region admin user

                        user.Activity = false;
                        user.DepartmentID = "0";
                        //user.Email
                        user.EmployeeID = 0;
                        var userid = adminUserRepository.GetList().Max(e => e.id) + 1;
                        //user.id = userid;
                        user.lastloginip = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                        user.lastlogintime = System.DateTime.Now;
                        user.logintimes = 1;
                        //user.password
                        //user.Phone = "";
                        //user.sex = "";
                        user.style = 0;
                        //user.truename = "";
                        user.UserGuid = iPow.Infrastructure.Crosscutting.Comm.Service.UserGuidService.BuilderUserGuid();
                        user.userid = operUser.id;
                        //user.username
                        adminUserRepository.Add(user);
                        #endregion

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
                            log.ShortMessage = "用户Id：" + operUser.id + " 添加一个新用户Id：" + user.id;
                            log.FullMessage = "AddUser 用户名：" + operUser.username + " 用户Id：" + operUser.id.ToString()
                                + " 添加用户Id：" + user.id + " 添加用户名：" + user.username;
                        }
                        else
                        {
                            log.UserId = 0;
                            log.ShortMessage = "用户名：" + user.username + "被添加";
                            log.FullMessage = "AddUser " + "用户名：" + user.username + "被添加";
                        }
                        iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(log);
                    }
                    catch (Exception ex)
                    {
                        user.id = 0;
                    }
                }
            }
            return user;
        }

        #endregion
    }
}
