using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;

namespace Miaow.Presentation.account.Controllers
{
    [HandleError]
    public class HomeController :
        Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {
        public HomeController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work)
            : base(work)
        { }

        public ActionResult Index()
        {
            var currentSessionUser = Session[Miaow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser]
                as Miaow.Service.SSO.Client.AuthService.User;
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
