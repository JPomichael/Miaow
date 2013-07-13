using System.Web.Mvc;

namespace iPow.jz.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AdminController : ControllerBase
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
        /// 产生验证码
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="d">The d.</param>
        /// <returns></returns>
        public ActionResult Vcode(string id, string d)
        {
            VerifyCode v = new VerifyCode();
            string code = v.CreateVerifyCode();                //取随机码
            Session[id] = code;
            v.Padding = 10;
            byte[] bytes = v.CreateImage(code);
            return File(bytes, @"image/jpeg");
        }

        /// <summary>
        /// 判断输入的验证码是否正确
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        [NoCache]
        public JsonResult CheakVcode(string key)
        {
            if ((string)Session["Logon"] == key)
            {
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
