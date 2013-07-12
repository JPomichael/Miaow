using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace iPow.Presentation.account.Controllers
{
    [HandleError]
    public class HomeController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        public HomeController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work)
            : base(work)
        { }

        public ActionResult Index()
        {
            var currentSessionUser = Session[iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser]
                as iPow.Service.SSO.Client.AuthService.User;
            if (currentSessionUser != null)
            {
                return RedirectToAction("login", "profile");
            }
            else
            {
                return View();
            }
        }
    }
}
