/*
 This file was create by Xusion at 2011.10.27
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using Wbm.SinaV2API.SinaServices;

namespace Wbm.SinaV2API.Helpers
{
    /// <summary>
    /// 日志对象
    /// </summary>
    public static class ApiLogHelper
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="ex">异常对象</param>
        public static void Append(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendLine(ex.ToString());
            sb.AppendLine(new string('-', 10));

            Save(sb.ToString());
        }

        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="strText">日志内容</param>
        private static void Save(string strText)
        {
            string logFolder = HttpContext.Current.Server.MapPath(SinaConfig.ApiLogPath).TrimEnd('/');
            string logName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "/" + new Random().Next().ToString() + ".log";
            string logPath = logFolder + "/" + logName;

            try
            {
                if (!Directory.Exists(logFolder)) { Directory.CreateDirectory(logFolder); }

                StreamWriter sw = File.AppendText(logPath);
                sw.WriteLine(strText);
                sw.Close();
                sw.Dispose();
            }
            catch { }
        }

    }
}
