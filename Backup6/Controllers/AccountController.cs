using System;
using System.Web.Mvc;

namespace iPow.Presentation.jq.Controllers
{
    [HandleError]
    public class AccountController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        public const int pwdLength = 8;

        public AccountController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work)
            : base(work)
        {

        }

        public RedirectResult LogOff()
        {
            return base.LogOffBase();
        }
    }
}