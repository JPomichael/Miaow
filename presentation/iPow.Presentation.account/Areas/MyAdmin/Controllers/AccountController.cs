using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using iPow.Presentation.account.Models;

namespace iPow.Presentation.account.Areas.MyAdmin
{
    [HandleError]
    public class AccountController :
         iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {

        public AccountController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work)
            : base(work)
        { }
 
        public ActionResult LogOn()
        {
            return View();
        }

        public RedirectResult LogOff()
        {
            return base.LogOffBase();
        }
    }
}
