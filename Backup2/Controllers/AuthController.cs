using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

using iPow.Service.SSO.WebService.Models;

namespace iPow.Service.SSO.WebService.Controllers
{
    [HandleError]
    public class AuthController :
        iPow.Infrastructure.Crosscutting.NetFramework.Controllers.iPowBaseController
    {

        public AuthController(iPow.Infrastructure.Crosscutting.NetFramework.IWorkContext work)
            : base(work)
        {

        }

        /// <summary>
        /// Logs the on.
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOn()
        {
            return View();
        }

        /// <summary>
        /// Logs the on.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                #region return url

                var referrer = "/";
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    referrer = returnUrl;
                }
                else
                {
                    referrer = Request[iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.UrlParaReturnUrl];
                }

                #endregion
                var userInfo = Session[iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser] as
                 iPow.Service.SSO.Entity.User;
                //用户已登录
                if (userInfo != null)
                {
                    this.UserLogined(userInfo, referrer);
                }
                else
                {
                    var userName = model.UserName;
                    var userPwd = model.Password;
                    if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userPwd))
                    {
                        var userService = iPowServiceSSOEngine.Current
                            .Resolve<iPow.Infrastructure.Crosscutting.Authorize.IUserService>();
                        var userModel = userService.GetUserByUserAndPwd(userName, userPwd);
                        var currentUserDto = AutoMapper.Mapper.Map<iPow.Infrastructure.Data.DataSys.Sys_AdminUser,
                        iPow.Service.SSO.Entity.User>(userModel);
                        if (currentUserDto != null)
                        {
                            currentUserDto.LoginDomain = referrer == null ? "http://sso.ipow.cn" : referrer;
                            currentUserDto.LoginIpAddress = iPow.Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                            iPow.Infrastructure.Crosscutting.Comm.Service.SsoService.SendSsoUserLoginedCookie();
                            return this.UserLogined(currentUserDto, referrer);
                        }
                        else
                        {
                            ModelState.AddModelError("用户名或密码不正确", "用户名或密码不正确");
                            return View(model);
                        }
                    }
                }
            }
            return new EmptyResult();
        }

        /// <summary>
        /// Logs the off.
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOff()
        {
            //子站 清现自己的session 跳转到sso的signout.aspx带上returnurl
            //sso站 清理session，清理已登陆标识，清理online user列表
            var temp = Session[iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser] as iPow.Service.SSO.Entity.User;
            if (temp != null)
            {
                var currentUser = OnLineUserService.OnLineUserList
                    .Where(d => d.username == temp.username && d.id == temp.id).FirstOrDefault();

                OnLineUserService.OnLineUserList.Remove(currentUser);
            }
            Session[iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser] = null;
            iPow.Infrastructure.Crosscutting.Comm.Service.SsoService.SendSsoUserLoginedExpiresCookie();
            Session.Abandon();

            //跳转Url
            string returnUrl = Request[iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.UrlParaReturnUrl];
            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                //如果为空，则关了这个窗口
                //Response.Write("<script>window.opener=null;window.close();</script>");
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Tokens the specified return URL.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Token(string returnUrl)
        {
            var user = Session[iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser]
                as iPow.Service.SSO.Entity.User;
            if (user != null)
            {
                return this.UserLogined(user, returnUrl);
            }
            else
            {
                iPow.Infrastructure.Crosscutting.Comm.Service.SsoService.SendSsoUserLoginedExpiresCookie();
            }
            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                //return RedirectToAction("logon","auth");
            }
            return View();
        }

        /// <summary>
        /// 用户已登录
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        private RedirectResult UserLogined(iPow.Service.SSO.Entity.User user, string returnUrl)
        {
            #region user first login

            var tempOnlineUser = iPow.Service.SSO.WebService.OnLineUserService
                .OnLineUserList.Where(e => e.username == user.username && e.id == user.id)
                .FirstOrDefault();

            if (tempOnlineUser == null)
            {
                var onlineUser = new iPow.Service.SSO.Entity.OnlineUser()
                {
                    Activity = user.Activity,
                    DepartmentID = user.DepartmentID,
                    Email = user.Email,
                    EmployeeID = user.EmployeeID,
                    id = user.id,
                    lastloginip = user.lastloginip,
                    lastlogintime = user.lastlogintime,
                    LoginDomain = user.LoginDomain,
                    LoginIpAddress = user.LoginIpAddress,
                    LoginTime = System.DateTime.Now,
                    logintimes = user.logintimes,
                    password = user.password,
                    Phone = user.Phone,
                    roleid = user.roleid,
                    sex = user.sex,
                    style = user.style,
                    truename = user.truename,
                    UserGuid = user.UserGuid,
                    userid = user.userid,
                    username = user.username,
                    UserType = user.UserType
                };
                iPow.Service.SSO.WebService.OnLineUserService.OnLineUserList.Add(onlineUser);
            }

            #endregion

            #region buileder secutity token

            iPow.Service.SSO.Entity.SecurityToken securityToken = new Entity.SecurityToken()
            {
                CreateTime = System.DateTime.Now,
                TokenId = iPow.Infrastructure.Crosscutting.Comm.Service.SsoService.BuilderTokenId(),
                IsValid = false,
                User = user
            };
            iPow.Service.SSO.WebService.SecurityTokenService.SecurityTokenList.Add(securityToken);

            #endregion

            //add session 这里的session用法，要和子站点统一，管理好时间
            iPow.Infrastructure.Crosscutting.Function.SessionHelper.Add(
                iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionNameCurrentUser,
                user, iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.SessionExpires);

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect("/");
            }
            string splitStr = returnUrl.Contains("?") ? "&" : "?";
            string returnFormat = "{0}{1}" + iPow.Infrastructure.Crosscutting.Comm.Service.ConstService.UrlParaToken + "={2}";
            string tokenStr = securityToken.TokenId;

            var redirectUrl = string.Format(returnFormat, returnUrl, splitStr, tokenStr);
            return Redirect(redirectUrl);
        }
    }
}
