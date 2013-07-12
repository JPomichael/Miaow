using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iPow.Presentation.account.Areas.MyAdmin
{
    [HandleError]
    public class ProfileController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {
        iPow.Infrastructure.Crosscutting.Authorize.IUserService userService;

        iPow.Infrastructure.Crosscutting.Comm.Service.IFormsAuthService formAuthService;

        public ProfileController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
        iPow.Infrastructure.Crosscutting.Authorize.IUserService user,
            iPow.Infrastructure.Crosscutting.Comm.Service.IFormsAuthService formAuth)
            : base(work)
        {
            if (user == null)
            {
                throw new ArgumentNullException("userService is null");
            }
            if (formAuth == null)
            {
                throw new ArgumentNullException("formAuthService is null");
            }
            userService = user;
            formAuthService = formAuth;
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Login()
        {
            var model = new iPow.Domain.Dto.Sys_AdminUserDto();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(iPow.Domain.Dto.Sys_AdminUserDto data)
        {
            //formAuthService.Login("", false);
            return RedirectToAction("index", "home");
        }

        public ActionResult LogOut()
        {
            formAuthService.LogOut();
            return RedirectToAction("login", "profile");
        }
    }
}