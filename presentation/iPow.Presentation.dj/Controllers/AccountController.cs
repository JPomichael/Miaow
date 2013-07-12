using System;
using System.Web.Mvc;

namespace iPow.Presentation.dj.Controllers
{
    [HandleError]
    public class AccountController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {

        public AccountController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work)
            : base(work)
        { }

        public RedirectResult LogOff()
        {
            return base.LogOffBase();
        }
    }
}