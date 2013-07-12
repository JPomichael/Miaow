using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iPow.Infrastructure.Data.DataSys;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public partial class UserService
    {
        #region get

        public IQueryable<Sys_AdminUser> GetList()
        {
            var res = adminUserRepository.GetList().AsQueryable();
            return res;
        }

        /// <summary>
        /// Gets the name of the user id by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public int GetUserIdByName(string name)
        {
            int res = 0;
            res = adminUserRepository.GetList(e => e.username == name).FirstOrDefault().id;
            return res;
        }

        /// <summary>
        /// Gets the name of the user model by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public iPow.Infrastructure.Data.DataSys.Sys_AdminUser GetUserByName(string name)
        {
            iPow.Infrastructure.Data.DataSys.Sys_AdminUser user = null;
            user = adminUserRepository.GetList(e => e.username == name).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Gets the user name by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public string GetUserNameById(int id)
        {
            var res = string.Empty;
            res = adminUserRepository.GetList(d => d.id == id).FirstOrDefault().username;
            return res;
        }

        /// <summary>
        /// Gets the name of the user model by.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Sys_AdminUser GetUserById(int id)
        {
            return adminUserRepository.GetList(d => d.id == id).FirstOrDefault();
        }

        /// <summary>
        /// Gets the user model by user name and PWD.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="pwd">The PWD.</param>
        /// <returns></returns>
        public Sys_AdminUser GetUserByUserAndPwd(string name, string pwd)
        {
            string password = iPow.Infrastructure.Crosscutting.Function.StringHelper.Tomd5(pwd);
            return adminUserRepository.GetList(e => e.username == name && e.password == password).FirstOrDefault();
        }


        /// <summary>
        /// Gets the user model by email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Sys_AdminUser GetUserByEmail(string email)
        {
            return adminUserRepository.GetList(d => d.Email == email).FirstOrDefault();
        }

        /// <summary>
        /// Gets the user model by QQ.
        /// </summary>
        /// <param name="qqId"></param>
        /// <returns></returns>
        public Sys_AdminUser GetUserByQQ(string qqId)
        {
            Sys_AdminUser user = null;
            var idModel = adminUserExtensionRepository.GetList(d => d.QQId == qqId).FirstOrDefault();
            if (idModel != null)
            {
                user = adminUserRepository.GetList(d => d.id == idModel.UserId).FirstOrDefault();
            }
            return user;
        }

        /// <summary>
        /// Gets the user model by sina.
        /// </summary>
        /// <param name="sinaId"></param>
        /// <returns></returns>
        public Sys_AdminUser GetUserBySina(string sinaId)
        {
            Sys_AdminUser user = null;
            var idModel = adminUserExtensionRepository.GetList(d => d.SinaId == sinaId).FirstOrDefault();
            if (idModel != null)
            {
                user = adminUserRepository.GetList(d => d.id == idModel.UserId).FirstOrDefault();
            }
            return user;
        }

        /// <summary>
        /// Gets the user model by user GUID.
        /// </summary>
        /// <param name="guid">The GUID.</param>
        /// <returns></returns>
        public Sys_AdminUser GetUserByUserGuid(string guid)
        {
            return adminUserRepository.GetList(d => d.UserGuid == guid).FirstOrDefault();
        }

        #endregion

    }
}
