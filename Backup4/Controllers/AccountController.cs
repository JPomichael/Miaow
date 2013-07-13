using System;
using System.Web.Mvc;
using System.Web.Security;
using iPow.jd.Models;


namespace iPow.jd.Controllers
{
    public class AccountController : ControllerBase
    {
        public const int PWDLENGTH = 8;

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult LogOn(LogOnModel model, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (MembershipService.ValidateUser(model.UserName, model.Password))
        //        {
        //            FormsService.SignIn(model.UserName, model.RememberMe);
        //            if (Url.IsLocalUrl(returnUrl))
        //            {
        //                return Redirect(returnUrl);
        //            }
        //            else
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "提供的用户名或密码不正确。");
        //        }
        //    }

        //    // 如果我们进行到这一步时某个地方出错，则重新显示表单
        //    return View(model);
        //}

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();
            return View();
        }

        public ActionResult Authenticate()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Authenticate(string token, bool createPersistentCookie)
        {
            SSO.Client.References.SSOPartnerServiceClient client = new SSO.Client.References.SSOPartnerServiceClient("partnerEndpoint");
            SSO.Client.References.SSOUser user = client.ValidateToken(token);
            if (string.IsNullOrEmpty(user.Username) || Guid.Empty.Equals(user.SessionToken))
            {
                return Json(new { result = "DENIED" });
            }
            this.FormsService.SignIn(user.Username, true);
            Session[iPow.function.Helper.SessionNameLogin] = "";
            return Json(new { result = "SUCCESS" });
        }


        /// <summary>
        /// Vcodes the specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="d">The d.</param>
        /// <returns></returns>
        [NoCache]
        public ActionResult Vcode(string d,string id = "")
        {
            VerifyCode v = new VerifyCode();
            string code = v.CreateVerifyCode() + "";                //取随机码
            Session[iPow.function.Helper.SessionNameLogin] = code;
            v.Padding = 10;
            byte[] bytes = v.CreateImage(code);
            return File(bytes, @"image/jpeg");
        }

        /// <summary>
        /// Gets the vcode.
        /// </summary>
        /// <returns></returns>
        [NoCache]
        public JsonResult GetVcode()
        {
            string temp = string.Empty;
            if (Session[iPow.function.Helper.SessionNameLogin] != null)
            {
                temp = Session[iPow.function.Helper.SessionNameLogin].ToString();
            }
            return Json(new { Vcode = temp }, JsonRequestBehavior.AllowGet);
        }
    }
}
