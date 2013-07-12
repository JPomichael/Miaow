using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPow.Infrastructure.Data.DataSys;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public class UserExtensionService : IUserExtensionService
    {
        iPow.Domain.Repository.IAdminUserExtensionRepository userExtensionRepository;

        public UserExtensionService(iPow.Domain.Repository.IAdminUserExtensionRepository userExtension)
        {
            if (userExtension == null)
            {
                throw new ArgumentNullException("userExtensionRepository is null");
            }
            userExtensionRepository = userExtension;
        }

        public Data.DataSys.Sys_AdminUserExtension Add(Data.DataSys.Sys_AdminUserExtension userExtension, Data.DataSys.Sys_AdminUser operUser)
        {
            try
            {
                userExtension.AddTime = System.DateTime.Now;
                userExtension.Sort = 0;
                userExtensionRepository.Add(userExtension);
                userExtensionRepository.Uow.Commit();
                //添加日志操作
            }
            catch (Exception ex)
            {
            }
            return userExtension;
        }

        public bool Delete(Data.DataSys.Sys_AdminUserExtension userExtension, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            try
            {
                userExtension.State = false;
                userExtensionRepository.Modify(userExtension);
                userExtensionRepository.Uow.Commit();
                res = true;
                //添加日志操作
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public bool DeleteTrue(Data.DataSys.Sys_AdminUserExtension userExtension, Data.DataSys.Sys_AdminUser operUser)
        {
            var res = false;
            try
            {
                userExtensionRepository.Delete(userExtension);
                userExtensionRepository.Uow.Commit();
                res = true;
                //添加日志操作
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public bool Delete(IList<int> idList, Data.DataSys.Sys_AdminUser operUser)
        {
            var delete = userExtensionRepository.GetList(e => idList.Contains(e.Id));
            foreach (var item in delete)
            {
                item.State = false;
                userExtensionRepository.Modify(item);
            }
            var res = false;
            try
            {
                userExtensionRepository.Uow.Commit();
                res = true;
                //添加日志操作
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public bool DeleteTrue(IList<int> idList, Data.DataSys.Sys_AdminUser operUser)
        {
            var delete = userExtensionRepository.GetList(e => idList.Contains(e.Id));
            foreach (var item in delete)
            {
                userExtensionRepository.Delete(item);
            }
            var res = false;
            try
            {
                userExtensionRepository.Uow.Commit();
                res = true;
                //添加日志操作
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public bool Modify(Data.DataSys.Sys_AdminUserExtension userExtension, Data.DataSys.Sys_AdminUser operUser)
        {
            var b = false;
            if (userExtension != null && userExtension.Id > 0 && userExtension.UserId > 0)
            {
                var log = new Sys_AdminUserLog();
                log.AddTime = System.DateTime.Now;
                log.IpAddress = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                log.PageUrl = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl();
                log.ReferrerUrl = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl();
                log.State = true;
                log.TypeId = 1;
                try
                {
                    userExtensionRepository.Uow.Commit();
                    b = true;
                    if (operUser != null)
                    {
                        log.UserId = operUser.id;
                        log.ShortMessage = "用户Id：" + operUser.id + " 改变用户Id号：" + userExtension.UserId.ToString() + " 的扩展信息";
                        log.FullMessage = "UpdateUser 用户名：" + operUser.username + " 用户Id：" + operUser.id.ToString()
                            + " 改变了用户Id号：" + userExtension.UserId.ToString() + " 的扩展信息";
                    }
                    else
                    {
                        log.UserId = 0;
                        log.ShortMessage = "用户Id号：" + userExtension.UserId.ToString() + " 的扩展信息被修改";
                        log.FullMessage = "UpdateUser " + "用户Id号：" + userExtension.UserId.ToString() + " 的扩展信息被修改";
                    }
                }
                catch (Exception ex)
                {
                    #region  exception
                    if (operUser != null && operUser.id > 0)
                    {
                        log.ShortMessage = "更新用户数据异常";
                        log.FullMessage = log.ShortMessage = "更新用户Id：" + userExtension.UserId.ToString() + " 操作用户Id：" + operUser.id + " 错误信息：" + ex.Message;
                        if (ex.InnerException != null)
                        {
                            log.FullMessage += "   内部错误信息：" + ex.InnerException.Message;
                        }
                    }
                    else
                    {
                        log.ShortMessage = "更新用户数据异常";
                        log.FullMessage = log.ShortMessage = "更新用户Id：" + userExtension.UserId.ToString() + " 错误信息：" + ex.Message;
                        if (ex.InnerException != null)
                        {
                            log.FullMessage += "   内部错误信息：" + ex.InnerException.Message;
                        }
                    }
                    #endregion
                }
                iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(log);
            }
            return b;
        }

        public Data.DataSys.Sys_AdminUserExtension Get(int id)
        {
            var data = userExtensionRepository.GetList(e => e.Id == id).FirstOrDefault();
            return data;
        }

        public IQueryable<Data.DataSys.Sys_AdminUserExtension> GetList()
        {
            var data = userExtensionRepository.GetList().AsQueryable();
            return data;
        }

        /// <summary>
        /// Exists the user by QQ.
        /// </summary>
        /// <param name="qqId">The qq id.</param>
        /// <returns></returns>
        public bool ExistUserByQQId(string qqId)
        {
            return userExtensionRepository.GetList(d => d.QQId == qqId).Any();
        }

        /// <summary>
        /// Exists the user by sina.
        /// </summary>
        /// <param name="sinaId">The sina id.</param>
        /// <returns></returns>
        public bool ExistUserBySinaId(string sinaId)
        {
            return userExtensionRepository.GetList(d => d.SinaId == sinaId).Any();
        }
    }
}
