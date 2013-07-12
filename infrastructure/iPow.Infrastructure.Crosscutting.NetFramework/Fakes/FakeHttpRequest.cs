using System;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Fakes
{
    /// <summary>
    /// 
    /// </summary>
    public class FakeHttpRequest : HttpRequestBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly HttpCookieCollection _cookies;

        /// <summary>
        /// 
        /// </summary>
        private readonly NameValueCollection _formParams;

        /// <summary>
        /// 
        /// </summary>
        private readonly NameValueCollection _queryStringParams;

        /// <summary>
        /// 
        /// </summary>
        private readonly NameValueCollection _serverVariables;

        /// <summary>
        /// 
        /// </summary>
        private readonly string _relativeUrl;

        /// <summary>
        /// 
        /// </summary>
        private readonly Uri _url;

        /// <summary>
        /// 
        /// </summary>
        private readonly Uri _urlReferrer;

        /// <summary>
        /// 
        /// </summary>
        private readonly string _httpMethod;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeHttpRequest"/> class.
        /// </summary>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <param name="method">The method.</param>
        /// <param name="formParams">The form params.</param>
        /// <param name="queryStringParams">The query string params.</param>
        /// <param name="cookies">The cookies.</param>
        public FakeHttpRequest(string relativeUrl, string method, NameValueCollection formParams, NameValueCollection queryStringParams,
                               HttpCookieCollection cookies)
        {
            _httpMethod = method;
            _relativeUrl = relativeUrl;
            _formParams = formParams;
            _queryStringParams = queryStringParams;
            _cookies = cookies;
            _serverVariables = new NameValueCollection();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeHttpRequest"/> class.
        /// </summary>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <param name="method">The method.</param>
        /// <param name="url">The URL.</param>
        /// <param name="urlReferrer">The URL referrer.</param>
        /// <param name="formParams">The form params.</param>
        /// <param name="queryStringParams">The query string params.</param>
        /// <param name="cookies">The cookies.</param>
        public FakeHttpRequest(string relativeUrl, string method, Uri url, Uri urlReferrer, NameValueCollection formParams, NameValueCollection queryStringParams,
                               HttpCookieCollection cookies)
            : this(relativeUrl, method, formParams, queryStringParams, cookies)
        {
            _url = url;
            _urlReferrer = urlReferrer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeHttpRequest"/> class.
        /// </summary>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <param name="url">The URL.</param>
        /// <param name="urlReferrer">The URL referrer.</param>
        public FakeHttpRequest(string relativeUrl, Uri url, Uri urlReferrer)
            : this(relativeUrl, HttpVerbs.Get.ToString("g"), url, urlReferrer, null, null, null)
        {
        }

        /// <summary>
        /// 在派生类中重写时，获取 Web 服务器变量的集合。
        /// </summary>
        /// <value></value>
        /// <returns>服务器变量</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override NameValueCollection ServerVariables
        {
            get
            {
                return _serverVariables;
            }
        }

        /// <summary>
        /// 在派生类中重写时，获取客户端发送的窗体变量的集合。
        /// </summary>
        /// <value></value>
        /// <returns>窗体变量。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override NameValueCollection Form
        {
            get { return _formParams; }
        }

        /// <summary>
        /// 在派生类中重写时，获取 HTTP 查询字符串变量的集合。
        /// </summary>
        /// <value></value>
        /// <returns>当前请求的 URL 中由客户端发送的查询字符串变量。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override NameValueCollection QueryString
        {
            get { return _queryStringParams; }
        }

        /// <summary>
        /// 在派生类中重写时，获取客户端发送的 Cookie 的集合。
        /// </summary>
        /// <value></value>
        /// <returns>客户端的 Cookie。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override HttpCookieCollection Cookies
        {
            get { return _cookies; }
        }

        /// <summary>
        /// 在派生类中重写时，获取应用程序根目录的虚拟路径，并通过对应用程序根目录使用波形符 (~) 表示法，将该路径转变为相对路径（如“~/page.aspx”的形式）。
        /// </summary>
        /// <value></value>
        /// <returns>当前请求的应用程序根目录的虚拟路径（添加了波形符运算符 (~)）。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override string AppRelativeCurrentExecutionFilePath
        {
            get { return _relativeUrl; }
        }

        /// <summary>
        /// 在派生类中重写时，获取有关当前请求的 URL 的信息。
        /// </summary>
        /// <value></value>
        /// <returns>一个对象，包含有关当前请求的 URL 的信息。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override Uri Url
        {
            get
            {
                return _url;
            }
        }

        /// <summary>
        /// 在派生类中重写时，获取有关链接到当前 URL 的客户端请求的 URL 的信息。
        /// </summary>
        /// <value></value>
        /// <returns>链接到当前请求的页面的 URL。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override Uri UrlReferrer
        {
            get
            {
                return _urlReferrer;
            }
        }

        /// <summary>
        /// 在派生类中重写时，获取具有 URL 扩展名的资源的附加路径信息。
        /// </summary>
        /// <value></value>
        /// <returns>资源的附加路径信息。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override string PathInfo
        {
            get { return String.Empty; }
        }

        /// <summary>
        /// 在派生类中重写时，获取服务器上的 ASP.NET 应用程序的虚拟根路径。
        /// </summary>
        /// <value></value>
        /// <returns>当前应用程序的虚拟路径。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override string ApplicationPath
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// 在派生类中重写时，获取客户端使用的 HTTP 数据传输方法（如 GET、POST 或 HEAD）。
        /// </summary>
        /// <value></value>
        /// <returns>客户端使用的 HTTP 数据传输方法。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override string HttpMethod
        {
            get
            {
                return _httpMethod;
            }
        }
    }
}