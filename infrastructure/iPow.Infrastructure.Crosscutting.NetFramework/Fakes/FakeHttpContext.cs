using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Web;
using System.Web.SessionState;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Fakes
{
    /// <summary>
    /// 
    /// </summary>
    public class FakeHttpContext : HttpContextBase
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
        private IPrincipal _principal;

        /// <summary>
        /// 
        /// </summary>
        private readonly NameValueCollection _queryStringParams;

        /// <summary>
        /// 
        /// </summary>
        private readonly string _relativeUrl;

        /// <summary>
        /// 
        /// </summary>
        private readonly string _method;

        /// <summary>
        /// 
        /// </summary>
        private readonly SessionStateItemCollection _sessionItems;

        /// <summary>
        /// 
        /// </summary>
        private HttpResponseBase _response;

        /// <summary>
        /// 
        /// </summary>
        private HttpRequestBase _request;

        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<object, object> _items;

        /// <summary>
        /// Roots this instance.
        /// </summary>
        /// <returns></returns>
        public static FakeHttpContext Root()
        {
            return new FakeHttpContext("~/");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeHttpContext"/> class.
        /// </summary>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <param name="method">The method.</param>
        public FakeHttpContext(string relativeUrl, string method)
            : this(relativeUrl, method, null, null, null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeHttpContext"/> class.
        /// </summary>
        /// <param name="relativeUrl">The relative URL.</param>
        public FakeHttpContext(string relativeUrl) 
            : this(relativeUrl, null, null, null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeHttpContext"/> class.
        /// </summary>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <param name="principal">The principal.</param>
        /// <param name="formParams">The form params.</param>
        /// <param name="queryStringParams">The query string params.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="sessionItems">The session items.</param>
        public FakeHttpContext(string relativeUrl, IPrincipal principal, NameValueCollection formParams,
                               NameValueCollection queryStringParams, HttpCookieCollection cookies,
                               SessionStateItemCollection sessionItems) 
            : this(relativeUrl, null, principal, formParams, queryStringParams, cookies, sessionItems)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeHttpContext"/> class.
        /// </summary>
        /// <param name="relativeUrl">The relative URL.</param>
        /// <param name="method">The method.</param>
        /// <param name="principal">The principal.</param>
        /// <param name="formParams">The form params.</param>
        /// <param name="queryStringParams">The query string params.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="sessionItems">The session items.</param>
        public FakeHttpContext(string relativeUrl, string method, IPrincipal principal, NameValueCollection formParams,
                               NameValueCollection queryStringParams, HttpCookieCollection cookies,
                               SessionStateItemCollection sessionItems)
        {
            _relativeUrl = relativeUrl;
            _method = method;
            _principal = principal;
            _formParams = formParams;
            _queryStringParams = queryStringParams;
            _cookies = cookies;
            _sessionItems = sessionItems;

            _items = new Dictionary<object, object>();
        }

        /// <summary>
        /// 在派生类中重写时，获取当前 HTTP 请求的 <see cref="T:System.Web.HttpRequest"/> 对象。
        /// </summary>
        /// <value></value>
        /// <returns>当前 HTTP 请求。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override HttpRequestBase Request
        {
            get
            {
                return _request ??
                       new FakeHttpRequest(_relativeUrl, _method, _formParams, _queryStringParams, _cookies);
            }
        }

        /// <summary>
        /// Sets the request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void SetRequest(HttpRequestBase request)
        {
            _request = request;
        }

        /// <summary>
        /// 在派生类中重写时，获取当前 HTTP 响应的 <see cref="T:System.Web.HttpResponse"/> 对象。
        /// </summary>
        /// <value></value>
        /// <returns>当前 HTTP 响应。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override HttpResponseBase Response
        {
            get
            {
                return _response ?? new FakeHttpResponse();
            }
        }

        /// <summary>
        /// Sets the response.
        /// </summary>
        /// <param name="response">The response.</param>
        public void SetResponse(HttpResponseBase response)
        {
            _response = response;
        }

        /// <summary>
        /// 在派生类中重写时，获取或设置当前 HTTP 请求的安全信息。
        /// </summary>
        /// <value></value>
        /// <returns>包含当前 HTTP 请求的安全信息的对象。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override IPrincipal User
        {
            get { return _principal; }
            set { _principal = value; }
        }

        /// <summary>
        /// 在派生类中重写时，获取当前 HTTP 请求的 <see cref="T:System.Web.SessionState.HttpSessionState"/> 对象。
        /// </summary>
        /// <value></value>
        /// <returns>当前 HTTP 请求的会话状态对象。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override HttpSessionStateBase Session
        {
            get { return new FakeHttpSessionState(_sessionItems); }
        }

        /// <summary>
        /// 在派生类中重写时，获取一个键/值集合，该集合在 HTTP 请求过程中可以用于在模块与处理程序之间组织和共享数据。
        /// </summary>
        /// <value></value>
        /// <returns>一个键/值集合，使用指定的键提供对集合中单个值的访问。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override System.Collections.IDictionary Items
        {
            get
            {
                return _items;
            }
        }

        /// <summary>
        /// 在派生类中重写时，获取或设置一个值，该值指定 <see cref="T:System.Web.Security.UrlAuthorizationModule"/> 对象是否应跳过对当前请求的授权检查。
        /// </summary>
        /// <value></value>
        /// <returns>如果 <see cref="T:System.Web.Security.UrlAuthorizationModule"/> 应跳过授权检查，则为 true；否则为 false。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override bool SkipAuthorization { get; set; }

        /// <summary>
        /// 在派生类中重写时，返回当前服务类型的对象。
        /// </summary>
        /// <param name="serviceType">要获取的服务对象的类型。</param>
        /// <returns>当前服务类型，如果未找到任何服务，则为 null。</returns>
        /// <exception cref="T:System.NotImplementedException">始终为 。</exception>
        public override object GetService(Type serviceType)
        {
            return null;
        }
    }
}