using System.Web.Mvc;
using System.Web;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Attributes
{
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
