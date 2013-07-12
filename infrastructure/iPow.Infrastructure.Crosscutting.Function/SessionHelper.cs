using System.Web;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    /// Session操作类
    /// </summary>
    public static class SessionHelper
    {
        /// <summary>
        /// 添加Session，调动有效期为20分钟
        /// </summary>
        /// <param name="key">Session对象名称</param>
        /// <param name="value">Session值</param>
        public static void Add(string key, string value)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session[key] = value;
            }
            else
            {
                HttpContext.Current.Session.Add(key, value);
            }
            HttpContext.Current.Session.Timeout = 20;
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="val">The val.</param>
        public static void Add(string key, object val)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session[key] = val;
            }
            else
            {
                HttpContext.Current.Session.Add(key, val);
            }
            HttpContext.Current.Session.Timeout = 20;
        }

        /// <summary>
        /// 添加Session，调动有效期为20分钟
        /// </summary>
        /// <param name="key">Session对象名称</param>
        /// <param name="values">Session值数组</param>
        public static void Adds(string key, string[] values)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session[key] = values;
            }
            else
            {
                HttpContext.Current.Session.Add(key, values);
            }
            HttpContext.Current.Session.Timeout = 20;
        }
        /// <summary>
        /// 添加Session
        /// </summary>
        /// <param name="key">Session对象名称</param>
        /// <param name="value">Session值</param>
        /// <param name="iExpires">调动有效期（分钟）</param>
        public static void Add(string key, string value, int iExpires)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session[key] = value;
            }
            else
            {
                HttpContext.Current.Session.Add(key, value);
            }
            HttpContext.Current.Session.Timeout = iExpires;
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="iExpires">The i expires.</param>
        public static void Add(string key, object value, int iExpires)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session[key] = value;
            }
            else
            {
                HttpContext.Current.Session.Add(key, value);
            }
            HttpContext.Current.Session.Timeout = iExpires;
        }

        /// <summary>
        /// 添加Session
        /// </summary>
        /// <param name="key">Session对象名称</param>
        /// <param name="values">Session值数组</param>
        /// <param name="iExpires">调动有效期（分钟）</param>
        public static void Adds(string key, string[] values, int iExpires)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session[key] = values;
            }
            else
            {
                HttpContext.Current.Session.Add(key, values);
            }
            HttpContext.Current.Session.Timeout = iExpires;
        }

        /// <summary>
        /// Addses the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="values">The values.</param>
        /// <param name="iExpires">The i expires.</param>
        public static void Adds(string key, object[] values, int iExpires)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session[key] = values;
            }
            else
            {
                HttpContext.Current.Session.Add(key, values);
            }
            HttpContext.Current.Session.Timeout = iExpires;
        }

        /// <summary>
        /// 读取某个Session对象值
        /// </summary>
        /// <param name="strSessionName">Session对象名称</param>
        /// <returns>Session对象值</returns>
        public static string GetStringValue(string key)
        {
            if (HttpContext.Current.Session[key] == null)
            {
                return null;
            }
            else
            {
                return HttpContext.Current.Session[key].ToString();
            }
        }

        /// <summary>
        /// Gets the specified s.
        /// </summary>
        /// <param name="key">The s.</param>
        /// <param name="b">if set to <c>true</c> [b].</param>
        /// <returns></returns>
        public static object GetObjectValue(string key)
        {
            if (HttpContext.Current.Session[key] == null)
            {
                return null;
            }
            else
            {
                return HttpContext.Current.Session[key];
            }
        }

        /// <summary>
        /// 读取某个Session对象值数组
        /// </summary>
        /// <param name="key">Session对象名称</param>
        /// <returns>Session对象值数组</returns>
        public static string[] GetStringArray(string key)
        {
            if (HttpContext.Current.Session[key] == null)
            {
                return null;
            }
            else
            {
                return (string[])HttpContext.Current.Session[key];
            }
        }
        /// <summary>
        /// 删除某个Session对象
        /// </summary>
        /// <param name="key">Session对象名称</param>
        public static void Delete(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
    }
}
