/*
 This file was create by Xusion at 2011.10.27
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Wbm.SinaV2API.SinaServices;

namespace Wbm.SinaV2API.Helpers
{
    /// <summary>
    /// 缓存对象(只能对当前网站客户端有效)
    /// </summary>
    public static class ApiCacheHelper
    {
        /// <summary>
        /// 获取值 当前使用Session
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static object GetValue(string strName)
        {
            switch (SinaConfig.KeyCacheMode)
            {
                case "Cookies":
                    return GetCookieValue(strName);
                case "Cache":
                    return GetCacheValue(strName);
                default:
                    return GetSessionValue(strName);
            }
        }
        /// <summary>
        /// 设置值 默认使用Session(config配置)
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strValue"></param>
        public static void SetValue(string strName, string strValue)
        {
            switch (SinaConfig.KeyCacheMode)
            {
                case "Cookies":
                    SetCookieValue(strName, strValue);
                    break;
                case "Cache":
                    SetCacheValue(strName, strValue);
                    break;
                default:
                    SetSessionValue(strName, strValue);
                    break;
            }
        }

        #region  缓存各种方法 (session,cookie)
        /// <summary>
        /// 获取Session值 
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        private static object GetSessionValue(string strName)
        {
            return HttpContext.Current.Session[strName] != null ? HttpContext.Current.Session[strName] : null;
        }

        /// <summary>
        /// 设置Session值 
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strValue"></param>
        private static void SetSessionValue(string strName, object strValue)
        {
            HttpContext.Current.Session.Timeout = SinaConfig.KeyCacheTimeout;
            HttpContext.Current.Session[strName] = strValue;
        }

        /// <summary>
        /// 获取Cache值 
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        private static object GetCacheValue(string strName)
        {
            return HttpContext.Current.Cache[strName] != null ? HttpContext.Current.Cache[strName] : null;
        }

        /// <summary>
        /// 设置Cache值 
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strValue"></param>
        private static void SetCacheValue(string strName, object strValue)
        {
            HttpContext.Current.Cache.Insert(strName, strValue, null, DateTime.Now.AddMinutes(SinaConfig.KeyCacheTimeout), System.Web.Caching.Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 获取Cookie值 
        /// </summary>
        /// <param name="strName"></param>
        private static string GetCookieValue(string strName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie != null)
            {
                return cookie.Value;
            }
            return "";
        }

        /// <summary>
        /// 设置Cookie值 
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strValue"></param>
        private static void SetCookieValue(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null) { cookie = new HttpCookie(strName); }
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddMinutes(SinaConfig.KeyCacheTimeout);
            cookie.HttpOnly = true;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        #endregion
    }
}
