using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Miaow.Presentation.account.Models;

namespace Miaow.Presentation.account.Areas.MyAdmin
{
    [HandleError]
    public class AccountController :
         Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {

        public AccountController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work)
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
