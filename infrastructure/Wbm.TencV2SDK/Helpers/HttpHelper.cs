using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.IO;

namespace Wbm.TencV2SDK.Helpers
{
    /// <summary>
    /// Http 请求助手
    /// </summary>
    public static class HttpHelper
    {
        /// <summary>
        /// 同步方式发起http get请求
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="queryString">参数字符串</param>
        /// <returns>请求返回值</returns>
        public static string HttpGet(string url, string queryString)
        {
            string responseData = null;

            if (!string.IsNullOrEmpty(queryString))
            {
                url += "?" + queryString.Trim(' ', '?', '&');
            }

            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.Timeout = 20000;
            webRequest.KeepAlive = false;

            responseData = WebResponseGet(webRequest);
            webRequest = null;
            return responseData;

        }

        /// <summary>
        /// 获取返回结果http get请求
        /// </summary>
        /// <param name="webRequest">webRequest对象</param>
        /// <returns>请求返回值</returns>
        public static string WebResponseGet(HttpWebRequest webRequest)
        {
            HttpWebResponse httpWebResponse = null;
            try
            {
                httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
                StreamReader responseReader = null;
                string responseData = String.Empty;
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
                responseReader.Close();
                responseReader = null;
                httpWebResponse.Close();
                return responseData;
            }
            catch (WebException wex)
            {
                string responseData = String.Empty;
                if (wex.Status == WebExceptionStatus.ProtocolError)
                {
                    try
                    {
                        responseData = String.Empty;
                        StreamReader responseReader = new StreamReader(wex.Response.GetResponseStream());
                        responseData = responseReader.ReadToEnd();
                        responseReader.Close();
                        responseReader = null;
                    }
                    catch { }
                }
                if (!string.IsNullOrEmpty(responseData))
                {
                    return responseData;
                }
                throw wex;
            }
            finally
            {
                httpWebResponse = null;
            }
        }


        /// <summary>
        /// 同步方式发起http get请求
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="paras">请求参数列表</param>
        /// <returns>请求返回值</returns>
        public static string HttpGet(string url, NameValueCollection paras)
        {
            string querystring = Helpers.UtilHelper.GetQueryFromParas(paras);
            return HttpGet(url, querystring);
        }



        /// <summary>
        /// 同步方式发起http post请求
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="queryString">参数字符串</param>
        /// <returns>请求返回值</returns>
        public static string HttpPost(string url, string queryString)
        {
            StreamWriter requestWriter = null;

            string responseData = null;

            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.Timeout = 20000;
            webRequest.KeepAlive = false;

            try
            {
                //POST the data.
                requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(queryString);
            }
            catch
            {
                throw;
            }
            finally
            {
                requestWriter.Close();
                requestWriter = null;
            }


            responseData = WebResponseGet(webRequest);
            webRequest = null;
            return responseData;

        }
        /// <summary>
        /// 同步方式发起http post请求
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="paras">请求参数列表</param>
        /// <returns>请求返回值</returns>
        public static string HttpPost(string url, NameValueCollection paras)
        {
            string querystring = Helpers.UtilHelper.GetQueryFromParas(paras);
            return HttpPost(url, querystring);
        }


        /// <summary>
        /// 同步方式发起http post请求，可以同时上传文件
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="queryString">请求参数字符串</param>
        /// <param name="files">上传文件列表</param>
        /// <returns>请求返回值</returns>
        public static string HttpPostWithFile(string url, string queryString, NameValueCollection files)
        {
            Stream requestStream = null;
            string responseData = null;
            string boundary = DateTime.Now.Ticks.ToString("x");

            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.Timeout = 20000;
            webRequest.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            webRequest.Method = "POST";
            webRequest.KeepAlive = false;
            webRequest.Credentials = CredentialCache.DefaultCredentials;


            Stream memStream = new MemoryStream();

            byte[] beginBoundary = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            byte[] endBoundary = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

            string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";

            NameValueCollection paras = Helpers.UtilHelper.GetQueryParameters(queryString);

            foreach (var key in paras.AllKeys)
            {
                // 写入头
                memStream.Write(beginBoundary, 0, beginBoundary.Length);

                string formitem = string.Format(formdataTemplate, key, System.Web.HttpUtility.UrlDecode(paras[key]));
                byte[] formitembytes = Encoding.UTF8.GetBytes(formitem);
                memStream.Write(formitembytes, 0, formitembytes.Length);
            }

            string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: \"{2}\"\r\n\r\n";

            foreach (var key in files.AllKeys)
            {
                string name = key;
                string filePath = files[key];
                string file = Path.GetFileName(filePath);
                string contentType = UtilHelper.GetContentType(file);

                // 写入头
                memStream.Write(beginBoundary, 0, beginBoundary.Length);

                string header = string.Format(headerTemplate, name, file, contentType);
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                memStream.Write(headerbytes, 0, headerbytes.Length);

                FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[1024];
                int bytesRead = 0;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    memStream.Write(buffer, 0, bytesRead);
                }

                // 写入结尾
                memStream.Write(endBoundary, 0, endBoundary.Length);

                fileStream.Close();
            }

            webRequest.ContentLength = memStream.Length;

            requestStream = webRequest.GetRequestStream();

            memStream.Position = 0;
            byte[] tempBuffer = new byte[memStream.Length];
            memStream.Read(tempBuffer, 0, tempBuffer.Length);
            memStream.Close();
            requestStream.Write(tempBuffer, 0, tempBuffer.Length);

            requestStream.Close();
            requestStream = null;


            responseData = WebResponseGet(webRequest);
            webRequest = null;
            return responseData;

        }
        /// <summary>
        /// 同步方式发起http post请求，可以同时上传文件
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="paras">请求参数列表</param>
        /// <param name="files">上传文件列表</param>
        /// <returns>请求返回值</returns>
        public static string HttpPostWithFile(string url, NameValueCollection paras, NameValueCollection files)
        {
            string querystring = Helpers.UtilHelper.GetQueryFromParas(paras);
            return HttpPostWithFile(url, querystring, files);
        }

        /// <summary>
        /// 验证证书
        /// </summary>
        /// <returns></returns>
        private static bool ValidateServerCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
/*
 * Author: xusion
 * Created: 2012.06.22
 * Support: http://wobumang.com
 */