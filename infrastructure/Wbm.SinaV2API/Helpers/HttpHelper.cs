/*
 This file was create by Xusion at 2011.10.27
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Wbm.SinaV2API.Helpers
{
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

            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "GET";
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.Timeout = 20000;
            webRequest.KeepAlive = false;

            try
            {
                responseData = WebResponseGet(webRequest);

                webRequest = null;

                return responseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取返回结果http get请求
        /// </summary>
        /// <param name="webRequest">webRequest对象</param>
        /// <returns>请求返回值</returns>
        public static string WebResponseGet(HttpWebRequest webRequest)
        {
            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
                StreamReader responseReader = null;
                string responseData = String.Empty;
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();

                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
                return responseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// 同步方式发起http get请求
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="paras">请求参数列表</param>
        /// <returns>请求返回值</returns>
        public static string HttpGet(string url, List<QueryParameter> paras)
        {
            string querystring = HttpUtil.GetQueryFromParas(paras);
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

            try
            {
                responseData = WebResponseGet(webRequest);

                webRequest = null;

                return responseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 同步方式发起http post请求
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="paras">请求参数列表</param>
        /// <returns>请求返回值</returns>
        public static string HttpPost(string url, List<QueryParameter> paras)
        {
            string querystring = HttpUtil.GetQueryFromParas(paras);
            return HttpPost(url, querystring);
        }


        /// <summary>
        /// 同步方式发起http post请求，可以同时上传文件
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="queryString">请求参数字符串</param>
        /// <param name="files">上传文件列表</param>
        /// <returns>请求返回值</returns>
        public static string HttpPostWithFile(string url, string queryString, List<QueryParameter> files)
        {
            Stream requestStream = null;
            string responseData = null;
            string boundary = DateTime.Now.Ticks.ToString("x");

            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.Timeout = 20000;
            webRequest.ContentType = "multipart/form-data;charset=utf-8;boundary=" + boundary;
            webRequest.Method = "POST";
            webRequest.KeepAlive = false;
            webRequest.Credentials = CredentialCache.DefaultCredentials;


            try
            {
                Stream memStream = new MemoryStream();

                byte[] beginBoundary = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
                byte[] endBoundary = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");

                // byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                // string formdataTemplate = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";

                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";

                List<QueryParameter> listParams = HttpUtil.GetQueryParameters(queryString);

                foreach (QueryParameter param in listParams)
                {
                    // 写入头
                    memStream.Write(beginBoundary, 0, beginBoundary.Length);

                    string formitem = string.Format(formdataTemplate, param.Name, param.Value);
                    byte[] formitembytes = Encoding.UTF8.GetBytes(formitem);
                    memStream.Write(formitembytes, 0, formitembytes.Length);
                }

                // memStream.Write(boundarybytes, 0, boundarybytes.Length);

                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: \"{2}\"\r\n\r\n";

                foreach (QueryParameter param in files)
                {
                    string name = param.Name;
                    string filePath = param.Value;
                    string file = Path.GetFileName(filePath);
                    string contentType = HttpUtil.GetContentType(file);

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

                    // memStream.Write(boundarybytes, 0, boundarybytes.Length);
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
            }
            catch
            {
                throw;
            }
            finally
            {
                requestStream.Close();
                requestStream = null;
            }

            try
            {
                responseData = WebResponseGet(webRequest);

                webRequest = null;

                return responseData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 同步方式发起http post请求，可以同时上传文件
        /// </summary>
        /// <param name="url">请求URL</param>
        /// <param name="paras">请求参数列表</param>
        /// <param name="files">上传文件列表</param>
        /// <returns>请求返回值</returns>
        public static string HttpPostWithFile(string url, List<QueryParameter> paras, List<QueryParameter> files)
        {
            string querystring = HttpUtil.GetQueryFromParas(paras);
            return HttpPostWithFile(url, querystring, files);
        }


    }

}
