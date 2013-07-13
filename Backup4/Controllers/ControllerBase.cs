using System;

using System.Web.Mvc;
using iPow.jd.Models;
using System.Web.Routing;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace iPow.jd.Controllers
{
    public class ControllerBase : System.Web.Mvc.Controller
    {
        /// <summary>
        /// Gets or sets the forms service.
        /// </summary>
        /// <value>The forms service.</value>
        public IFormsAuthenticationService FormsService { get; set; }

        /// <summary>
        /// 初始化调用构造函数后可能不可用的数据。
        /// </summary>
        /// <param name="requestContext">HTTP 上下文和路由数据。</param>
        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            base.Initialize(requestContext);
        }

        /// <summary>
        /// Called when [action executing].
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            #region
            var tokenModel = context.HttpContext.Request.Cookies[".ipow.cn"];
            if (tokenModel != null)
            {
                string token = tokenModel.Value;
                if (!string.IsNullOrEmpty(token))
                {
                    if (User.Identity != null && User.Identity.IsAuthenticated)
                    {
                        //HttpCookie localhost = new HttpCookie(FormsAuthentication.FormsCookieName);
                        //localhost.Path = "/";
                        //localhost.HttpOnly = true;
                        //localhost.Expires = DateTime.Now.AddDays(-10000.0);
                        //Response.Cookies.Add(localhost);
                    }
                }
            }
            #endregion
            if (context.HttpContext.User.Identity is WindowsIdentity)
            {
                throw new InvalidOperationException("Windows authentication is not supported.");
            }

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class NoCache : ActionFilterAttribute
    {
        /// <summary>
        /// Called when [result executing].
        /// </summary>
        /// <param name="filter">The filter.</param>
        public override void OnResultExecuting(ResultExecutingContext filter)
        {
            filter.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filter.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filter.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filter.HttpContext.Response.Cache.SetNoStore();
            base.OnResultExecuting(filter);
        }
    }
}