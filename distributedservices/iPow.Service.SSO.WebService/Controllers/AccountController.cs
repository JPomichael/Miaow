using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iPow.Service.SSO.WebService.Controllers
{
    [HandleError]
    public class AccountController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        public AccountController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work)
            : base(work)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
