using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPow.Infrastructure.Crosscutting.Comm.Service
{
    public class SsoService
    {
        /// <summary>
        /// Gets the sso log on and return URL.
        /// </summary>
        /// <returns></returns>
        public static string GetSsoLogOnAndReturnUrl()
        {
            var ssoLogOnUrl = GetSsoLogOnUrl();
            var currentUrl = iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.UrlParaReturnUrl + "=" +
                iPow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl();
            var returnUrl = ssoLogOnUrl + "?" + currentUrl;
            return returnUrl;
        }

        /// <summary>
        /// Gets the sso log off and return URL.
        /// </summary>
        /// <returns></returns>
        public static string GetSsoLogOffAndReturnUrl()
        {
            var ssoLogOffUrl = GetSsoLogOffUrl();
            var currentUrl = iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.UrlParaReturnUrl + "=" +
                iPow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl();
            var returnUrl = ssoLogOffUrl + "?" + currentUrl;
            return returnUrl;
        }

        /// <summary>
        /// Gets the sso log off and return default URL.
        /// </summary>
        /// <returns></returns>
        public static string GetSsoLogOffAndReturnDefaultUrl()
        {
            var ssoLogOffUrl = GetSsoLogOffUrl();
            var currentUrl = iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.UrlParaReturnUrl + "=" +
                iPow.Infrastructure.Crosscutting.Function.StringHelper.GetDomainName();
            var returnUrl = ssoLogOffUrl + "?" + currentUrl;
            return returnUrl;
        }


        /// <summary>
        /// Gets the sso token and return URL.
        /// </summary>
        /// <returns></returns>
        public static string GetSsoTokenAndReturnUrl()
        {
            var ssoTokenUrl = GetSsoTokenUrl();
            var currentUrl = iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.UrlParaReturnUrl + "=" +
                iPow.Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl();
            var returnUrl = ssoTokenUrl + "?" + currentUrl;
            return returnUrl;
        }


        /// <summary>
        /// Sends the sso user logined cookie.
        /// </summary>
        public static void SendSsoUserLoginedCookie()
        {
            //发放公用已登陆标志cookie
            iPow.Infrastructure.Crosscutting.Function.CookieHelper.Add(
                iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieNameUserLogined,
                "1",
                iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieExpires
                , "ipow.cn", true, "/");
        }

        /// <summary>
        /// Sends the sso user logined cookie.
        /// </summary>
        public static void SendSsoUserLoginedExpiresCookie()
        {
            //发放公用已登陆标志cookie
            iPow.Infrastructure.Crosscutting.Function.CookieHelper.Add(
                iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieNameUserLogined,
                "",
                -100
                , "ipow.cn", true, "/");

            iPow.Infrastructure.Crosscutting.Function.CookieHelper.Add(
                iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieNameUserLogined,
                "",
                -100
                , "sso.ipow.cn", true, "/");
        }

        /// <summary>
        /// 这个cookie也是拿到当前域的cookie，而不是域ipow.cn, 也可能会有两个cookie所以这样写，去拿到有值的cookie
        /// </summary>
        /// <param name="cookieList">The cookie list.</param>
        /// <returns></returns>
        public static List<int> GetUserLoginedCookieNameIndexList(System.Web.HttpCookieCollection cookieList)
        {
            //这个cookie也是拿到当前域的cookie，而不是域ipow.cn, 也可能会有两个cookie所以这样写，去拿到有值的cookie
            var cookieNameList = cookieList.AllKeys.ToList();
            var cookieNameIndexList = new List<int>();
            var targetUserLoginedStr = iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.CookieNameUserLogined;
            for (int i = 0; i < cookieNameList.Count; i++)
            {
                if (cookieNameList[i].CompareTo(targetUserLoginedStr) == 0)
                {
                    cookieNameIndexList.Add(i);
                }
            }
            return cookieNameIndexList;
        }
        
        /// <summary>
        /// Gets the sso log on URL.
        /// </summary>
        /// <returns></returns>
        public static string GetSsoLogOnUrl()
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["ssoLogOnUrl"];
            return url;
        }

        /// <summary>
        /// Gets the sso log off URL.
        /// </summary>
        /// <returns></returns>
        public static string GetSsoLogOffUrl()
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["ssoLogOffUrl"];
            return url;
        }

        /// <summary>
        /// Gets the sso token URL.
        /// </summary>
        /// <returns></returns>
        public static string GetSsoTokenUrl()
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["ssoTokenUrl"];
            return url;
        }

        #region  builder user token id

        /// <summary>
        ///  builder token id
        /// </summary>
        /// <returns></returns>
        public static string BuilderTokenId()
        {
            var randBuilder = new iPow.Infrastructure.Crosscutting.Validator.VerifyCode();
            return Guid.NewGuid().ToString() + "-" + randBuilder.CreateVerifyCode(10);
        }
        #endregion

    }
}
