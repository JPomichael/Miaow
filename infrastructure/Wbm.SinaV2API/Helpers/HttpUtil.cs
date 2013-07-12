/*
 This file was create by Xusion at 2011.10.27
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Web.Script.Serialization;

namespace Wbm.SinaV2API.Helpers
{
    public static class HttpUtil
    {
        /// <summary>
        /// ParseQueryString
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static List<QueryParameter> GetQueryParameters(string strValue)
        {
            List<QueryParameter> list = new List<QueryParameter>();
            if (!string.IsNullOrEmpty(strValue))
            {
                foreach (var item in strValue.Trim(' ', '?', '&').Split('&'))
                {
                    if (item.IndexOf('=') > -1)
                    {
                        var temp = item.Split('=');
                        list.Add(new QueryParameter(temp[0], temp[1]));
                    }
                    else
                    {
                        list.Add(new QueryParameter(item, string.Empty));
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// GetQueryFromParas
        /// </summary>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static string GetQueryFromParas(List<QueryParameter> paras)
        {
            if (paras == null || paras.Count == 0)
                return "";
            StringBuilder sbList = new StringBuilder();
            int count = 1;
            foreach (QueryParameter para in paras)
            {
                sbList.AppendFormat("{0}={1}", para.Name, para.Value);
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
        /// json数据转dic
        /// </summary>
        /// <param name="strJson">json数据</param>
        /// <returns></returns>
        public static T ParseJson<T>(string strJson)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(strJson);
        }

        /// <summary>
        /// 获取Dictionary值
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetDicValue(Dictionary<string, object> dic, string keyName)
        {
            return dic.ContainsKey(keyName) ? dic[keyName].ToString() : string.Empty;
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
        /// 获取头像URl
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="imageUrlEntity"></param>
        /// <returns></returns>
        public static string GetImageUrl(string strValue, ImageUrlEntity imageUrlEntity)
        {
            return strValue.Replace("/50/", "/" + (int)imageUrlEntity + "/");
        }
    }

    /// <summary>
    /// QueryParameter
    /// </summary>
    public class QueryParameter
    {
        private string name = string.Empty;
        private string value = string.Empty;

        public QueryParameter(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
        public QueryParameter(string name, object value)
        {
            this.name = name;
            this.value = value.ToString();
        }
        public string Name
        {
            get { return name == null ? string.Empty : name.Trim(); }
        }

        public string Value
        {
            get { return value == null ? string.Empty : value.Trim(); }
        }
    }

}
