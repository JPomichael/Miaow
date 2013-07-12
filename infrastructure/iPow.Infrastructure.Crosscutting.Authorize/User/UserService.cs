using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Infrastructure.Data.DataSys;
using iPow.Infrastructure.Crosscutting.Comm.Service;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public partial class UserService : IUserService
    {
        iPow.Domain.Repository.IAdminUserRepository adminUserRepository;

        iPow.Domain.Repository.IAdminUserExtensionRepository adminUserExtensionRepository;

        iPow.Domain.Repository.IAdminUserIndividuationRepository adminUserIndividuationRepository;

        iPow.Domain.Repository.IUserActionRepository userActionRepository;

        iPow.Domain.Repository.IUserRoleRepository userRoleRepository;

        iPow.Domain.Repository.IRolePermissionRepository rolePermissionRepository;

        public UserService(iPow.Domain.Repository.IAdminUserRepository adminUser,
             iPow.Domain.Repository.IAdminUserExtensionRepository adminUserExtension,
             iPow.Domain.Repository.IAdminUserIndividuationRepository adminUserIndividuation,
             iPow.Domain.Repository.IUserActionRepository userAction,
             iPow.Domain.Repository.IUserRoleRepository userRole,
             iPow.Domain.Repository.IRolePermissionRepository rolePermission)
        {
            if (adminUser == null)
            {
                throw new ArgumentNullException("adminuserrepository is null");
            }
            if (adminUserExtension == null)
            {
                throw new ArgumentNullException("adminUserExtensionRepository is null");
            }
            if (adminUserIndividuation == null)
            {
                throw new ArgumentNullException("adminUserIndividuationRepository is null");
            }
            if (userAction == null)
            {
                throw new ArgumentNullException("userActionRepository is null");
            }
            if (userRole == null)
            {
                throw new ArgumentNullException("userRoleRepository is null");
            }
            if (rolePermission == null)
            {
                throw new ArgumentNullException("rolePermissionRepository is null");
            }
            adminUserRepository = adminUser;
            adminUserExtensionRepository = adminUserExtension;
            adminUserIndividuationRepository = adminUserIndividuation;
            userActionRepository = userAction;
            userRoleRepository = userRole;
            rolePermissionRepository = rolePermission;
        }

        #region  exist

        /// <summary>
        /// Exists the user by name PWD.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pwd">The PWD.</param>
        /// <param name="login">if set to <c>true</c> [login].</param>
        /// <returns></returns>
        public bool ExistUserByNamePwd(string name, string pwd, bool login)
        {
            bool b = false;
            pwd = iPow.Infrastructure.Crosscutting.Function.StringHelper.Tomd5(pwd);
            var user = adminUserRepository.GetList(e => e.username == name)
                .Where(e => e.password == pwd)
                .Where(d => d.Activity == true)
                .FirstOrDefault();
            if (user != null)
            {
                b = true;
                var log = new Sys_AdminUserLog();
                log.AddTime = System.DateTime.Now;
                log.IpAddress = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                log.PageUrl = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl();
                log.ReferrerUrl = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl();
                log.State = true;
                log.TypeId = 1;
                log.UserId = 0;
                log.UserId = 0;
                log.FullMessage = "ExistUserByNamePwd 用户Id号：" + user.id.ToString();
                log.ShortMessage = "查找用户名：" + name + " 密码：" + pwd + "成功";
                //查找成功
                if (login)
                {
                    user.lastloginip = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                    user.lastlogintime = System.DateTime.Now;
                    user.logintimes += 1;
                    //添加日志用户日志
                    log.ShortMessage = "用户名：" + name + " 密码：" + pwd + "登陆成功";
                }
                iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(log);
            }
            return b;
        }

        /// <summary>
        /// Exists the user by name PWD no MD5.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pwd">The PWD.</param>
        /// <returns></returns>
        public bool ExistUserByNamePwdEncrypted(string name, string pwd)
        {
            bool b = false;
            var user = adminUserRepository.GetList(e => e.username == name)
                .Where(e => e.password == pwd)
                .Where(d => d.Activity == true)
                .FirstOrDefault();
            if (user != null)
            {
                b = true;
            }
            return b;
        }

        /// <summary>
        /// Exists the name of the user by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public bool ExistUserByName(string name)
        {
            bool b = false;
            int res = adminUserRepository.GetList(e => e.username == name).Count();
            if (res > 0)
            {
                b = true;
            }
            return b;
        }

        /// <summary>
        /// Exists the name of the user by.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ExistUserByEmail(string email)
        {
            return adminUserRepository.GetList(d => d.Email == email).Any();
        }

        #endregion
    }
}