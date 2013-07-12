using System.Web;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    /// Session������
    /// </summary>
    public static class SessionHelper
    {
        /// <summary>
        /// ���Session��������Ч��Ϊ20����
        /// </summary>
        /// <param name="key">Session��������</param>
        /// <param name="value">Sessionֵ</param>
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
        /// ���Session��������Ч��Ϊ20����
        /// </summary>
        /// <param name="key">Session��������</param>
        /// <param name="values">Sessionֵ����</param>
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
        /// ���Session
        /// </summary>
        /// <param name="key">Session��������</param>
        /// <param name="value">Sessionֵ</param>
        /// <param name="iExpires">������Ч�ڣ����ӣ�</param>
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
        /// ���Session
        /// </summary>
        /// <param name="key">Session��������</param>
        /// <param name="values">Sessionֵ����</param>
        /// <param name="iExpires">������Ч�ڣ����ӣ�</param>
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
        /// ��ȡĳ��Session����ֵ
        /// </summary>
        /// <param name="strSessionName">Session��������</param>
        /// <returns>Session����ֵ</returns>
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
        /// ��ȡĳ��Session����ֵ����
        /// </summary>
        /// <param name="key">Session��������</param>
        /// <returns>Session����ֵ����</returns>
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
        /// ɾ��ĳ��Session����
        /// </summary>
        /// <param name="key">Session��������</param>
        public static void Delete(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
    }
}
