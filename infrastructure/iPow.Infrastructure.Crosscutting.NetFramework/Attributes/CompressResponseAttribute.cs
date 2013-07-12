using System;
using System.Web;
using System.Web.Mvc;
using System.IO.Compression;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    public class CompressResponseAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 在执行操作方法之前由 MVC 框架调用。
        /// </summary>
        /// <param name="filterContext">筛选器上下文。</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestBase request = filterContext.HttpContext.Request;
            string acceptEncoding = request.Headers["Accept-Encoding"];
            if (!String.IsNullOrEmpty(acceptEncoding))
            {
                acceptEncoding = acceptEncoding.ToUpperInvariant();
                HttpResponseBase response = filterContext.HttpContext.Response;
                if (acceptEncoding.Contains("GZIP"))
                {
                    response.AppendHeader("Content-encoding", "gzip");
                    response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
                }
                else if (acceptEncoding.Contains("DEFLATE"))
                {
                    response.AppendHeader("Content-encoding", "deflate");
                    response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
                }
            }
        }
    }
}
