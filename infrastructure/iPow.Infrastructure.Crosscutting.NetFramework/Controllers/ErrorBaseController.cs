using System.Web;
using System.Web.Mvc;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorBaseController : iPowBaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorBaseController"/> class.
        /// </summary>
        public ErrorBaseController(IWorkContext work)
            : base(work)
        { }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string title = string.Empty;
            string message = string.Empty;
            var httpException = RouteData.Values["httpException"] as HttpException;
            var statusCode = (httpException == null) ? 500 : httpException.GetHttpCode();
            switch (statusCode)
            {
                case 400:
                    Response.StatusCode = 400;
                    title = "错误的请求-400";
                    message = "您的请求好像是错误的，服务器不能处理你的请求.";
                    break;
                case 403:
                    Response.StatusCode = 403;
                    title = "服务器禁止访问-403";
                    message = "您的请求服务器禁止访问.";
                    break;
                case 404:
                    Response.StatusCode = 404;
                    title = "页面不存在-404";
                    message = "您请求的页面不存在";
                    break;
                case 500:
                    Response.StatusCode = 500;
                    title = "服务器内部错误-500";
                    message = "请刷新一下试试";
                    break;
                case 502:
                    Response.StatusCode = 502;
                    title = "网关超时-502";
                    message = "Web 服务器用作网关或代理服务器时收到了无效响应";
                    break;

                case 503:
                    Response.StatusCode = 503;
                    title = "服务不可用-503";
                    message = "我们正在努力建设中……";
                    break;
                case 504:
                    Response.StatusCode = 504;
                    title = "网关超时-504";
                    message = "Sorry, something went wrong.It's been logged.";
                    break;
                default:
                    title = "系统提示";
                    if (httpException != null)
                    {
                        message = httpException.Message;
                    }
                    else
                    {
                        message = "系统资源不足，请访问其他资源";
                    }
                    break;
            }
            ViewBag.title = title;
            ViewBag.message = message;
            Response.TrySkipIisCustomErrors = true;
            return View("Error");
        }
    }
}
