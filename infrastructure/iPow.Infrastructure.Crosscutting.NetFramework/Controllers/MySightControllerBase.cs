using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace iPow.Infrastructure.Crosscutting.NetFramework.Controllers
{
    public class MySightControllerBase : System.Web.Mvc.Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
                viewResult.MasterName = "_MySightLayout";
            }
            base.OnActionExecuted(filterContext);
        }

    }
}
