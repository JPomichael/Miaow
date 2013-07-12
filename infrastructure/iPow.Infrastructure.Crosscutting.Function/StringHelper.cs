using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Xml;
using System.Collections.Generic;
using System.Web;
using System.Diagnostics;

namespace iPow.Infrastructure.Crosscutting.Function
{
    /// <summary>
    /// 字符串操作工具集
    /// Copyright (C) 2008-2010 深圳互动力科技有限公司
    /// All rights reserved
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringHelper"/> class.
        /// </summary>
        public StringHelper()
        { }

        #region 返回32位的MD5字符串
        /// <summary>
        /// 返回32位的MD5字符串
        /// </summary>
        /// <param name="md5String"></param>
        /// <returns></returns>
        public static string Tomd5(string md5String)
        {
            string strmd5;
            byte[] result = Encoding.Default.GetBytes(md5String);    //输入密码文本
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            strmd5 = BitConverter.ToString(output).Replace("-", "");  //输出加密文本
            return strmd5;
        }
        #endregion

        /// <summary>
        /// Get a value indicating whether the request is made by search engine (web crawler)
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>Result</returns>
        public static bool IsSearchEngine(HttpRequestBase request)
        {
            if (request == null)
            {
                return false;
            }
            bool result = false;
            try
            {
                result = request.Browser.Crawler;
                if (!result)
                {
                    //put any additional known crawlers in the Regex below for some custom validation
                    //var regEx = new Regex("Twiceler|twiceler|BaiDuSpider|baduspider|Slurp|slurp|ask|Ask|Teoma|teoma|Yahoo|yahoo");
                    //result = regEx.Match(request.UserAgent).Success;
                }
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
            }
            return result;
        }

        /// <summary>
        /// Gets the current URL.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentUrl()
        {
            var currentUrl = string.Empty;
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                var rawUrl = HttpContext.Current.Request.RawUrl;
                if (string.Compare(rawUrl, "/", false) != 0)
                {
                    currentUrl = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + rawUrl;
                }
                else
                {
                    var currentUri = HttpContext.Current.Request.Url;
                    if (currentUri != null)
                    {
                        currentUrl = currentUri.ToString();
                    }
                }
            }
            return HttpUtility.UrlEncode(currentUrl);
        }

        public static string GetUrlPara(string paraName)
        {
            var res = string.Empty;
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                res = HttpContext.Current.Request[paraName];
                if (res == null)
                {
                    var rawUrl = HttpContext.Current.Request.RawUrl;
                    if (string.Compare(rawUrl, "/", false) != 0)
                    {
                        var index = rawUrl.IndexOf("?") < 0 ? 0 : rawUrl.IndexOf("?");
                        rawUrl = rawUrl.Substring(index);
                        var para = HttpUtility.ParseQueryString(rawUrl);
                        var val = para.GetValues(paraName);
                        if (val != null && val.Length > 0)
                        {
                            res = val[0];
                        }
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Gets the referrer URL.
        /// </summary>
        /// <returns></returns>
        public static string GetReferrerUrl()
        {
            var currentReferrerUrl = string.Empty;
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            { }
            var currentReferrerUri = HttpContext.Current.Request.UrlReferrer;
            if (currentReferrerUri != null)
            {
                currentReferrerUrl = currentReferrerUri.ToString();
            }
            return currentReferrerUrl;
        }

        /// <summary>
        /// 网站根目录或主目录地址 http://www.baidu.com/
        /// </summary>
        /// <returns>网站根目录 http://www.baidu.com/</returns>
        public static string GetDomainName()
        {
            var res = "";
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                string strApp = HttpContext.Current.Request.ApplicationPath;
                if (strApp == "/")
                {
                    strApp = "";
                }
                res = HttpContext.Current.Request.Url.Scheme.ToString() + "://" + HttpContext.Current.Request.Url.Authority.ToString() + strApp + "/";
            }
            return res;
        }

        #region 获取真实IP

        /// <summary>
        ///获取真实IP
        ///本机127.0.0.1
        /// </summary>
        public static string GetRealIP()
        {
            string ip = string.Empty;
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                HttpRequest request = HttpContext.Current.Request;
                ip = request.UserHostAddress;
                if (ip.CompareTo("::1") == 0)
                {
                    ip = "127.0.0.1";
                }
            }
            return ip;
        }

        /// <summary>
        /// 获取192.168.1.* IP // 匿名
        /// </summary>
        /// <returns></returns>
        public static string GetAnonyIP()
        {
            string ip = string.Empty;
            try
            {
                if (HttpContext.Current != null && HttpContext.Current.Request != null)
                {
                    HttpRequest request = HttpContext.Current.Request;
                    ip = request.UserHostAddress;
                    if (ip.CompareTo("::1") == 0)
                    {
                        ip = "127.0.0.1";
                    }
                    string[] array = ip.Split('.');
                    if (array.Length == 4)
                    {
                        ip = array[0] + "." + array[1] + "." + array[2] + "." + "*";
                    }
                    else
                    {
                        ip = "匿名";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return ip;
        }

        #endregion

        #region 将IP地址转化为数字
        //将IP 地址转化为数字
        public static long IPtoNum(string Ip)
        {
            string[] stringip = new string[4];
            stringip = Ip.Split('.');
            long ipnum = Convert.ToInt64((stringip[0])) * 16777216 + Convert.ToInt64(stringip[1]) * 65536 + Convert.ToInt64(stringip[2]) * 256 + Convert.ToInt64(stringip[3]);
            return ipnum;
        }
        #endregion

        #region 从字符串中的尾部删除指定的字符串
        /// <summary>
        /// 从字符串中的尾部删除指定的字符串
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="removedString"></param>
        /// <returns></returns>
        public static string Remove(string sourceString, string removedString)
        {
            try
            {
                if (sourceString.IndexOf(removedString) < 0)
                    throw new Exception("原字符串中不包含移除字符串！");
                string result = sourceString;
                int lengthOfSourceString = sourceString.Length;
                int lengthOfRemovedString = removedString.Length;
                int startIndex = lengthOfSourceString - lengthOfRemovedString;
                string tempSubString = sourceString.Substring(startIndex);
                if (tempSubString.ToUpper() == removedString.ToUpper())
                {
                    result = sourceString.Remove(startIndex, lengthOfRemovedString);
                }
                return result;
            }
            catch
            {
                return sourceString;
            }
        }
        #endregion

        #region 获取拆分符右边的字符串
        /// <summary>
        /// 获取拆分符右边的字符串
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static string RightSplit(string sourceString, char splitChar)
        {
            string result = null;
            string[] tempString = sourceString.Split(splitChar);
            if (tempString.Length > 0)
            {
                result = tempString[tempString.Length - 1].ToString();
            }
            return result;
        }
        #endregion

        #region 获取拆分符左边的字符串
        /// <summary>
        /// 获取拆分符左边的字符串
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static string LeftSplit(string sourceString, char splitChar)
        {
            string result = null;
            string[] tempString = sourceString.Split(splitChar);
            if (tempString.Length > 0)
            {
                result = tempString[0].ToString();
            }
            return result;
        }
        #endregion

        #region 去掉最后一个逗号
        /// <summary>
        /// 去掉最后一个逗号
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static string DelLastComma(string origin)
        {
            if (origin.IndexOf(",") == -1)
            {
                return origin;
            }
            return origin.Substring(0, origin.LastIndexOf(","));
        }
        #endregion

        #region 删除不可见字符
        /// <summary>
        /// 删除不可见字符
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string DeleteUnVisibleChar(string sourceString)
        {
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder(131);
            for (int i = 0; i < sourceString.Length; i++)
            {
                int Unicode = sourceString[i];
                if (Unicode >= 16)
                {
                    sBuilder.Append(sourceString[i].ToString());
                }
            }
            return sBuilder.ToString();
        }
        #endregion

        #region 获取数组元素的合并字符串
        /// <summary>
        /// 获取数组元素的合并字符串
        /// </summary>
        /// <param name="stringArray"></param>
        /// <returns></returns>
        public static string GetArrayString(string[] stringArray)
        {
            string totalString = null;
            for (int i = 0; i < stringArray.Length; i++)
            {
                totalString = totalString + stringArray[i];
            }
            return totalString;
        }
        #endregion

        #region 获取某一字符串在字符串数组中出现的次数
        /// <summary>
        /// 获取某一字符串在字符串数组中出现的次数
        /// </summary>
        public static int GetStringCount(string[] stringArray, string findString)
        {
            int count = -1;
            string totalString = GetArrayString(stringArray);
            string subString = totalString;

            while (subString.IndexOf(findString) >= 0)
            {
                subString = totalString.Substring(subString.IndexOf(findString));
                count += 1;
            }
            return count;
        }
        #endregion

        #region 获取某一字符串在字符串中出现的次数
        /// <summary>
        ///     获取某一字符串在字符串中出现的次数
        /// </summary>
        /// <param name="stringArray" type="string">
        ///     <para>
        ///         原字符串
        ///     </para>
        /// </param>
        /// <param name="findString" type="string">
        ///     <para>
        ///         匹配字符串
        ///     </para>
        /// </param>
        /// <returns>
        ///     匹配字符串数量
        /// </returns>
        public static int GetStringCount(string sourceString, string findString)
        {
            int count = 0;
            int findStringLength = findString.Length;
            string subString = sourceString;

            while (subString.IndexOf(findString) >= 0)
            {
                subString = subString.Substring(subString.IndexOf(findString) + findStringLength);
                count += 1;
            }
            return count;
        }
        #endregion

        #region 截取从startString开始到原字符串结尾的所有字符
        /// <summary>
        /// 截取从startString开始到原字符串结尾的所有字符   
        /// </summary>
        /// <param name="sourceString" type="string">
        ///     <para>
        ///         
        ///     </para>
        /// </param>
        /// <param name="startString" type="string">
        ///     <para>
        ///         
        ///     </para>
        /// </param>
        /// <returns>
        ///     A string value...
        /// </returns>
        public static string GetSubString(string sourceString, string startString)
        {
            try
            {
                int index = sourceString.ToUpper().IndexOf(startString);
                if (index > 0)
                {
                    return sourceString.Substring(index);
                }
                return sourceString;
            }
            catch
            {
                return "";
            }
        }

        public static string GetSubString(string sourceString, string beginRemovedString, string endRemovedString)
        {
            try
            {
                if (sourceString.IndexOf(beginRemovedString) != 0)
                    beginRemovedString = "";

                if (sourceString.LastIndexOf(endRemovedString, sourceString.Length - endRemovedString.Length) < 0)
                    endRemovedString = "";

                int startIndex = beginRemovedString.Length;
                int length = sourceString.Length - beginRemovedString.Length - endRemovedString.Length;
                if (length > 0)
                {
                    return sourceString.Substring(startIndex, length);
                }
                return sourceString;
            }
            catch
            {
                return sourceString; ;
            }
        }
        #endregion

        #region 按字节数取出字符串的长度
        /// <summary>
        /// 按字节数取出字符串的长度
        /// </summary>
        /// <param name="strTmp">要计算的字符串</param>
        /// <returns>字符串的字节数</returns>
        public static int GetByteCount(string strTmp)
        {
            int intCharCount = 0;
            for (int i = 0; i < strTmp.Length; i++)
            {
                if (System.Text.UTF8Encoding.UTF8.GetByteCount(strTmp.Substring(i, 1)) == 3)
                {
                    intCharCount = intCharCount + 2;
                }
                else
                {
                    intCharCount = intCharCount + 1;
                }
            }
            return intCharCount;
        }
        #endregion

        #region 按字节数要在字符串的位置
        /// <summary>
        /// 按字节数要在字符串的位置
        /// </summary>
        /// <param name="intIns">字符串的位置</param>
        /// <param name="strTmp">要计算的字符串</param>
        /// <returns>字节的位置</returns>
        public static int GetByteIndex(int intIns, string strTmp)
        {
            int intReIns = 0;
            if (strTmp.Trim() == "")
            {
                return intIns;
            }
            for (int i = 0; i < strTmp.Length; i++)
            {
                if (System.Text.UTF8Encoding.UTF8.GetByteCount(strTmp.Substring(i, 1)) == 3)
                {
                    intReIns = intReIns + 2;
                }
                else
                {
                    intReIns = intReIns + 1;
                }
                if (intReIns >= intIns)
                {
                    intReIns = i + 1;
                    break;
                }
            }
            return intReIns;
        }
        #endregion

        #region 在字符串后面填充字符达到目标长度
        /// <summary>
        /// 在字符串后面填充字符达到目标长度
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="fillWord">要填充的字符</param>
        /// <param name="Length">目标长度</param>
        /// <returns>字节的位置</returns>
        public static string BackFillString(string sourceString, string fillWord, int Length)
        {
            string result;
            StringBuilder sb = new StringBuilder();
            sb.Append(sourceString);
            if (sb.Length < Length)
            {
                while (sb.Length < Length)
                {
                    sb.Append(fillWord);
                }
                result = sb.ToString();
            }
            else
            {
                result = sb.ToString();
                result.Substring(0, 7);
            }
            return result;
        }
        #endregion

        #region 在字符串前面填充字符达到目标长度
        /// <summary>
        /// 在字符串前面填充字符达到目标长度
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="fillWord">要填充的字符</param>
        /// <param name="Length">目标长度</param>
        /// <returns>字节的位置</returns>
        public static string FrontFillString(string sourceString, string fillWord, int Length)
        {
            string result;
            StringBuilder sb = new StringBuilder();
            sb.Append(sourceString);
            if (sb.Length < Length)
            {
                while (sb.Length < Length)
                {
                    sb.Insert(0, fillWord);
                }
                result = sb.ToString();
            }
            else
            {
                result = sb.ToString();
                result.Substring(0, Length);
            }
            return result;
        }
        #endregion

        #region 截取指定长度中英文字符串方法 如果是超过长度，则在后面添加".."字符
        /// <summary>
        /// 截取指定长度中英文字符串方法 如果是超过长度，则在后面添加".."字符
        /// 显示新闻标题最非常有用，为了保持页面的格局，对标题进行限定长度，这就需要对中文进行双字符计算
        /// </summary>
        /// <param name="stringToSub">源字符串</param>
        /// <param name="Length">目标长度</param>
        /// <returns>截取结果</returns>
        public static string GetFirstString(string stringToSub, int length)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            char[] stringChar = stringToSub.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int nLength = 0;
            bool isCut = false;
            for (int i = 0; i < stringChar.Length; i++)
            {
                if (regex.IsMatch((stringChar[i]).ToString()))
                {
                    sb.Append(stringChar[i]);
                    nLength += 2;
                }
                else
                {
                    sb.Append(stringChar[i]);
                    nLength = nLength + 1;
                }

                if (nLength > length)
                {
                    isCut = true;
                    break;
                }
            }
            if (isCut)
                return sb.ToString() + "…";
            else
                return sb.ToString();
        }

        #endregion

        #region 过滤单引号
        /// <summary>
        /// 安全过滤单引
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DelSingleQuotes(string str)
        {
            str = str.Trim();
            str = str.Replace("'", "''");
            str = str.Replace("update", "");
            str = str.Replace("select", "");
            str = str.Replace("delete", "");
            str = str.Replace("insert", "");
            str = str.Replace("and", "");
            return str;
        }
        #endregion

        #region 处理数字型参数，假如是其他字符的，设参数为0
        /// <summary>
        /// 处理数字型参数，假如是其他字符的，设参数为0
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int GetIntParam(string p)
        {
            int Param = 0;
            try
            {
                Param = Convert.ToInt32(p);
            }
            catch
            {
                Param = 0;
            }
            return Param;
        }
        #endregion

        #region 处理字符型参数
        /// <summary>
        /// 处理字符型参数，并去掉非法字符
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string GetStringParam(string p)
        {
            string Param = "";
            try
            {
                if (HttpContext.Current.Request["" + p + ""] != null)
                    Param = HttpContext.Current.Request["" + p + ""].ToString();
                else
                    Param = "";
            }
            catch
            {
                Param = "";
            }
            return Param;
        }
        #endregion

        #region 将字符串转换成JS escape编码
        /// <summary>
        /// 将字符串转换成JS escape编码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string SToEscape(string str)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                byte[] ba = System.Text.Encoding.Unicode.GetBytes(str);
                for (int i = 0; i < ba.Length; i += 2)
                {
                    sb.Append("%u");
                    sb.Append(ba[i + 1].ToString("X2"));
                    sb.Append(ba[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch
            {
                return "";
            }
        }
        #endregion

        public static string StrToUrlGbk(string str)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("gbk");
                byte[] ba = encoding.GetBytes(str);
                for (int i = 0; i < ba.Length; i += 2)
                {
                    sb.Append("%");
                    sb.Append(ba[i].ToString("X2"));
                    sb.Append("%");
                    sb.Append(ba[i + 1].ToString("X2"));
                }
                return sb.ToString();
            }
            catch
            {
                return "";
            }
        }

        #region 清除HTML标签的多余
        /// <summary>
        /// 清除HTML标签的多余
        /// </summary>
        /// <param name="el">标签名</param>
        /// <param name="str">源字符串</param>
        /// <returns></returns>
        public static string repElement(string el, string str)
        {
            string pat = @"<" + el + "[^>]+>";
            string rep = "<" + el + ">";
            str = Regex.Replace(str.ToString(), pat, rep);
            return str;
        }
        #endregion

        #region 把读取的文件中的所有的html标记去掉，把&nbsp;替换成空格
        /// <summary>
        /// 把读取的文件中的所有的html标记去掉，把&nbsp;替换成空格
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string ParseHtml(string html)
        {
            html = HttpUtility.HtmlDecode(html);
            string[] el = new string[] { "p", "span", "strong", "table", "div", "tr", "td" };
            foreach (string s in el)
            {
                html = repElement(s, html);
            }
            //删除脚本
            html = Regex.Replace(html, @"<script(.*)</script>", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Regex reg = new Regex("<[^>]*>");
            html = reg.Replace(html, "");

            html = Regex.Replace(html, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"-->", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"<!--.*", "", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            html = html.Replace("<", "");
            html = html.Replace(">", "");
            html = html.Replace("\r\n", "");
            //     html = HttpUtility.HtmlEncode(html).Trim();


            return html;
        }
        #endregion

        #region 读取XML节点属性
        /// <summary>
        /// 读取XML节点属性
        /// </summary>
        /// <param name="sXmlPath"></param>
        /// <returns></returns>
        public static string ReadXml(string sXmlPath)
        {
            try
            {
                string strPopularity = "";
                XmlDocument XmlConfig = new XmlDocument();
                try
                {
                    XmlConfig.Load(sXmlPath);
                }
                catch
                {
                    strPopularity = "0";
                }

                XmlNodeList XmlHostList;
                XmlHostList = XmlConfig.GetElementsByTagName("POPULARITY");
                foreach (XmlElement host in XmlHostList)
                {
                    strPopularity = host.Attributes["TEXT"].Value;
                }
                if (strPopularity == "")
                    strPopularity = "0";
                return strPopularity;
            }
            catch
            {
                return "0";
            }
        }
        #endregion

        #region 检测URL
        public static bool CheckUrl()
        {
            Uri ComeUrl = HttpContext.Current.Request.UrlReferrer;//取得来访URl源
            string cUrl;
            if (ComeUrl == null)
            {
                return false;
            }
            else
            {
                string reffer = ComeUrl.ToString(); ;
                cUrl = "http://" + HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
                if (reffer.Substring(cUrl.Length, 1) == ":")
                {
                    cUrl += ":" + HttpContext.Current.Request.ServerVariables["SERVER_PORT"].ToString();
                }
                int lenth;
                lenth = cUrl.Length;
                cUrl += HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"];
                int result;
                result = String.Compare(reffer, 1, cUrl, 1, lenth, true);
                return (result == 0);
            }

        }
        #endregion

        #region 小写数字转换为大写
        /// <summary>
        /// 小写数字转换为大写
        /// </summary>
        /// <param name="iNum"></param>
        /// <returns></returns>
        public static string ConvertNum(int iNum)
        {
            string[] c_Num1 = { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            string[] c_fh = { "", "十", "百", "千" };
            string[] c_we = { "", "万", "亿", "亿亿" };
            string s = iNum.ToString();
            string ss = "", hh = "";
            bool frist = true;
            int getfh;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '0')
                {
                    if (s[i - 1] == '0')
                        continue;
                    else
                        if (!frist)
                            ss = c_Num1[0] + ss;
                }
                else
                {
                    getfh = s.Length - i - 1;
                    if (getfh % 4 == 0)
                        hh = c_we[getfh / 4];
                    else
                        hh = "";
                    ss = c_Num1[s[i] - 48] + hh + ss;
                    frist = false;
                }
            }
            return ss;
        }
        #endregion

        /// <summary>
        /// 获取星级数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string GetIndexNum(float num, string name)
        {
            string IndexHtml = "";
            int inum = (int)num;
            for (int i = 0; i < inum; i++)
            {
                IndexHtml += "<img height=\"11\" src=\"/images/start.gif\" width=\"12\" alt=\"" + name + ":" + num.ToString() + "\" />" + System.Environment.NewLine;
            }
            if (num > inum)
            {
                IndexHtml += "<img height=\"11\" src=\"/images/start.gif\" width=\"12\" alt=\"" + name + ":" + num.ToString() + "\" />" + System.Environment.NewLine;
            }
            return IndexHtml;
        }

        public static string CleanHtml(string strContent)
        {
            Regex R = new Regex(@"<[^>]*", RegexOptions.IgnoreCase);
            string RText = R.Replace(strContent, "$").Replace(">", "");

            Regex R1 = new Regex(@"[\s]*", RegexOptions.IgnoreCase);
            string R1Text = R1.Replace(RText, "");

            //Regex RR = new Regex("[$]+",RegexOptions.IgnoreCase);
            //string RRText = RR.Replace(R1Text,"$").TrimStart('$').TrimEnd('$').Replace("$","");

            return R1Text;
        }

        public static string FormatHtml(string strHtml)
        {
            string strPics = "";
            string[] aPicInfo = new string[2];
            strHtml = Regex.Replace(strHtml, @"\s[on].+?=([\""|\'])(.*?)\1", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            strHtml = Regex.Replace(strHtml, "(<font[^>]+>)|(</font*>)", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            strHtml = Regex.Replace(strHtml, "(<span[^>]+>)|(</span*>)", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            strHtml = Regex.Replace(strHtml, @"<img.*?\ssrc=([^\""\'\s][^\""\'\s>]*).*?>", "<img src=\"$1\" />", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            string strNHtml = strHtml;
            //正则匹配图片SRC地址
            MatchCollection mc = Regex.Matches(strHtml.Trim(), @"<img.*?\ssrc=([\""\'])([^\""\']+?)\1.*?>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            string[] aPicInfos = new string[mc.Count];
            int i = 0;
            foreach (Match m in mc)
            {
                strPics = m.Groups[2].ToString();
                if (strPics.IndexOf("ipow.cn") < 0 && strPics.IndexOf("face") < 0)
                {
                    aPicInfo = PicHelper.DownPhoto(strPics, "", ".jpg");
                    if (aPicInfo != null)
                    {
                        aPicInfos[i] = aPicInfo[0] + aPicInfo[1];
                        strNHtml = strNHtml.Replace(m.Value.ToString(), "$Pic" + i.ToString() + "$");
                        i++;
                    }
                }
            }
            strNHtml = ParseHtml(strNHtml);
            for (i = 0; i < mc.Count; i++)
            {
                strNHtml = strNHtml.Replace("$Pic" + i.ToString() + "$", "<img src=\"" + aPicInfos[i] + "\" class=\"articleImg\" onload=\"javascript:if(this.width>640)this.width=640\"/>");
            }
            //strNHtml = Regex.Replace(strNHtml.ToLower(), @"<img.*?\ssrc=([\""\'])([^\""\']+?)\1.*?>", "<img src=\"$2\" class=\"articleImg\" onload=\"javascript:if(this.width>640)this.width=640\"/>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return strNHtml;
        }

        /// <summary>
        /// 正则取图片路径
        /// </summary>
        /// <param name="strHtml">HTML代码</param>
        /// <param name="iCount">图片数量</param>
        /// <returns></returns>
        public static string GetPicSrc(string strHtml, int iCount)
        {
            string strNewHtml = "", strPics = "", strPic1 = "";
            //去除onclick,onload等脚本
            strNewHtml = Regex.Replace(strHtml, @"\s[on].+?=([\""|\'])(.*?)\1", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            //将SRC不带引号的图片地址加上引号
            strNewHtml = Regex.Replace(strHtml, @"<img.*?\ssrc=([^\""\'\s][^\""\'\s>]*).*?>", "<img src=\"$1\" />", RegexOptions.IgnoreCase | RegexOptions.Compiled);

            //正则匹配图片SRC地址
            MatchCollection mc = Regex.Matches(strNewHtml.Trim(), @"<img.*?\ssrc=([\""\'])([^\""\']+?)\1.*?>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            int i = 1;
            foreach (Match m in mc)
            {
                if (i > iCount)
                    break;
                strPics = m.Groups[2].ToString();
                if (strPics.IndexOf("face") < 0)
                {
                    strPic1 += strPics + ",";
                    i++;
                }
            }
            return strPic1.TrimEnd(',');

        }

        #region 评论分页
        /// <summary>
        ///  评论分页
        /// </summary>
        public static string UICommPage(int recordAmount, int pageAmount, int PageSize, int PageIndex, string strURL)
        {
            int totalPages = pageAmount;
            if (PageIndex < 1)
            {
                PageIndex = 1;
            }
            if (PageIndex > totalPages)
            {
                PageIndex = totalPages;
            }

            string PageHTML = "";
            if (PageIndex <= 1)
            {
                //PageHTML = "<div class=\"win10topmore123\" align=\"center\">&lt;&lt;</div>" + PageHTML + System.Environment.NewLine;
                //PageHTML =  PageHTML + System.Environment.NewLine;
            }
            else
            {
                PageHTML = "    <a href=\"" + strURL + (PageIndex - 1) + ".html\" id=\"commpage" + (PageIndex - 1) + "\"  onclick=\"ajaxLoadInfo(event,this.href,\'url\',\'commListInfo\');\" title=\"上一页\");\">&lt;&lt;</a>" + PageHTML + System.Environment.NewLine;
            }
            int i;
            if (PageIndex <= 10 && totalPages <= 10)
            {
                for (i = 1; i <= totalPages; i++)
                {
                    if (i == PageIndex)
                    {
                        PageHTML = "    <span>" + i + "</span>" + PageHTML + System.Environment.NewLine;
                    }
                    else
                    {
                        PageHTML = "    <a href=\"" + strURL + i + ".html\" id=\"commpage" + i + "\"  onclick=\"ajaxLoadInfo(event,this.href,\'url\',\'commListInfo\');\"  title=\"第" + i + "页\">" + i + " </a>" + PageHTML + System.Environment.NewLine;
                    }

                }
            }
            else if (totalPages >= 10 && PageIndex <= 5)
            {
                for (i = 1; i <= 10; i++)
                {
                    if (i == PageIndex)
                    {
                        PageHTML = "    <span>" + i + "</span>" + PageHTML + System.Environment.NewLine;
                    }
                    else
                    {
                        PageHTML = "    <a href=\"" + strURL + i + ".html\" id=\"commpage" + i + "\"  onclick=\"ajaxLoadInfo(event,this.href,\'url\',\'commListInfo\');\"  title=\"第" + i + "页\">" + i + " </a>" + PageHTML + System.Environment.NewLine;
                    }

                }
            }
            else if ((PageIndex + 5) <= totalPages)
            {
                for (i = (PageIndex - 4); i <= (PageIndex + 5); i++)
                {
                    if (i == PageIndex)
                    {
                        PageHTML = "    <span>" + i + "</span>" + PageHTML + System.Environment.NewLine;
                    }
                    else
                    {
                        PageHTML = "    <a href=\"" + strURL + i + ".html\" id=\"commpage" + i + "\"   onclick=\"ajaxLoadInfo(event,this.href,\'url\',\'commListInfo\');\"  title=\"第" + i + "页\">" + i + " </a>" + PageHTML + System.Environment.NewLine;
                    }

                }

            }
            else
            {
                for (i = (PageIndex - 4); i <= totalPages; i++)
                {
                    if (i == PageIndex)
                    {
                        PageHTML = "    <span>" + i + "</span>" + PageHTML + System.Environment.NewLine;
                    }
                    else
                    {
                        PageHTML = "    <a href=\"" + strURL + i + ".html\" id=\"commpage" + i + "\"  onclick=\"ajaxLoadInfo(event,this.href,\'url\',\'commListInfo\');\"  title=\"第" + i + "页\">" + i + " </a>" + PageHTML + System.Environment.NewLine;
                    }

                }

            }

            if (PageIndex >= totalPages)
            {
            }
            else
            {
                PageHTML = "    <a href=\"" + strURL + (PageIndex + 1) + ".html\" id=\"commpage" + PageIndex + 1 + "\"  onclick=\"ajaxLoadInfo(event,this.href,\'url\',\'commListInfo\');\"  title=\"下一页\">&gt;&gt;</a>" + PageHTML + System.Environment.NewLine;
            }

            return PageHTML;
        }
        #endregion

        #region 公共分页
        /// <summary>
        ///  评论分页
        /// </summary>
        public static string UIPublicPage(int recordAmount, int pageAmount, int PageSize, int PageIndex, string strURL)
        {
            int totalPages = pageAmount;
            if (PageIndex < 1)
            {
                PageIndex = 1;
            }
            if (PageIndex > totalPages)
            {
                PageIndex = totalPages;
            }

            string PageHTML = "";
            if (PageIndex <= 1)
            {
                //PageHTML = "<div class=\"win10topmore123\" align=\"center\">&lt;&lt;</div>" + PageHTML + System.Environment.NewLine;
                //PageHTML =  PageHTML + System.Environment.NewLine;
            }
            else
            {
                PageHTML = "    <a href=\"" + strURL + (PageIndex - 1) + ".shtml\" id=\"commpage" + (PageIndex - 1) + "\" title=\"上一页\");\">&lt;&lt;</a>" + PageHTML + System.Environment.NewLine;
            }
            int i;
            if (PageIndex <= 10 && totalPages <= 10)
            {
                for (i = 1; i <= totalPages; i++)
                {
                    if (i == PageIndex)
                    {
                        PageHTML = "    <span>" + i + "</span>" + PageHTML + System.Environment.NewLine;
                    }
                    else
                    {
                        PageHTML = "    <a href=\"" + strURL + i + ".shtml\" id=\"commpage" + i + "\" title=\"第" + i + "页\">" + i + " </a>" + PageHTML + System.Environment.NewLine;
                    }

                }
            }
            else if (totalPages >= 10 && PageIndex <= 5)
            {
                for (i = 1; i <= 10; i++)
                {
                    if (i == PageIndex)
                    {
                        PageHTML = "    <span>" + i + "</span>" + PageHTML + System.Environment.NewLine;
                    }
                    else
                    {
                        PageHTML = "    <a href=\"" + strURL + i + ".shtml\" id=\"commpage" + i + "\" title=\"第" + i + "页\">" + i + " </a>" + PageHTML + System.Environment.NewLine;
                    }

                }
            }
            else if ((PageIndex + 5) <= totalPages)
            {
                for (i = (PageIndex - 4); i <= (PageIndex + 5); i++)
                {
                    if (i == PageIndex)
                    {
                        PageHTML = "    <span>" + i + "</span>" + PageHTML + System.Environment.NewLine;
                    }
                    else
                    {
                        PageHTML = "    <a href=\"" + strURL + i + ".shtml\" id=\"commpage" + i + "\" title=\"第" + i + "页\">" + i + " </a>" + PageHTML + System.Environment.NewLine;
                    }

                }

            }
            else
            {
                for (i = (PageIndex - 4); i <= totalPages; i++)
                {
                    if (i == PageIndex)
                    {
                        PageHTML = "    <span>" + i + "</span>" + PageHTML + System.Environment.NewLine;
                    }
                    else
                    {
                        PageHTML = "    <a href=\"" + strURL + i + ".shtml\" id=\"commpage" + i + "\" title=\"第" + i + "页\">" + i + " </a>" + PageHTML + System.Environment.NewLine;
                    }

                }

            }

            if (PageIndex >= totalPages)
            {
            }
            else
            {
                PageHTML = "    <a href=\"" + strURL + (PageIndex + 1) + ".shtml\" id=\"commpage" + PageIndex + 1 + "\" title=\"下一页\">&gt;&gt;</a>" + PageHTML + System.Environment.NewLine;
            }

            return PageHTML;
        }
        #endregion

        /// <summary>
        /// Encodes the specified STR encode.
        /// 
        /// </summary>
        /// <param name="strEncode">The STR encode.</param>
        /// <returns></returns>
        public static string EncodeToUnicode(string strEncode)
        {
            string strReturn = "";//  存储转换后的编码  
            foreach (short shortx in strEncode.ToCharArray())
            {
                strReturn += shortx.ToString("X4");
            }
            return strReturn;
        }

        /// <summary>  
        /// <函数：Decode>  
        ///作用：将16进制数据编码转化为字符串，是Encode的逆过程  
        /// </summary>  
        /// <param name="strDecode"></param>  
        /// <returns></returns>  
        public static string DecodeUnicodeToString(string strDecode)
        {
            string sResult = "";
            for (int i = 0; i < strDecode.Length / 4; i++)
            {
                sResult += (char)short.Parse(strDecode.Substring(i * 4, 4), global::System.Globalization.NumberStyles.HexNumber);
            }
            return sResult;
        }

        /// <summary>
        /// Splits the string.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="tar">The tar.</param>
        /// <returns></returns>
        public static List<string> SplitString(string source, string tar)
        {
            List<string> res = new List<string>();
            string[] temp = source.Split(tar.ToCharArray());
            foreach (var item in temp)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    res.Add(item);
                }
            }
            return res;
        }

        /// <summary>
        /// Splits the STR.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="tar">The tar.</param>
        /// <returns></returns>
        public static List<string> SplitStr(string source, string tar)
        {
            List<string> res = new List<string>();
            int count = GetStringCount(source, tar);
            if (count > 0)
            {
                string sub = source + "";
                for (int i = 0; i < count; i++)
                {
                    int per = sub.IndexOf(tar);
                    string temp = sub.Substring(0, per) + "";
                    res.Add(temp);
                    sub = sub.Substring(per + tar.Length) + "";
                    if (i == count - 1 && !string.IsNullOrEmpty(sub))
                    {
                        res.Add(sub);
                    }
                }
            }
            else
            {
                res.Add(source);
            }
            return res;
        }

        /// <summary>
        /// 转换成 HTML code
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns>字符串</returns>
        public static string ToHtml(string str)
        {
            str = str.Replace("&amp;", "&");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&quot;", "\"");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&gt;", ">");
            str = str.Replace("<br>", "<br/>");
            return str;
        }
    }
}
