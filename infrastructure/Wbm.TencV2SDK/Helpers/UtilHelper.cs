using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Script.Serialization;
using System.Text;
using System.IO;
using System.Web;
using Microsoft.Win32;

namespace Wbm.TencV2SDK.Helpers
{
    /// <summary>
    /// 常用函数助手
    /// </summary>
    public static class UtilHelper
    {
        /// <summary>
        /// ParseQueryString
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static NameValueCollection GetQueryParameters(string strValue)
        {
            var paras = new NameValueCollection();
            if (!string.IsNullOrEmpty(strValue))
            {
                foreach (var item in strValue.Trim(' ', '?', '&').Split('&'))
                {
                    if (item.IndexOf('=') > -1)
                    {
                        var temp = item.Split('=');
                        paras.Add(temp[0], temp[1]);
                    }
                    else
                    {
                        paras.Add(item, string.Empty);
                    }
                }
            }
            return paras;
        }

        /// <summary>
        /// GetQueryFromParas
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static string GetQueryFromParas(NameValueCollection paras)
        {

            if (paras == null || paras.Count == 0)
                return "";
            StringBuilder sbList = new StringBuilder();
            int count = 1;
            foreach (var key in paras.AllKeys)
            {
                sbList.AppendFormat("{0}={1}", key, HttpUtility.UrlEncode(paras[key]));
                if (count < paras.Count)
                {
                    sbList.Append("&");
                }
                count++;
            }
            return sbList.ToString(); ;
        }

        /// <summary>
        /// 根据文件名获取文件类型
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetContentType(string fileName)
        {
            string contentType = "application/octetstream";
            string ext = Path.GetExtension(fileName).ToLower();
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(ext);

            if (registryKey != null && registryKey.GetValue("Content Type") != null)
            {
                contentType = registryKey.GetValue("Content Type").ToString();
            }

            return contentType;
        }

        /// <summary>
        /// json数据转对象
        /// </summary>
        /// <param name="strJson">json数据</param>
        /// <returns></returns>
        public static T ParseJson<T>(string strJson)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(strJson);
        }

        /// <summary>
        /// 对象转json数据
        /// </summary>
        /// <param name="strJson">json数据</param>
        /// <returns></returns>
        public static string ParseJson(object objModel)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(objModel);
        }


        /// <summary>
        /// Utc时间转本地时间
        /// </summary>
        /// <param name="strValue">原格式：Wed Nov 17 15:07:48 +0800 2010</param>
        /// <returns></returns>
        public static string UtcToDateTime(string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                //原格式：Wed Nov 17 15:07:48 +0800 2010
                string[] str = strValue.Split(' ');
                //转格式：Wed Nov 17 2010 15:07:48
                return str[0] + " " + str[1] + " " + str[2] + " " + str[5] + " " + str[3];
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 获取客户端IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;
        }
    }
}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */