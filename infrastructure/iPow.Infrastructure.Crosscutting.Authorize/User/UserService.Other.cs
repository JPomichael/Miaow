using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Authorize
{
    public partial class UserService
    {
        #region other

        /// <summary>
        /// 用于Add user前的 存在与否判断
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public bool UserHasUser(string username, string email)
        {
            var res = adminUserRepository.GetList(e => e.username == username && e.Email == email).Any();
            return res;
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
        #endregion

    }
}
