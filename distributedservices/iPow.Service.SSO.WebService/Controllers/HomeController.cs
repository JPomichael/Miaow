using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iPow.Service.SSO.WebService.Controllers
{
    [HandleError]
    public class HomeController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {

        public HomeController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work)
            : base(work)
        {
        }

        public ActionResult Index()
        {
            //add Check  by JPomichael Date：2012-4-26
            if (Session[iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser] != null)
            {
                //如果Sessionli 里有的话 说  欢迎亲
                ViewBag.Message = "亲 欢迎拥抱互动旅行网! 爱生活爱旅行 尽在互动力";
            }
            else
            {
                //没有登录直接跳到登陆页
                var loginUrl = iPow.Infrastructure.Crosscutting.Comm.Service.SsoService.GetSsoLogOnAndReturnUrl();
            }
            return View();
        }
    }
}
