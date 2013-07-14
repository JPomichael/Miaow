using System;
using System.Web.Mvc;

namespace Miaow.Presentation.dj.Controllers
{
    [HandleError]
    public class AccountController :
        Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {

        public AccountController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work)
            : base(work)
        { }

        public RedirectResult LogOff()
        {
            return base.LogOffBase();
        }
    }
}