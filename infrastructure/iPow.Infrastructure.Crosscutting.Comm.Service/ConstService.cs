using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Comm.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class ConstService
    {
        #region session names

        /// <summary>
        /// 
        /// </summary>
        public const string SessionNameCurrentUser = "ipow.session.user";

        #region sina

        /// <summary>
        /// 用于新浪用户登陆
        /// </summary>
        public const string SessionNameSinaOauthToken = "sina.oauth.token";

        /// <summary>
        /// 用于新浪用户登陆
        /// </summary>
        public const string SessionNameSinaOauthTokenSecret = "sina.oauth.token.secret";

        /// <summary>
        /// 用于新浪用户登陆
        /// </summary>
        public const string SessionNameSinaReturnUrl = "sina.returnurl";


        #endregion

        #region tencent
        /// <summary>
        /// 用于腾讯用户登陆
        /// </summary>
        public const string SessionNameTencentOauthToken = "tencent.oauth.token";

        /// <summary>
        /// 用于腾讯用户登陆
        /// </summary>
        public const string SessionNameTencentOauthTokenSecret = "tencent.oauth.token.secret";

        /// <summary>
        /// 用于腾讯用户登陆
        /// </summary>
        public const string SessionNameTencentReturnUrl = "tencent.returnurl";

        #endregion




        /// <summary>
        /// 
        /// </summary>
        public const int SessionExpires = 60;

        #endregion

        #region cookie name

        /// <summary>
        /// 暂时没用
        /// </summary>
        public const string CookieNameCurrentUser = "ipow.customer";

        /// <summary>
        /// 暂时没用
        /// </summary>
        public const string CookieNameCurrentCityInfo = "ipow.city";

        /// <summary>
        /// 暂时没用
        /// </summary>
        public const string CookieNameCurrentSelectedCityInfo = "ipow.selected.city";

        /// <summary>
        /// 
        /// </summary>
        public const string CookieNameUserLogined = "__utmuled";

        /// <summary>
        /// 默认为1440，以分钟计算为一天
        /// </summary>
        public const int CookieExpires = 1440;

        #endregion

        #region other


        /// <summary>
        /// cookies加密密钥
        /// </summary>
        public const string CurrentUserDesKey = "szhdl201";

        /// <summary>
        /// ipowwebworkcontext.cs 用到
        /// </summary>
        public const int UserSearchEngineUserId = 60;

        #endregion

        #region url para

        /// <summary>
        /// 
        /// </summary>
        public const string UrlParaReturnUrl = "returnUrl";

        /// <summary>
        /// 
        /// </summary>
        public const string UrlParaToken = "token";

        #endregion


    }
}
