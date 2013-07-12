using System;
using System.Linq;
using System.Web.Mvc;
using iPow.DataSys;
using System.Configuration;
using iPow.jz.Models;

namespace iPow.jz.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Logins this instance.
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult Login()
        {
            return PartialView();
        }

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <param name="rememberMe">if set to <c>true</c> [remember me].</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string email, string password, bool rememberMe)
        {
            if (iPow.DataClass.jz.Querys.IsExistUser(email, password))
            {
                sns_user user = iPow.DataClass.jz.Querys.GetForumSingleUserByEmailPwd(email, password);
                Session["user"] = email;
            }
            return View("Index", new FroumModels());
        }

        /// <summary>
        /// Validates the log on.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        private bool ValidateLogOn(string email, string password)
        {
            if (String.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("Error", "你必须指定一个电子邮件。");
            }
            if (String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("Error", "你必须指定一个密码。");
            }
            if (!iPow.DataClass.jz.Querys.IsExistUser(email, password))
            {
                ModelState.AddModelError("Error", "用户名或密码错误.");
            }
            return ModelState.IsValid;
        }
    }
}
