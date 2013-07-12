using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace iPow.Infrastructure.Crosscutting.Function
{
    public class WebHttpHelper
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Webs the request.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="postData">The post data.</param>
        /// <returns></returns>
        public string WebRequest(HttpMethod method, string url, string postData)
        {
            this.Message = string.Empty;
            HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            string responseData = "";
            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
            if (method == HttpMethod.POST)
            {
                webRequest.ContentType = "application/x-www-form-urlencoded";
                requestWriter = new StreamWriter(webRequest.GetRequestStream());
                try
                {
                    requestWriter.Write(postData);
                }
                catch (Exception ex)
                {
                    this.Message = ex.Message;
                }
                finally
                {
                    requestWriter.Close();
                    requestWriter = null;
                }
            }
            responseData = GetWebResponse(webRequest);
            webRequest = null;
            return responseData;
        }

        /// <summary>
        /// _s the web response get.
        /// </summary>
        /// <param name="webRequest">The web request.</param>
        /// <returns></returns>
        private string GetWebResponse(HttpWebRequest webRequest)
        {
            this.Message = string.Empty;
            StreamReader responseReader = null;
            string responseData = "";
            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                this.Message = ex.Message;
            }
            finally
            {
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }
            return responseData;
        }
    }
}