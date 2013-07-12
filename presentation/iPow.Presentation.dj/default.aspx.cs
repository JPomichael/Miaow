using System;

using System.Web.Mvc;
using System.Web;

namespace iPow.Presentation.dj
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Request.Path;
            HttpContext.Current.RewritePath(Request.ApplicationPath,false);
            IHttpHandler handler = new System.Web.Mvc.MvcHttpHandler();
            handler.ProcessRequest(HttpContext.Current);
            HttpContext.Current.RewritePath(path);
        }
    }
}