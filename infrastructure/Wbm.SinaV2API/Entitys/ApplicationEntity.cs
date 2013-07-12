/*
 This file was create by Xusion at 2011.10.27
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wbm.SinaV2API.Entitys
{
    #region ApplicationEntity 实体
    /// <summary>
    /// Application实体
    /// </summary>
    public class ApplicationEntity
    {
        /// <summary>
        /// 名字，只是做判断使用，但不能重复
        /// </summary>
        public string AppName { set; get; }

        /// <summary>
        /// 申请QQ登录成功后，分配给网站的appid。
        /// </summary>
        public string AppKey { set; get; }

        /// <summary>
        /// 申请QQ登录成功后，分配给网站的appkey。
        /// </summary>
        public string AppSecret { set; get; }

        /// <summary>
        /// 成功授权后的回调地址，建议设置为网站首页或网站的用户中心。
        /// </summary>
        public string RedirectUri { set; get; }


        /// <summary>
        /// 新浪APPKey实体
        /// </summary>
        /// <param name="AppName">名字，只是做判断使用，但不能重复</param>
        /// <param name="AppKey">App Key</param>
        /// <param name="AppSecret">App Secret</param>
        /// <param name="AppSecret">App RedirectUri</param>
        public ApplicationEntity(string AppName, string AppKey, string AppSecret, string RedirectUri)
        {
            this.AppName = AppName;
            this.AppKey = AppKey;
            this.AppSecret = AppSecret;
            this.RedirectUri = RedirectUri;
        }
    }
    #endregion

}
