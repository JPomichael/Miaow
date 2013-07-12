using System;
using System.Web;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    ///cook ��ժҪ˵��
    /// </summary>
    public class CookieHelper
    {
        /// <summary>
        /// ����һ��Cookie
        /// </summary>
        /// <param name="name">Cookie����</param>
        /// <param name="value">Cookieֵ</param>
        /// <param name="time">Cookie����ʱ��(Сʱ),0Ϊ�ر�ҳ��ʧЧ</param>
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
        /// <param name="time">The time.�Է��Ӽ���</param>
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
        /// ȡ��CookieValue
        /// </summary>
        /// <param name="CookieName">Cookie����</param>
        /// <returns>Cookie��ֵ</returns>
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
        /// ���CookieValue
        /// </summary>
        /// <param name="CookieName">Cookie����</param>
        public static void Clear(string name)
        {
            HttpCookie cookie = new HttpCookie(name);
            DateTime now = DateTime.Now;
            cookie.Expires = now.AddYears(-2);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}