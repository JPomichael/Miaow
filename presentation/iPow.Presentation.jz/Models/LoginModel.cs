using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iPow.DataSys;
using Webdiyer.WebControls.Mvc;
using System.Collections;

namespace iPow.jz.Models
{
    public class LoginModel
    {
        private static irainbowEntities irainbow = new DataSys.irainbowEntities(FroumModels.conn);

        /// <summary>
        /// 判断用户是否登陆
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool isLogin(string email, string password)
        {
            if (password == null)
            {
                password = "";
            }
            password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5");
            sns_user snsUser = irainbow.sns_user.Where(o => o.email == email && o.passwd == password).SingleOrDefault();
            if (snsUser == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class snsFeed
    {
        public string icon { get; set; }
        public string title_data { get; set; }
        public string time { get; set; }
    }
}