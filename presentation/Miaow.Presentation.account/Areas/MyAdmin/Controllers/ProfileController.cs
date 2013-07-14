using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Miaow.Presentation.account.Areas.MyAdmin
{
    [HandleError]
    public class ProfileController :
        Miaow.Infrastructure.Crosscutting.NetFramework.Controllers.MiaowBaseController
    {
        Miaow.Infrastructure.Crosscutting.Authorize.IUserService userService;

        Miaow.Infrastructure.Crosscutting.Comm.Service.IFormsAuthService formAuthService;

        public ProfileController(Miaow.Infrastructure.Crosscutting.NetFramework.IWorkContext work,
        Miaow.Infrastructure.Crosscutting.Authorize.IUserService user,
            Miaow.Infrastructure.Crosscutting.Comm.Service.IFormsAuthService formAuth)
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
            var model = new Miaow.Domain.Dto.Sys_AdminUserDto();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(Miaow.Domain.Dto.Sys_AdminUserDto data)
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