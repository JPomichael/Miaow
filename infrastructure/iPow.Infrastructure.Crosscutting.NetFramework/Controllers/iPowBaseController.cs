using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;

using iPow.Infrastructure.Crosscutting.NetFramework.Engines;
using System.Web;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class iPowBaseController : System.Web.Mvc.Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected IWorkContext workContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="iPowBaseController"/> class.
        /// </summary>
        /// <param name="work">The work.</param>
        public iPowBaseController(IWorkContext work)
        {
            if (work == null)
            {
                throw new ArgumentNullException("workContext is null");
            }
            workContext = work;
        }

        /// <summary>
        /// URLs to lower.
        /// added by yjihrp 2012.2.3.13.06
        /// modify by yjihrp 2012.2.3.13.06
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        protected virtual void UrlToLower(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            var routes = RouteTable.Routes;
            var context = filterContext.RequestContext;
            var routeData = context.RouteData;
            var dataTokens = routeData.DataTokens;
            if (dataTokens["area"] == null)
                dataTokens.Add("area", "");
            var vpd = routes.GetVirtualPathForArea(context, routeData.Values);
            if (vpd != null)
            {
                var virtualPath = vpd.VirtualPath.ToLower();
                var request = context.HttpContext.Request;
                if (request != null)
                {
                    string path = Request.Path;
                    if (!string.Equals(virtualPath, path))
                    {
                        filterContext.RequestContext.HttpContext.RewritePath("/", virtualPath, request.Url.Query);
                        //这个方法会有问题的中文的时候，两个URL不一样，就会重写，下面是重定向 virtualPath ,再重定向
                        //一直这样下去，
                        //filterContext.Result = new RedirectResult(virtualPath + request.Url.Query, true);
                    }
                }
            }
        }

        /// <summary>
        /// Adds the log.
        /// added by yjihrp 2012.2.3.13.08
        /// modify by yjihrp 2012.2.3.13.08
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        protected virtual void AddExceptionLogInfo(System.Web.Mvc.ExceptionContext filterContext)
        {
            var logType = 1;
            //如果说是有user的话，应该是在Session里面哦，没有则为0
            var userId = 0;

            var pageUrl = filterContext.HttpContext.Request.Url == null ? string.Empty : filterContext.HttpContext.Request.Url.ToString();
            var refUrl = filterContext.HttpContext.Request.UrlReferrer == null ? string.Empty : filterContext.HttpContext.Request.UrlReferrer.ToString();
            var shortMessage = filterContext.Exception.Message;
            var fullMessage = filterContext.Exception.InnerException == null ? filterContext.Exception.StackTrace : filterContext.Exception.InnerException.Message;
            var ipAddress = Crosscutting.Function.StringHelper.GetRealIP();
            iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(logType, userId, pageUrl, refUrl, shortMessage, fullMessage, ipAddress);
        }

        /// <summary>
        /// Adds the excuting log info.
        /// added by yjihrp 2012.2.3.13.24
        /// modify by yjihrp 2012.2.3.13.24
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        protected virtual void AddExcutingLogInfo(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            var logType = 1;
            var userId = 0;

            var pageUrl = filterContext.HttpContext.Request.Url == null ? string.Empty : filterContext.HttpContext.Request.Url.ToString();
            pageUrl = pageUrl.Length > 500 ? pageUrl.Substring(0, 500) : pageUrl;

            var refUrl = filterContext.HttpContext.Request.UrlReferrer == null ? string.Empty : filterContext.HttpContext.Request.UrlReferrer.ToString();
            refUrl = refUrl.Length > 500 ? refUrl.Substring(0, 500) : refUrl;

            var shortMessage = "1.running controller " + filterContext.Controller.ToString();
            shortMessage += ",2.running method " + filterContext.ActionDescriptor.ActionName;
            var fullMessage = "1.browser " + filterContext.HttpContext.Request.Browser.Type;
            fullMessage += ",2.http method " + filterContext.HttpContext.Request.HttpMethod;
            fullMessage += ",3.total bytes " + filterContext.HttpContext.Request.TotalBytes.ToString();
            fullMessage += ",4.user host name " + filterContext.HttpContext.Request.UserHostName;
            fullMessage += ",5.user agent " + filterContext.HttpContext.Request.UserAgent;
            fullMessage += ",6.user host address " + filterContext.HttpContext.Request.UserHostAddress;
            fullMessage += ",7.cookies ";
            for (int i = 0; i < filterContext.HttpContext.Request.Cookies.Count; i++)
            {
                var logCookie = filterContext.HttpContext.Request.Cookies.Get(i);
                fullMessage += " cookie name: " + logCookie.Name;
                fullMessage += "cookie value: " + logCookie.Value;
            }
            var ipAddress = Crosscutting.Function.StringHelper.GetRealIP();
            iPow.Infrastructure.Data.LoggerReopsitoryManager.AddLogInfo(logType, userId, pageUrl, refUrl, shortMessage, fullMessage, ipAddress);
        }

        /// <summary>
        /// Initializes data that might not be available when the constructor is called.
        /// </summary>
        /// <param name="requestContext">The HTTP context and route data.</param>
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            this.UrlToLower(filterContext);
            //AddExcutingLogInfo(filterContext);
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Called when an unhandled exception occurs in the action.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            //AddExceptionLogInfo(filterContext);
            base.OnException(filterContext);
        }

        protected void AddModelStateError()
        {
            var error = ModelState.Values.Where(d => d.Errors.Count > 0).FirstOrDefault();
            if (error != null && error.Errors.Count > 0)
            {
                var errorFirst = error.Errors.FirstOrDefault();
                ModelState.AddModelError(errorFirst.ErrorMessage, errorFirst.ErrorMessage);
            }
        }

        protected virtual RedirectResult LogOffBase()
        {
            //子站 清现自己的session 跳转到sso的logoff带上returnurl
            //sso站 清理session，清理忆登陆标识，清理online user列表
            Session[iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser] = null;
            var returnUrl = iPow.Infrastructure.Crosscutting.Comm.Service.SsoService.GetSsoLogOffAndReturnDefaultUrl();
            return Redirect(returnUrl);
        }
    }
}
