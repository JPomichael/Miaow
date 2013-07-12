using System;
using System.Web;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    ///cook 的摘要说明
    /// </summary>
    public class CookieHelper
    {
        /// <summary>
        /// 保存一个Cookie
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="value">Cookie值</param>
        /// <param name="time">Cookie过期时间(小时),0为关闭页面失效</param>
        public static void Add(string name, string value, double time)
        {
            HttpCookie cookie = new HttpCookie(name);
            DateTime now = DateTime.Now;
            cookie.Value = value;
            if (time != 0)
            {
                cookie.Expires = now.AddHours(time);
            }
            if (HttpContext.Current.Response.Cookies[name] != null)
            {
                HttpContext.Current.Response.Cookies.Remove(name);
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }


        /// <summary>
        /// Adds the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="time">The time.以分钟计算</param>
        /// <param name="domain">The domain.</param>
        /// <param name="httpOnly">if set to <c>true</c> [HTTP only].</param>
        /// <param name="path">The path.</param>
        public static void Add(string name, string value, double time, string domain, bool httpOnly, string path)
        {
            HttpCookie cookie = new HttpCookie(name);
            DateTime now = DateTime.Now;
            cookie.Value = value;
            cookie.Domain = domain;
            cookie.HttpOnly = httpOnly;
            cookie.Path = path;
            if (time != 0)
            {
                cookie.Expires = now.AddMinutes(time);
            }
            if (HttpContext.Current.Response.Cookies[name] != null)
            {
                //HttpContext.Current.Response.Cookies.Remove(name);
            }
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 取得CookieValue
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        /// <returns>Cookie的值</returns>
        public static string Get(string name)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null)
            {
                return cookie.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 清除CookieValue
        /// </summary>
        /// <param name="CookieName">Cookie名称</param>
        public static void Clear(string name)
        {
            HttpCookie cookie = new HttpCookie(name);
            DateTime now = DateTime.Now;
            cookie.Expires = now.AddYears(-2);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}