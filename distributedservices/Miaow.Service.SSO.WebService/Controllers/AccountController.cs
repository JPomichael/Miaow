using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Miaow.Service.SSO.WebService.Controllers
{
    [HandleError]
    public class AccountController :
        Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {
        public AccountController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work)
            : base(work)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
