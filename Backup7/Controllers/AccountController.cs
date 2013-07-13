using System;
using System.Web.Mvc;
using System.Web.Security;

namespace iPow.Presentation.Union.Controllers
{
    [HandleError]
    public class AccountController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="work">The work.</param>
        public AccountController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work)
            : base(work)
        { 
        
        }

        /// <summary>
        /// Logs the off.
        /// </summary>
        /// <returns></returns>
        public RedirectResult LogOff()
        {
            return base.LogOffBase();
        }
    }
}
